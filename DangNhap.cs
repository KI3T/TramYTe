using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TramYTe.Database;

namespace TramYTe
{
    public partial class DangNhap : Form
    {
        /* -------------------------------------------------------------------------------------------- */
        /* -------------------------------------------------------------------------------------------- */
        private bool dragging = false;
        private Point startPoint;
        private void Controlbar_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void Controlbar_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point newPoint = PointToScreen(e.Location);
                Location = new Point(newPoint.X - startPoint.X, newPoint.Y - startPoint.Y);
            }
        }

        private void Controlbar_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void buttonX_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void buttonShowPass_Click(object sender, EventArgs e)
        {
            if (textBoxMatKhau.UseSystemPasswordChar == true)
            {
                textBoxMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                if (textBoxMatKhau.Text == "Mật khẩu")
                {
                    textBoxMatKhau.UseSystemPasswordChar = false;
                }
                else
                {
                    textBoxMatKhau.UseSystemPasswordChar = true;
                }
            }
        }

        private void textBoxTaiKhoan_Enter(object sender, EventArgs e)
        {
            if (textBoxTaiKhoan.Text == "Tài khoản")
            {
                textBoxTaiKhoan.Text = "";
                textBoxTaiKhoan.ForeColor = Color.Black;
            }
        }

        private void textBoxTaiKhoan_Leave(object sender, EventArgs e)
        {
            if (textBoxTaiKhoan.Text == "")
            {
                textBoxTaiKhoan.Text = "Tài khoản";
                textBoxTaiKhoan.ForeColor = Color.Gray;
            }
        }

        private void textBoxMatKhau_Enter(object sender, EventArgs e)
        {
            if (textBoxMatKhau.Text == "Mật khẩu")
            {
                textBoxMatKhau.Text = "";
                textBoxMatKhau.UseSystemPasswordChar = true;
                textBoxMatKhau.ForeColor = Color.Black;
            }
        }

        private void textBoxMatKhau_Leave(object sender, EventArgs e)
        {
            if (textBoxMatKhau.Text == "")
            {
                textBoxMatKhau.Text = "Mật khẩu";
                textBoxMatKhau.UseSystemPasswordChar = false;
                textBoxMatKhau.ForeColor = Color.Gray;
            }
        }

        private void textBoxTaiKhoan_TextChanged(object sender, EventArgs e)
        {
            if ((textBoxTaiKhoan.Text != "" && textBoxTaiKhoan.Text != "Tài khoản")
                && (textBoxMatKhau.Text != "" && textBoxMatKhau.Text != "Mật khẩu"))
            {
                buttonDangNhap.Enabled = true;
                buttonDangNhap.BackColor = Color.Red;
                buttonDangNhap.Cursor = Cursors.Hand;
            }
            else
            {
                buttonDangNhap.Enabled = false;
                buttonDangNhap.BackColor = Color.Transparent;
                buttonDangNhap.Cursor = Cursors.Default;
            }
        }

        private void textBoxMatKhau_TextChanged(object sender, EventArgs e)
        {
            if ((textBoxTaiKhoan.Text != "" && textBoxTaiKhoan.Text != "Tài khoản")
                && (textBoxMatKhau.Text != "" && textBoxMatKhau.Text != "Mật khẩu"))
            {
                buttonDangNhap.Enabled = true;
                buttonDangNhap.BackColor = Color.Red;
                buttonDangNhap.Cursor = Cursors.Hand;
            }
            else
            {
                buttonDangNhap.Enabled = false;
                buttonDangNhap.BackColor = Color.Transparent;
                buttonDangNhap.Cursor = Cursors.Default;
            }
        }

        private void textBoxTaiKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && e.KeyChar > 127)
            {
                // Loại bỏ ký tự đó
                e.Handled = true;
            }
        }

        private void textBoxMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && e.KeyChar > 127)
            {
                e.Handled = true;
            }
        }
        /* -------------------------------------------------------------------------------------------- */
        /* -------------------------------------------------------------------------------------------- */

        public DangNhap()
        {
            InitializeComponent();
        }

        private dbTYTDataContext db;
        public string maho = "";

        private void buttonDangNhap_Click(object sender, EventArgs e)
        {
            db = new dbTYTDataContext();
            var v = (from s in db.TaiKhoanDangNhaps
                     where s.TaiKhoan == textBoxTaiKhoan.Text
                     select s).FirstOrDefault();

            if (v == null)
            {
                MessageBox.Show("Không tìm thấy tài khoản!");
            }
            else
            {
                if (v.MatKhau == textBoxMatKhau.Text)
                {
                    maho = (from s in db.TaiKhoanDangNhaps
                             where s.TaiKhoan == textBoxTaiKhoan.Text
                             select s.MaHo).FirstOrDefault();
                    if (v.Quyen == "admin")
                    {
                        MainAdmin f = new MainAdmin();
                        this.Hide();
                        f.ShowDialog();
                        this.Show();
                        
                    }
                    else
                    {
                        MainHome f = new MainHome();
                        f.mh = maho;
                        this.Hide();
                        f.ShowDialog();
                        this.Show();
                    }
                    textBoxTaiKhoan.Text = null;
                    textBoxMatKhau.Text = null;
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
                }
            }
        }
    }
}
