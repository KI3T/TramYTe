using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TramYTe.Database;

namespace TramYTe.AdminMain
{
    public partial class QuanLyTiemChung : Form
    {
        public QuanLyTiemChung()
        {
            InitializeComponent();
        }

        private dbTYTDataContext db;
        private DataGridViewRow r;
        private void Show()
        {
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
                                 a.TrangThai
                             };
        }
        private void QuanLyTiemChung_Load(object sender, EventArgs e)
        {
            db = new dbTYTDataContext();
            var mh = from s in db.HoGiaDinhs
                     select s.MaHo;

            comboBoxMaHo.DataSource = mh.ToList();

            var tvc = from s in db.Vaccines
                      where Convert.ToDateTime(s.NgaySanXuat).AddDays((double)s.HanSuDung) > DateTime.Now
                      select s.TenVaccine;

            comboBoxTenVaccine.DataSource = tvc.ToList();

            Show();
            DGV.Columns["MaPhieuTiemChung"].HeaderText = "Mã phiếu tiêm chủng";
            DGV.Columns["MaThanhVien"].HeaderText = "Mã thành viên";
            DGV.Columns["HoTen"].HeaderText = "Tên bệnh nhân";
            DGV.Columns["MaVaccine"].HeaderText = "Mã Vaccine";
            DGV.Columns["TenVaccine"].HeaderText = "Tên Vaccine";
            DGV.Columns["SoLuong"].HeaderText = "Số lượng";
            DGV.Columns["TrieuChungSauTiem"].HeaderText = "Triệu chứng sau tiêm";
            DGV.Columns["NgayTiem"].HeaderText = "Ngày tiêm";
            DGV.Columns["NgayTiemTiepTheo"].HeaderText = "Ngày tiêm tiếp theo";
            DGV.Columns["TrangThai"].HeaderText = "Trạng thái";
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

        private void comboBoxTenVaccine_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tenvaccine = comboBoxTenVaccine.SelectedItem.ToString();
            var mvc = (from s in db.Vaccines
                       where s.TenVaccine == tenvaccine
                       select s).FirstOrDefault();
            if (mvc != null)
            {
                textBoxMaVaccine.Text = mvc.MaVaccine;
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
            if (string.IsNullOrEmpty(textBoxMaPhieuTiemChung.Text))
            {
                MessageBox.Show("Mã phiếu tiêm chủng không thể trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxMaPhieuTiemChung.Select();
                return;
            }
            else if (string.IsNullOrEmpty(textBoxSoLuong.Text))
            {
                MessageBox.Show("Số lượng không thể trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxSoLuong.Select();
                return;
            }
            else
            {
                var s = db.TiemChungs.Where(p => p.MaPhieuTiemChung == textBoxMaPhieuTiemChung.Text).Count();
                if (s > 0)
                {
                    MessageBox.Show("Mã phiếu tiêm chủng đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxMaPhieuTiemChung.Select();
                    return;
                }
            }

            TiemChung tc = new TiemChung();
            tc.MaPhieuTiemChung = textBoxMaPhieuTiemChung.Text;
            tc.MaVaccine = textBoxMaVaccine.Text;
            tc.SoLuong = Convert.ToInt32(textBoxSoLuong.Text);
            tc.NgayTiem = DateTime.Now;
            tc.TrieuChungSauTiem = textBoxTrieuChungSauTiem.Text;
            tc.MaThanhVien = textBoxMaBenhNhan.Text;
            if (comboBoxTrangThai.Text == "Hoàn thành")
            {
                tc.TrangThai = true;
            }
            else
            {
                tc.TrangThai = false;
            }
            db.TiemChungs.InsertOnSubmit(tc);
            db.SubmitChanges();
            MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Show();

            Vaccine vc = new Vaccine();
            vc.SoLuong -= Convert.ToInt32(textBoxSoLuong.Value);
            db.Vaccines.InsertOnSubmit(vc);
            db.SubmitChanges();

            textBoxMaPhieuTiemChung.Text = textBoxSoLuong.Text = textBoxTrieuChungSauTiem.Text = null;
            panelThongTin.Visible = false;
        }

        private void buttonLamMoi_Click(object sender, EventArgs e)
        {
            textBoxMaPhieuTiemChung.Text = textBoxSoLuong.Text = textBoxTrieuChungSauTiem.Text = null;
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn Phiếu tiêm chủng muốn xóa hoặc thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var s = db.TiemChungs.SingleOrDefault(p => p.MaPhieuTiemChung == DGV.SelectedCells[0].OwningRow.Cells["MaPhieuTiemChung"].Value.ToString());
                db.TiemChungs.DeleteOnSubmit(s);
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
            var searchResults = from a in db.TiemChungs
                                from b in db.ThanhViens
                                from c in db.Vaccines
                                where a.MaThanhVien == b.MaThanhVien
                                where a.MaPhieuTiemChung.Contains(textBoxTimKiem.Text)
                                || a.MaThanhVien.Contains(textBoxTimKiem.Text)
                                || b.HoTen.Contains(textBoxTimKiem.Text)
                                || a.MaVaccine.Contains(textBoxTimKiem.Text)
                                || a.SoLuong.ToString().Contains(textBoxTimKiem.Text)
                                || a.TrieuChungSauTiem.Contains(textBoxTimKiem.Text)
                                || a.NgayTiem.ToString().Contains(textBoxTimKiem.Text)
                                select new
                                {
                                    a.MaPhieuTiemChung,
                                    a.MaThanhVien,
                                    b.HoTen,
                                    a.MaVaccine,
                                    a.SoLuong,
                                    a.TrieuChungSauTiem,
                                    a.NgayTiem
                                };
            DGV.DataSource = searchResults.ToList();
        }

        private void buttonXemDanhSach_Click(object sender, EventArgs e)
        {
            Show();
        }

        private void buttonLichTiemChung_Click(object sender, EventArgs e)
        {
            QuanLyLichTiemChung f = new QuanLyLichTiemChung();
            f.ShowDialog();
        }
    }
}
