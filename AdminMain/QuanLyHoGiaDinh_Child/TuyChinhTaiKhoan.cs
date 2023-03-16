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

namespace TramYTe.AdminMain.QuanLyHoGiaDinh_Child
{
    public partial class TuyChinhTaiKhoan : Form
    {
        public TuyChinhTaiKhoan()
        {
            InitializeComponent();
        }

        private dbTYTDataContext db;
        private DataGridViewRow r;
        private void Show()
        {
            db = new dbTYTDataContext();
            DGV.DataSource = from a in db.TaiKhoanDangNhaps
                             select new
                             {
                                 a.TaiKhoan,
                                 a.MatKhau,
                                 a.MaHo,
                                 a.Quyen
                             };
        }

        private void QuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            db = new dbTYTDataContext();
            var kp = from s in db.HoGiaDinhs
                     select s.MaHo;

            comboBoxMaHo.DataSource = kp.ToList();

            Show();
            DGV.Columns["TaiKhoan"].HeaderText = "Tài khoản";
            DGV.Columns["MatKhau"].HeaderText = "Mật khẩu";
            DGV.Columns["MaHo"].HeaderText = "Mã hộ";
            DGV.Columns["Quyen"].HeaderText = "Quyền";
            panelThongTin.Visible = false;
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                r = DGV.Rows[e.RowIndex];
            }
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            panelThongTin.Visible = true;
        }

        private void buttonXacNhan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxTaiKhoan.Text))
            {
                MessageBox.Show("Tài khoản khám không thể trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxTaiKhoan.Select();
                return;
            }
            else if (string.IsNullOrEmpty(textBoxMatKhau.Text))
            {
                MessageBox.Show("Mật khẩu không thể trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxMatKhau.Select();
                return;
            }
            else
            {
                var s = db.TaiKhoanDangNhaps.Where(p => p.TaiKhoan == textBoxTaiKhoan.Text).Count();
                if (s > 0)
                {
                    MessageBox.Show("Tài khoản đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxTaiKhoan.Select();
                    return;
                }
            }

            TaiKhoanDangNhap tk = new TaiKhoanDangNhap();
            tk.TaiKhoan = textBoxTaiKhoan.Text;
            tk.MatKhau = textBoxMatKhau.Text;
            tk.MaHo = comboBoxMaHo.Text;
            tk.Quyen = comboBoxQuyen.Text;
            db.TaiKhoanDangNhaps.InsertOnSubmit(tk);
            db.SubmitChanges();
            MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Show();
            textBoxTaiKhoan.Text = textBoxMatKhau.Text = null;
            panelThongTin.Visible = false;
        }

        private void buttonLamMoi_Click(object sender, EventArgs e)
        {
            textBoxTaiKhoan.Text = textBoxMatKhau.Text = null;
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            SuaTaiKhoan f = new SuaTaiKhoan();
            f.Show();
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn Tài khoản muốn xóa hoặc thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var s = db.TaiKhoanDangNhaps.SingleOrDefault(p => p.TaiKhoan == DGV.SelectedCells[0].OwningRow.Cells["TaiKhoan"].Value.ToString());
                db.TaiKhoanDangNhaps.DeleteOnSubmit(s);
                db.SubmitChanges();
                MessageBox.Show("Xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Show();
                r = null;
            }
            catch (Exception)
            {
                MessageBox.Show("Hãy thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            db = new dbTYTDataContext();
            var searchResults = from a in db.TaiKhoanDangNhaps
                                where a.TaiKhoan.Contains(textBoxTimKiem.Text)
                                || a.MaHo.Contains(textBoxTimKiem.Text)
                                || a.Quyen.Contains(textBoxTimKiem.Text)
                                select new
                                {
                                    a.TaiKhoan,
                                    a.MatKhau,
                                    a.MaHo,
                                    a.Quyen
                                };
            DGV.DataSource = searchResults.ToList();
        }

        private void buttonXemDanhSach_Click(object sender, EventArgs e)
        {
            Show();
        }

        private void DGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DGV.Columns[e.ColumnIndex].Name == "MatKhau" && e.Value != null)
            {
                e.Value = new string('*', e.Value.ToString().Length);
            }
        }
    }
}
