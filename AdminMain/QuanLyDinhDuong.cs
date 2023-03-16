using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TramYTe.Database;

namespace TramYTe.AdminMain
{
    public partial class QuanLyDinhDuong : Form
    {
        public QuanLyDinhDuong()
        {
            InitializeComponent();
        }

        private dbTYTDataContext db;
        private DataGridViewRow r;
        private void Show()
        {
            db = new dbTYTDataContext();
            DGV.DataSource = from a in db.DinhDuongs
                             from b in db.ThanhViens
                             where a.MaThanhVien == b.MaThanhVien
                             let thangTuoi = SqlMethods.DateDiffMonth(b.NgaySinh, DateTime.Now)
                             let bmi = Convert.ToDouble(a.CanNang / ((a.ChieuCao / 100) * (a.ChieuCao / 100)))
                             let tinhTrang = bmi < 16 ? "Gầy độ III" :
                                             bmi < 17 ? "Gầy độ II" :
                                             bmi < 18.5 ? "Gầy độ I" :
                                             bmi < 25 ? "Bình thường" :
                                             bmi < 30 ? "Thừa cân" :
                                             bmi < 35 ? "Béo phì độ I" :
                                             bmi < 40 ? "Béo phì độ II" :
                                             "Béo phì độ III"
                             select new
                             {
                                 a.MaPhieuDinhDuong,
                                 b.MaHo,
                                 a.MaThanhVien,
                                 b.HoTen,
                                 b.NgaySinh,
                                 b.GioiTinh,
                                 a.ChieuCao,
                                 a.CanNang,
                                 BMI = Math.Round(bmi, 1, MidpointRounding.AwayFromZero),
                                 TinhTrang = tinhTrang,
                                 a.NgayKham
                             };
        }
        private void QuanLyDinhDuong_Load(object sender, EventArgs e)
        {
            db = new dbTYTDataContext();
            var mh = from s in db.HoGiaDinhs
                     select s.MaHo;

            comboBoxMaHo.DataSource = mh.ToList();

            Show();
            DGV.Columns["MaPhieuDinhDuong"].HeaderText = "Mã phiếu dinh dưỡng";
            DGV.Columns["MaHo"].HeaderText = "Mã hộ";
            DGV.Columns["MaThanhVien"].HeaderText = "Mã thành viên";
            DGV.Columns["HoTen"].HeaderText = "Họ tên";
            DGV.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            DGV.Columns["GioiTinh"].HeaderText = "Giới tính";
            DGV.Columns["ChieuCao"].HeaderText = "Chiều cao (cm)";
            DGV.Columns["CanNang"].HeaderText = "Cân nặng (kg)";
            DGV.Columns["BMI"].HeaderText = "BMI";
            DGV.Columns["TinhTrang"].HeaderText = "Tình trạng";
            DGV.Columns["NgayKham"].HeaderText = "Ngày khám";
            panelThongTin.Visible = false;
        }

        private void comboBoxMaHo_SelectedIndexChanged(object sender, EventArgs e)
        {
            db = new dbTYTDataContext();
            string selectedMaHo = comboBoxMaHo.SelectedItem.ToString();

            var ttv = from s in db.ThanhViens
                      where s.MaHo == selectedMaHo
                      select s.HoTen;

            comboBoxTenBenhNhan.DataSource = ttv.ToList();
            Show();
        }

