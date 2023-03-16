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

namespace TramYTe.AdminMain
{
    public partial class QuanLyKhamThai : Form
    {
        public QuanLyKhamThai()
        {
            InitializeComponent();
        }

        private dbTYTDataContext db;
        private DataGridViewRow r;
        private void Show()
        {
            db = new dbTYTDataContext();
            DGV.DataSource = from a in db.ThaiKies
                             from b in db.ThanhViens
                             where a.MaThanhVien == b.MaThanhVien
                             select new
                             {
                                 a.MaPhieuKhamThai,
                                 a.MaThanhVien,
                                 b.HoTen,
                                 a.NgayMangThai,
                                 a.CanNang,
                                 a.NgayKham,
                                 a.NgayTaiKham
                             };
        }

        private void QuanLyKhamThai_Load(object sender, EventArgs e)
        {
            db = new dbTYTDataContext();
            var mh = from s in db.HoGiaDinhs
                     select s.MaHo;

            comboBoxMaHo.DataSource = mh.ToList();

            Show();
            DGV.Columns["MaPhieuKhamThai"].HeaderText = "Mã phiếu khám thai";
            DGV.Columns["MaThanhVien"].HeaderText = "Mã bệnh nhân";
            DGV.Columns["HoTen"].HeaderText = "Tên bệnh nhân";
            DGV.Columns["NgayMangThai"].HeaderText = "Ngày thụ thai";
            DGV.Columns["CanNang"].HeaderText = "Cân nặng thai (kg)";
            DGV.Columns["NgayKham"].HeaderText = "Ngày khám";
            DGV.Columns["NgayTaiKham"].HeaderText = "Ngày tái khám";
            panelThongTin.Visible = false;
        }

        private void comboBoxMaHo_SelectedIndexChanged(object sender, EventArgs e)
        {
            db = new dbTYTDataContext();
            string selectedMaHo = comboBoxMaHo.SelectedItem.ToString();

            var ttv = from s in db.ThanhViens
                      where s.MaHo == selectedMaHo
                      where s.GioiTinh == "Nữ"
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
            if (string.IsNullOrEmpty(textBoxMaPhieuKhamThai.Text))
            {
                MessageBox.Show("Mã phiếu khám thai không thể trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxMaPhieuKhamThai.Select();
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
                var s = db.ThaiKies.Where(p => p.MaPhieuKhamThai == textBoxMaPhieuKhamThai.Text).Count();
                if (s > 0)
                {
                    MessageBox.Show("Mã phiếu khám thai đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxMaPhieuKhamThai.Select();
                    return;
                }
            }

            ThaiKy thai = new ThaiKy();
            thai.MaPhieuKhamThai = textBoxMaPhieuKhamThai.Text;
            thai.CanNang = double.Parse(textBoxCanNang.Text);
            thai.NgayMangThai = dateTimePickerNgayThuThai.Value;
            thai.NgayKham = DateTime.Now;
            thai.MaThanhVien = textBoxMaBenhNhan.Text;
            thai.NgayTaiKham = checkBoxTaiKham.Checked ? dateTimePickerNgayTaiKham.Value : (DateTime?)null;
            db.ThaiKies.InsertOnSubmit(thai);
            db.SubmitChanges();
            MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Show();
            textBoxMaPhieuKhamThai.Text = textBoxCanNang.Text = null;
            panelThongTin.Visible = false;
        }

        private void buttonLamMoi_Click(object sender, EventArgs e)
        {
            textBoxMaPhieuKhamThai.Text = textBoxCanNang.Text = null;
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn Phiếu khám thai muốn xóa hoặc thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var s = db.ThaiKies.SingleOrDefault(p => p.MaPhieuKhamThai == DGV.SelectedCells[0].OwningRow.Cells["MaPhieuKhamThai"].Value.ToString());
                db.ThaiKies.DeleteOnSubmit(s);
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
            var searchResults = from a in db.ThaiKies
                                from b in db.ThanhViens
                                where a.MaThanhVien == b.MaThanhVien
                                where a.MaPhieuKhamThai.Contains(textBoxTimKiem.Text)                             
                                || a.MaThanhVien.Contains(textBoxTimKiem.Text)
                                || b.HoTen.Contains(textBoxTimKiem.Text)
                                || a.NgayMangThai.ToString().Contains(textBoxTimKiem.Text)
                                || a.CanNang.ToString().Contains(textBoxTimKiem.Text)
                                || a.NgayKham.ToString().Contains(textBoxTimKiem.Text)
                                select new
                                {
                                    a.MaPhieuKhamThai,
                                    a.MaThanhVien,
                                    b.HoTen,
                                    a.NgayMangThai,
                                    a.CanNang,
                                    a.NgayKham
                                };
            DGV.DataSource = searchResults.ToList();
        }

        private void buttonXemDanhSach_Click(object sender, EventArgs e)
        {
            Show();
        }

        private void checkBoxTaiKham_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTaiKham.Checked)
            {
                labelNgayTaiKham.Visible = true;
                dateTimePickerNgayTaiKham.Visible = true;
            }
            else
            {
                labelNgayTaiKham.Visible = false;
                dateTimePickerNgayTaiKham.Visible = false;
            }
        }
    }
}
