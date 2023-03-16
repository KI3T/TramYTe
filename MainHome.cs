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
using TramYTe.Database;

namespace TramYTe
{
    public partial class MainHome : Form
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

        public MainHome()
        {
            InitializeComponent();
        }

        private dbTYTDataContext db;
        public string mh;
        private void MainHome_Load(object sender, EventArgs e)
        {
            labelMaHo.Text = mh;
        }

        private void buttonThanhVienGiaDinh_Click(object sender, EventArgs e)
        {
            buttonThanhVienGiaDinh.BackColor = Color.White;
            buttonTiemChung.BackColor = Color.Transparent;
            buttonDinhDuong.BackColor = Color.Transparent;
            buttonThaiKy.BackColor = Color.Transparent;
            buttonPhongKham.BackColor = Color.Transparent;

            DGV.DataSource = null;
            db = new dbTYTDataContext();
            DGV.DataSource = from b in db.ThanhViens
                             where mh == b.MaHo
                             select new
                             {
                                 b.MaThanhVien,
                                 b.HoTen,
                                 b.NgaySinh,
                                 b.GioiTinh,
                                 b.DienThoai,
                                 b.CCCD,
                                 b.LichSuBenhAn
                             };
            DGV.Columns["MaThanhVien"].HeaderText = "Mã thành viên";
            DGV.Columns["HoTen"].HeaderText = "Họ tên";
            DGV.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            DGV.Columns["GioiTinh"].HeaderText = "Giới tính";
            DGV.Columns["DienThoai"].HeaderText = "Số điện thoại";
            DGV.Columns["CCCD"].HeaderText = "Căn cước công dân";
            DGV.Columns["LichSuBenhAn"].HeaderText = "Lịch sử bệnh án";
        }

        private void buttonTiemChung_Click(object sender, EventArgs e)
        {
            buttonThanhVienGiaDinh.BackColor = Color.Transparent;
            buttonTiemChung.BackColor = Color.White;
            buttonDinhDuong.BackColor = Color.Transparent;
            buttonThaiKy.BackColor = Color.Transparent;
            buttonPhongKham.BackColor = Color.Transparent;

            DGV.DataSource = null;
            db = new dbTYTDataContext();
            DGV.DataSource = from a in db.TiemChungs
                             from b in db.ThanhViens
                             from c in db.Vaccines
                             where a.MaThanhVien == b.MaThanhVien
                                   && a.MaVaccine == c.MaVaccine
                             select new
                             {
                                 a.MaPhieuTiemChung,
                                 a.MaThanhVien,
                                 b.HoTen,
                                 a.MaVaccine,
                                 c.TenVaccine,
                                 a.SoLuong,
                                 a.TrieuChungSauTiem,
                                 a.NgayTiem,
                                 NgayTiemTiepTheo = a.TrangThai == true ? null as DateTime? : Convert.ToDateTime(a.NgayTiem).AddDays((double)c.ChuKyTiem) as DateTime?,
                             };
            DGV.Columns["MaPhieuTiemChung"].HeaderText = "Mã phiếu tiêm chủng";
            DGV.Columns["HoTen"].HeaderText = "Họ tên";
            DGV.Columns["TenVaccine"].HeaderText = "Tên Vaccine";
            DGV.Columns["SoLuong"].HeaderText = "Số lượng";
            DGV.Columns["NgayTiem"].HeaderText = "Ngày tiêm";
            DGV.Columns["TrieuChungSauTiem"].HeaderText = "Triệu chứng sau tiêm";
            DGV.Columns["NgayTiemTiepTheo"].HeaderText = "Ngày tiêm tiếp theo";
        }

