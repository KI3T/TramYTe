using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TramYTe.AdminMain.QuanLyHoGiaDinh_Child;
using TramYTe.Database;

namespace TramYTe.AdminMain
{
    public partial class QuanLyHoGiaDinh : Form
    {
        public QuanLyHoGiaDinh()
        {
            InitializeComponent();
        }

        private dbTYTDataContext db;
        private DataGridViewRow r;

        private void Show()
        {
            db = new dbTYTDataContext();
            var thanhvien = from b in db.ThanhViens
                            where comboBoxHoGiaDinh.Text == b.MaHo
                            select b;
            DGV.DataSource = thanhvien.ToList();
        }

        private void QuanLyHoGiaDinh_Load(object sender, EventArgs e)
        {
            db = new dbTYTDataContext();
            var kp = from s in db.KhuPhos
                          select s.TenKhuPho;

            comboBoxKhuPho.DataSource = kp.ToList();

            Show();
            DGV.Columns["MaThanhVien"].HeaderText = "Mã thành viên";
            DGV.Columns["HoTen"].HeaderText = "Họ tên";
            DGV.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            DGV.Columns["GioiTinh"].HeaderText = "Giới tính";
            DGV.Columns["DienThoai"].HeaderText = "Số điện thoại";
            DGV.Columns["CCCD"].HeaderText = "Căn cước công dân";
            DGV.Columns["LichSuBenhAn"].HeaderText = "Lịch sử bệnh án";
            DGV.Columns["HoGiaDinh"].HeaderText = "HoGiaDinh";
            DGV.Columns["HoGiaDinh"].Visible = false;
            panelThongTin.Visible = false;
        }

        private void comboBoxKhuPho_SelectedIndexChanged(object sender, EventArgs e)
        {
            db = new dbTYTDataContext();
            string selectedKhuPho = comboBoxKhuPho.SelectedItem.ToString();

            var hgd = from s in db.HoGiaDinhs
                             where s.KhuPho.TenKhuPho == selectedKhuPho
                             select s.MaHo;

            comboBoxHoGiaDinh.DataSource = hgd.ToList();
            Show();
        }

        private void comboBoxHoGiaDinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            db = new dbTYTDataContext();
            string selectedMaHo = comboBoxHoGiaDinh.SelectedItem.ToString();

            var tk = from s in db.TaiKhoanDangNhaps
                     where s.MaHo == selectedMaHo
                     select s.TaiKhoan;

