using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TramYTe.AdminMain;

namespace TramYTe
{
    public partial class MainAdmin : Form
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
        /* -------------------------------------------------------------------------------------------- */
        /* -------------------------------------------------------------------------------------------- */

        public MainAdmin()
        {
            InitializeComponent();
        }

        private void buttonThongTinVaccine_Click(object sender, EventArgs e)
        {
            buttonThongTinVaccine.BackColor = Color.White;
            buttonQuanLyTiemChung.BackColor = Color.Transparent;
            buttonQuanLyDinhDuong.BackColor = Color.Transparent;
            buttonQuanLyKhamKhai.BackColor = Color.Transparent;
            buttonChamSocTreEm.BackColor = Color.Transparent;
            buttonQuanLyHoGiaDinh.BackColor = Color.Transparent;
            buttonQuanLyPhongKham.BackColor = Color.Transparent;
            buttonQuanLyThongBao.BackColor = Color.Transparent;

            panelAdmin.Controls.Clear();
            ThongTinVaccine formThongTinVaccine = new ThongTinVaccine();
            formThongTinVaccine.TopLevel = false; // form ThongTinVaccine không phải là TopLevel
            formThongTinVaccine.AutoScroll = true; // Cho phép scroll bar
            panelAdmin.Controls.Add(formThongTinVaccine); // Thêm form ThongTinVaccine vào panelAdmin
            formThongTinVaccine.Show(); // Hiển thị form ThongTinVaccine
        }

        private void QuanLyTiemChung_Click(object sender, EventArgs e)
        {
            buttonThongTinVaccine.BackColor = Color.Transparent;
            buttonQuanLyTiemChung.BackColor = Color.White;
            buttonQuanLyDinhDuong.BackColor = Color.Transparent;
            buttonQuanLyKhamKhai.BackColor = Color.Transparent;
            buttonChamSocTreEm.BackColor = Color.Transparent;
            buttonQuanLyHoGiaDinh.BackColor = Color.Transparent;
            buttonQuanLyPhongKham.BackColor = Color.Transparent;
            buttonQuanLyThongBao.BackColor = Color.Transparent;

            panelAdmin.Controls.Clear();
            QuanLyTiemChung formQuanLyTiemChung = new QuanLyTiemChung();
            formQuanLyTiemChung.TopLevel = false;
            formQuanLyTiemChung.AutoScroll = true;
            panelAdmin.Controls.Add(formQuanLyTiemChung);
            formQuanLyTiemChung.Show();
        }


        private void buttonQuanLyDinhDuong_Click(object sender, EventArgs e)
        {
            buttonThongTinVaccine.BackColor = Color.Transparent;
            buttonQuanLyTiemChung.BackColor = Color.Transparent;
            buttonQuanLyDinhDuong.BackColor = Color.White;
            buttonQuanLyKhamKhai.BackColor = Color.Transparent;
            buttonChamSocTreEm.BackColor = Color.Transparent;
            buttonQuanLyHoGiaDinh.BackColor = Color.Transparent;
            buttonQuanLyPhongKham.BackColor = Color.Transparent;
            buttonQuanLyThongBao.BackColor = Color.Transparent;

            panelAdmin.Controls.Clear();
            QuanLyDinhDuong formQuanLyDinhDuong = new QuanLyDinhDuong();
            formQuanLyDinhDuong.TopLevel = false;
            formQuanLyDinhDuong.AutoScroll = true;
            panelAdmin.Controls.Add(formQuanLyDinhDuong);
            formQuanLyDinhDuong.Show();
        }

        private void buttonQuanLyKhamKhai_Click(object sender, EventArgs e)
        {
            buttonThongTinVaccine.BackColor = Color.Transparent;
            buttonQuanLyTiemChung.BackColor = Color.Transparent;
            buttonQuanLyDinhDuong.BackColor = Color.Transparent;
            buttonQuanLyKhamKhai.BackColor = Color.White;
            buttonChamSocTreEm.BackColor = Color.Transparent;
            buttonQuanLyHoGiaDinh.BackColor = Color.Transparent;
            buttonQuanLyPhongKham.BackColor = Color.Transparent;
            buttonQuanLyThongBao.BackColor = Color.Transparent;

            panelAdmin.Controls.Clear();
            QuanLyKhamThai formQuanLyKhamThai = new QuanLyKhamThai();
            formQuanLyKhamThai.TopLevel = false;
            formQuanLyKhamThai.AutoScroll = true;
            panelAdmin.Controls.Add(formQuanLyKhamThai);
            formQuanLyKhamThai.Show();
        }