        private void comboBoxTenBenhNhan_SelectedIndexChanged(object sender, EventArgs e)
        {

            string tenthanhvien = comboBoxTenBenhNhan.SelectedItem.ToString();
            var mtv = (from s in db.ThanhViens
                      where s.HoTen == tenthanhvien
                      select s).FirstOrDefault();
            if (mtv != null)
            {
                textBoxMaBenhNhan.Text = mtv.MaThanhVien;
            }
            Show();
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
            if (string.IsNullOrEmpty(textBoxMaPhieuDinhDuong.Text))
            {
                MessageBox.Show("Mã phiếu dinh dưỡng không thể trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxMaPhieuDinhDuong.Select();
                return;
            }
            else if (string.IsNullOrEmpty(textBoxChieuCao.Text))
            {
                MessageBox.Show("Chiều cao không thể trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxChieuCao.Select();
                return;
            }
            else if (string.IsNullOrEmpty(textBoxCanNang.Text))
            {
                MessageBox.Show("Cân nặng không thể trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxCanNang.Select();
                return;
            }
            else
            {
                var s = db.DinhDuongs.Where(p => p.MaPhieuDinhDuong == textBoxMaPhieuDinhDuong.Text).Count();
                if (s > 0)
                {
                    MessageBox.Show("Mã phiếu dinh dưỡng đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxMaPhieuDinhDuong.Select();
                    return;
                }
            }

            DinhDuong dd = new DinhDuong();
            dd.MaPhieuDinhDuong = textBoxMaPhieuDinhDuong.Text;
            dd.ChieuCao = float.Parse(textBoxChieuCao.Text);
            dd.CanNang = float.Parse(textBoxCanNang.Text);
            dd.NgayKham = DateTime.Now;
            dd.MaThanhVien = textBoxMaBenhNhan.Text;
            db.DinhDuongs.InsertOnSubmit(dd);
            db.SubmitChanges();
            MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Show();
            textBoxMaPhieuDinhDuong.Text = textBoxChieuCao.Text = textBoxCanNang.Text = null;
            panelThongTin.Visible = false;
        }

        private void buttonLamMoi_Click(object sender, EventArgs e)
        {
            textBoxMaPhieuDinhDuong.Text = textBoxChieuCao.Text = textBoxCanNang.Text = null;
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn Thành viên muốn xóa hoặc thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var s = db.DinhDuongs.SingleOrDefault(p => p.MaPhieuDinhDuong == DGV.SelectedCells[0].OwningRow.Cells["MaPhieuDinhDuong"].Value.ToString());
                db.DinhDuongs.DeleteOnSubmit(s);
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
            var searchResults = from a in db.DinhDuongs
                                from b in db.ThanhViens
                                where a.MaThanhVien == b.MaThanhVien
                                where a.MaPhieuDinhDuong.Contains(textBoxTimKiem.Text)
                                || b.MaHo.Contains(textBoxTimKiem.Text)
                                || a.MaThanhVien.Contains(textBoxTimKiem.Text)
                                || b.HoTen.Contains(textBoxTimKiem.Text)
                                || b.NgaySinh.ToString().Contains(textBoxTimKiem.Text)
                                || b.GioiTinh.Contains(textBoxTimKiem.Text)
                                || a.ChieuCao.ToString().Contains(textBoxTimKiem.Text)
                                || a.CanNang.ToString().Contains(textBoxTimKiem.Text)
                                || a.NgayKham.ToString().Contains(textBoxTimKiem.Text)
                                let bmi = Convert.ToDouble(a.CanNang / ((a.ChieuCao / 100) * (a.ChieuCao / 100)))
                                select new
                                {
                                    a.MaPhieuDinhDuong,
                                    b.MaHo,
                                    a.MaThanhVien,
                                    b.HoTen,
                                    b.NgaySinh,
                                    b.GioiTinh,
                                    a.ChieuCao,
                                    a.CanNang,
                                    BMI = Math.Round(bmi, 1, MidpointRounding.AwayFromZero),
                                    TinhTrang = bmi < 16 ? "Gầy độ III" :
                                             bmi < 17 ? "Gầy độ II" :
                                             bmi < 18.5 ? "Gầy độ I" :
                                             bmi < 25 ? "Bình thường" :
                                             bmi < 30 ? "Thừa cân" :
                                             bmi < 35 ? "Béo phì độ I" :
                                             bmi < 40 ? "Béo phì độ II" :
                                             "Béo phì độ III",
                                    a.NgayKham
                                };
            DGV.DataSource = searchResults.ToList();
        }

        private void buttonXemDanhSach_Click(object sender, EventArgs e)
        {
            Show();
        }
    }
}