            string taikhoan = tk.FirstOrDefault();
            textBoxTaiKhoan.Text = taikhoan;
            if (taikhoan == null)
            {
                MessageBox.Show("Lưu ý: hộ gia đình này chưa có tài khoản");
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

        private void buttonThemThanhVien_Click(object sender, EventArgs e)
        {
            panelThongTin.Visible = true;
        }

        private void buttonXacNhan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxMaThanhVien.Text))
            {
                MessageBox.Show("Mã thành viên không thể trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxMaThanhVien.Select();
                return;
            }
            else if (string.IsNullOrEmpty(textBoxHoTen.Text))
            {
                MessageBox.Show("Họ tên không thể trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxHoTen.Select();
                return;
            }
            else if (string.IsNullOrEmpty(textBoxGioiTinh.Text))
            {
                MessageBox.Show("Giới tính không thể trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxGioiTinh.Select();
                return;
            }
            else
            {
                var s = db.PhongKhams.Where(p => p.MaPhongKham == textBoxMaThanhVien.Text).Count();
                if (s > 0)
                {
                    MessageBox.Show("Mã thành viên đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxMaThanhVien.Select();
                    return;
                }
            }

            ThanhVien tv = new ThanhVien();
            tv.MaThanhVien = textBoxMaThanhVien.Text;
            tv.HoTen = textBoxHoTen.Text;
            tv.NgaySinh = dateTimePickerNgaySinh.Value;
            tv.GioiTinh = textBoxGioiTinh.Text;
            tv.DienThoai = textBoxDienThoai.Text;
            tv.CCCD = textBoxCCCD.Text;
            tv.MaHo = comboBoxHoGiaDinh.Text;
            tv.LichSuBenhAn = textBoxLichSuBenhAn.Text;
            db.ThanhViens.InsertOnSubmit(tv);
            db.SubmitChanges();
            MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Show();
            textBoxMaThanhVien.Text = textBoxHoTen.Text = textBoxGioiTinh.Text
                = textBoxDienThoai.Text = textBoxCCCD.Text = textBoxLichSuBenhAn.Text = null;
            panelThongTin.Visible = false;
        }

        private void buttonLamMoi_Click(object sender, EventArgs e)
        {
            textBoxMaThanhVien.Text = textBoxHoTen.Text = textBoxGioiTinh.Text
                = textBoxDienThoai.Text = textBoxCCCD.Text = textBoxLichSuBenhAn.Text = null;
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn Thành viên muốn sửa hoặc chọn một ô khác và thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                db = new dbTYTDataContext();
                var s = db.ThanhViens.SingleOrDefault(p => p.MaThanhVien == DGV.SelectedCells[0].OwningRow.Cells["MaThanhVien"].Value.ToString());
                string MaThanhVien1 = DGV.SelectedCells[0].OwningRow.Cells["MaThanhVien"].Value.ToString();
                string HoTen1 = DGV.SelectedCells[0].OwningRow.Cells["HoTen"].Value.ToString();
                DateTime? NgaySinh1 = DGV.SelectedCells[0].OwningRow.Cells["NgaySinh"].Value == null ?
                    null : (DateTime?)DGV.SelectedCells[0].OwningRow.Cells["NgaySinh"].Value;
                string GioiTinh1 = DGV.SelectedCells[0].OwningRow.Cells["GioiTinh"].Value.ToString();
                string DienThoai1 = DGV.SelectedCells[0].OwningRow.Cells["DienThoai"].Value == null ?
                    null : DGV.SelectedCells[0].OwningRow.Cells["DienThoai"].Value.ToString(); //Kiểm tra dữ liệu trên DGV có null không, nếu có gán null, không gán giá trị nhập
                string CCCD1 = DGV.SelectedCells[0].OwningRow.Cells["CCCD"].Value == null ?
                    null : DGV.SelectedCells[0].OwningRow.Cells["CCCD"].Value.ToString();
                string MaHo1 = DGV.SelectedCells[0].OwningRow.Cells["MaHo"].Value.ToString();
                string LichSuBenhAn1 = DGV.SelectedCells[0].OwningRow.Cells["LichSuBenhAn"].Value == null ?
                    null : DGV.SelectedCells[0].OwningRow.Cells["LichSuBenhAn"].Value.ToString();
                if (s == null)
                {
                    MessageBox.Show("Xin vui lòng không sửa Mã thành viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Show();
                    return;
                }
                s.MaThanhVien = MaThanhVien1;
                s.HoTen = HoTen1;
                s.NgaySinh = NgaySinh1;
                s.GioiTinh = GioiTinh1;
                s.DienThoai = DienThoai1;
                s.CCCD = CCCD1;
                s.MaHo = MaHo1;
                s.LichSuBenhAn = LichSuBenhAn1;
                db.SubmitChanges();
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Show();
                r = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Phải chọn Thàng viên để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
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
                var s = db.ThanhViens.SingleOrDefault(p => p.MaThanhVien == DGV.SelectedCells[0].OwningRow.Cells["MaThanhVien"].Value.ToString());
                db.ThanhViens.DeleteOnSubmit(s);
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
            var searchResults = from p in db.ThanhViens
                                where p.MaHo == comboBoxHoGiaDinh.Text
                                where p.MaThanhVien.Contains(textBoxTimKiem.Text)
                                || p.HoTen.Contains(textBoxTimKiem.Text)
                                || p.NgaySinh.ToString().Contains(textBoxTimKiem.Text)
                                || p.GioiTinh.Contains(textBoxTimKiem.Text)
                                || p.DienThoai.Contains(textBoxTimKiem.Text)
                                || p.CCCD.Contains(textBoxTimKiem.Text)
                                select p;
            DGV.DataSource = searchResults.ToList();
        }

        private void buttonXemDanhSach_Click(object sender, EventArgs e)
        {
            Show();
        }

        private void buttonTuyChinhKhuPho_Click(object sender, EventArgs e)
        {
            TuyChinhKhuPho f = new TuyChinhKhuPho();
            f.Show();
        }

        private void buttonTuyChinhHoGiaDinh_Click(object sender, EventArgs e)
        {
            TuyChinhHoGiaDinh f = new TuyChinhHoGiaDinh();
            f.Show();
        }

        private void buttonTuyChinhTaiKhoan_Click(object sender, EventArgs e)
        {
            TuyChinhTaiKhoan f = new TuyChinhTaiKhoan();
            f.Show();
        }
    }
}