        private void buttonChamSocTreEm_Click(object sender, EventArgs e)
        {
            buttonThongTinVaccine.BackColor = Color.Transparent;
            buttonQuanLyTiemChung.BackColor = Color.Transparent;
            buttonQuanLyDinhDuong.BackColor = Color.Transparent;
            buttonQuanLyKhamKhai.BackColor = Color.Transparent;
            buttonChamSocTreEm.BackColor = Color.White;
            buttonQuanLyHoGiaDinh.BackColor = Color.Transparent;
            buttonQuanLyPhongKham.BackColor = Color.Transparent;
            buttonQuanLyThongBao.BackColor = Color.Transparent;

            panelAdmin.Controls.Clear();
            ChamSocTreEm formChamSocTreEm = new ChamSocTreEm();
            formChamSocTreEm.TopLevel = false;
            formChamSocTreEm.AutoScroll = true;
            panelAdmin.Controls.Add(formChamSocTreEm);
            formChamSocTreEm.Show();
        }


        private void buttonQuanLyHoGiaDinh_Click(object sender, EventArgs e)
        {
            buttonThongTinVaccine.BackColor = Color.Transparent;
            buttonQuanLyTiemChung.BackColor = Color.Transparent;
            buttonQuanLyDinhDuong.BackColor = Color.Transparent;
            buttonQuanLyKhamKhai.BackColor = Color.Transparent;
            buttonChamSocTreEm.BackColor = Color.Transparent;
            buttonQuanLyHoGiaDinh.BackColor = Color.White;
            buttonQuanLyPhongKham.BackColor = Color.Transparent;
            buttonQuanLyThongBao.BackColor = Color.Transparent;

            panelAdmin.Controls.Clear();
            QuanLyHoGiaDinh formQuanLyHoGiaDinh = new QuanLyHoGiaDinh();
            formQuanLyHoGiaDinh.TopLevel = false;
            formQuanLyHoGiaDinh.AutoScroll = true;
            panelAdmin.Controls.Add(formQuanLyHoGiaDinh);
            formQuanLyHoGiaDinh.Show();
        }

        private void buttonQuanLyPhongKham_Click(object sender, EventArgs e)
        {
            buttonThongTinVaccine.BackColor = Color.Transparent;
            buttonQuanLyTiemChung.BackColor = Color.Transparent;
            buttonQuanLyDinhDuong.BackColor = Color.Transparent;
            buttonQuanLyKhamKhai.BackColor = Color.Transparent;
            buttonChamSocTreEm.BackColor = Color.Transparent;
            buttonQuanLyHoGiaDinh.BackColor = Color.Transparent;
            buttonQuanLyPhongKham.BackColor = Color.White;
            buttonQuanLyThongBao.BackColor = Color.Transparent;

            panelAdmin.Controls.Clear();
            QuanLyPhongKham formQuanLyPhongKham = new QuanLyPhongKham();
            formQuanLyPhongKham.TopLevel = false;
            formQuanLyPhongKham.AutoScroll = true;
            panelAdmin.Controls.Add(formQuanLyPhongKham);
            formQuanLyPhongKham.Show();
        }

        private void buttonQuanLyThongBao_Click(object sender, EventArgs e)
        {
            buttonThongTinVaccine.BackColor = Color.Transparent;
            buttonQuanLyTiemChung.BackColor = Color.Transparent;
            buttonQuanLyDinhDuong.BackColor = Color.Transparent;
            buttonQuanLyKhamKhai.BackColor = Color.Transparent;
            buttonChamSocTreEm.BackColor = Color.Transparent;
            buttonQuanLyHoGiaDinh.BackColor = Color.Transparent;
            buttonQuanLyPhongKham.BackColor = Color.Transparent;
            buttonQuanLyThongBao.BackColor = Color.White;

            panelAdmin.Controls.Clear();
            QuanLyThongBao formQuanLyThongBao = new QuanLyThongBao();
            formQuanLyThongBao.TopLevel = false;
            formQuanLyThongBao.AutoScroll = true;
            panelAdmin.Controls.Add(formQuanLyThongBao);
            formQuanLyThongBao.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            TaoThongBao f = new TaoThongBao();
            f.ShowDialog();
        }

    }
}