        private void buttonDinhDuong_Click(object sender, EventArgs e)
        {
            buttonThanhVienGiaDinh.BackColor = Color.Transparent;
            buttonTiemChung.BackColor = Color.Transparent;
            buttonDinhDuong.BackColor = Color.White;
            buttonThaiKy.BackColor = Color.Transparent;
            buttonPhongKham.BackColor = Color.Transparent;

            DGV.DataSource = null;
            db = new dbTYTDataContext();
            DGV.DataSource = from a in db.ThanhViens
                             from b in db.DinhDuongs
                             where mh == a.MaHo
                             where a.MaThanhVien == b.MaThanhVien
                             let bmi = Convert.ToDouble(b.CanNang / ((b.ChieuCao / 100) * (b.ChieuCao / 100)))
                             select new
                             {
                                 b.MaPhieuDinhDuong,
                                 a.HoTen,
                                 b.ChieuCao,
                                 b.CanNang,
                                 BMI = Math.Round(bmi, 1, MidpointRounding.AwayFromZero),
                                 TinhTrang = bmi < 16 ? "Gầy độ III" :
                                             bmi < 17 ? "Gầy độ II" :
                                             bmi < 18.5 ? "Gầy độ I" :
                                             bmi < 25 ? "Bình thường" :
                                             bmi < 30 ? "Thừa cân" :
                                             bmi < 35 ? "Béo phì độ I" :
                                             bmi < 40 ? "Béo phì độ II" :
                                             "Béo phì độ III",
                                 b.NgayKham
                             };
            DGV.Columns["MaPhieuDinhDuong"].HeaderText = "Mã phiếu dinh dưỡng";
            DGV.Columns["HoTen"].HeaderText = "Họ tên";
            DGV.Columns["ChieuCao"].HeaderText = "Chiều cao (cm)";
            DGV.Columns["CanNang"].HeaderText = "Cân nặng (kg)";
            DGV.Columns["BMI"].HeaderText = "BMI";
            DGV.Columns["TinhTrang"].HeaderText = "Tình trạng";
            DGV.Columns["NgayKham"].HeaderText = "Ngày khám";
        }

        private void buttonThaiKy_Click(object sender, EventArgs e)
        {
            buttonThanhVienGiaDinh.BackColor = Color.Transparent;
            buttonTiemChung.BackColor = Color.Transparent;
            buttonDinhDuong.BackColor = Color.Transparent;
            buttonThaiKy.BackColor = Color.White;
            buttonPhongKham.BackColor = Color.Transparent;

            DGV.DataSource = null;
            db = new dbTYTDataContext();
            DGV.DataSource = from a in db.ThanhViens
                             from b in db.ThaiKies
                             where mh == a.MaHo
                             where a.MaThanhVien == b.MaThanhVien
                             select new
                             {
                                 b.MaPhieuKhamThai,
                                 a.HoTen,
                                 b.CanNang,
                                 b.NgayMangThai,
                                 b.NgayKham,
                                 b.NgayTaiKham
                             };
            DGV.Columns["MaPhieuKhamThai"].HeaderText = "Mã phiếu khám thai";
            DGV.Columns["HoTen"].HeaderText = "Họ tên";
            DGV.Columns["CanNang"].HeaderText = "Cân nặng thai (kg)";
            DGV.Columns["NgayMangThai"].HeaderText = "Ngày thụ thai";
            DGV.Columns["NgayKham"].HeaderText = "Ngày khám";
            DGV.Columns["NgayTaiKham"].HeaderText = "Ngày tái khám";
        }

        private void buttonPhongKham_Click(object sender, EventArgs e)
        {
            buttonThanhVienGiaDinh.BackColor = Color.Transparent;
            buttonTiemChung.BackColor = Color.Transparent;
            buttonDinhDuong.BackColor = Color.Transparent;
            buttonThaiKy.BackColor = Color.Transparent;
            buttonPhongKham.BackColor = Color.White;

            DGV.DataSource = null;
            db = new dbTYTDataContext();
            DGV.DataSource = from a in db.PhongKhams
                             select new
                             {
                                 a.TenPhongKham,
                                 a.NoiDung,
                                 a.MaThanhVien
                             };
            DGV.Columns["TenPhongKham"].HeaderText = "Tên phòng khám";
            DGV.Columns["NoiDung"].HeaderText = "Mô tả";
            DGV.Columns["MaThanhVien"].HeaderText = "Mã trưởng phòng khám";
        }

        private void pictureBoxThongBaoMoi_Click(object sender, EventArgs e)
        {
            ThongBaoHome f = new ThongBaoHome();
            f.maho = mh;
            f.Show();
            pictureBoxThongBaoMoi.Visible = false;
        }

        private void pictureBoxThongBao_Click(object sender, EventArgs e)
        {
            ThongBaoHome f = new ThongBaoHome();
            f.maho = mh;
            f.Show();
        }

        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DGV.Columns[e.ColumnIndex].Name == "MaThanhVien")
            {
                string maThanhVien = DGV.Rows[e.RowIndex].Cells["MaThanhVien"].Value.ToString();
                ThongTinTruongPhongKham f = new ThongTinTruongPhongKham();
                f.mtv = maThanhVien;
                f.Show();
            }
        }
    }
}
