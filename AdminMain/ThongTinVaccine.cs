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
    public partial class ThongTinVaccine : Form
    {
        public ThongTinVaccine()
        {
            InitializeComponent();
        }

        private dbTYTDataContext db;
        private DataGridViewRow r;
        private void Show()
        {
            db = new dbTYTDataContext();
            DGV.DataSource = db.Vaccines.Select(c => c);
        }

        private void ThongTinVaccine_Load(object sender, EventArgs e)
        {
            Show();
            DGV.Columns["MaVaccine"].HeaderText = "Mã Vaccine";
            DGV.Columns["TenVaccine"].HeaderText = "Tên Vaccine";
            DGV.Columns["MaLo"].HeaderText = "Mã lô";
            DGV.Columns["SoLuong"].HeaderText = "Số lượng hiện có";
            DGV.Columns["NhaSanXuat"].HeaderText = "Nhà sản xuất";
            DGV.Columns["SoLuongDeXuat"].HeaderText = "Số lượng đề xuất";
            DGV.Columns["NgaySanXuat"].HeaderText = "Ngày sản xuất";
            DGV.Columns["HanSuDung"].HeaderText = "Hạn sử dụng (ngày)";
            DGV.Columns["ChuKyTiem"].HeaderText = "Chu kỳ tiêm";
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
            if (string.IsNullOrEmpty(textBoxMaVaccine.Text))
            {
                MessageBox.Show("Mã Vaccine không thể trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxMaVaccine.Select();
                return;
            }
            else if (string.IsNullOrEmpty(textBoxTenVaccine.Text))
            {
                MessageBox.Show("Tên Vaccine không thể trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxTenVaccine.Select();
                return;
            }
            else if (string.IsNullOrEmpty(textBoxMaLo.Text))
            {
                MessageBox.Show("Mã lô không thể trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxMaLo.Select();
                return;
            }
            else if (string.IsNullOrEmpty(textBoxSoLuong.Text))
            {
                MessageBox.Show("Số lượng không thể trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxSoLuong.Select();
                return;
            }
            else if (string.IsNullOrEmpty(textBoxNhaSanXuat.Text))
            {
                MessageBox.Show("Nhà sản xuất không thể trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxNhaSanXuat.Select();
                return;
            }
            else if (string.IsNullOrEmpty(textBoxSoLuongDeXuat.Text))
            {
                MessageBox.Show("Số lượng đề xuất không thể trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxSoLuongDeXuat.Select();
                return;
            }
            else if (string.IsNullOrEmpty(textBoxHanSuDung.Text))
            {
                MessageBox.Show("Hạn sử dụng không thể trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxSoLuongDeXuat.Select();
                return;
            }
            else if (string.IsNullOrEmpty(textBoxChuKyTiem.Text))
            {
                MessageBox.Show("Chu kỳ tiêm không thể trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxSoLuongDeXuat.Select();
                return;
            }
            else
            {
                var s = db.Vaccines.Where(p => p.MaVaccine == textBoxMaVaccine.Text).Count();
                if (s > 0)
                {
                    MessageBox.Show("Mã Vaccine đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxMaVaccine.Select();
                    return;
                }
            }

            Vaccine vc = new Vaccine();
            vc.MaVaccine = textBoxMaVaccine.Text;
            vc.TenVaccine = textBoxTenVaccine.Text;
            vc.MaLo = textBoxMaLo.Text;
            vc.SoLuong = Convert.ToInt32(textBoxSoLuong.Text);
            vc.NhaSanXuat = textBoxNhaSanXuat.Text;
            vc.SoLuongDeXuat = Convert.ToInt32(textBoxSoLuongDeXuat.Text);
            vc.NgaySanXuat = dateTimePickerNgaySanXuat.Value;
            vc.HanSuDung = Convert.ToInt32(textBoxHanSuDung.Text);
            vc.ChuKyTiem = Convert.ToInt32(textBoxChuKyTiem.Text);
            db.Vaccines.InsertOnSubmit(vc);
            db.SubmitChanges();
            MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Show();
            textBoxMaVaccine.Text = textBoxTenVaccine.Text = textBoxMaLo.Text = textBoxSoLuong.Text
                = textBoxNhaSanXuat.Text = textBoxSoLuongDeXuat.Text = null;
            panelThongTin.Visible = false;
        }

        private void buttonLamMoi_Click(object sender, EventArgs e)
        {
            textBoxMaVaccine.Text = textBoxTenVaccine.Text = textBoxMaLo.Text = textBoxSoLuong.Text
                = textBoxNhaSanXuat.Text = textBoxSoLuongDeXuat.Text = null;
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn Vaccine muốn sửa hoặc thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                db = new dbTYTDataContext();
                var s = db.Vaccines.SingleOrDefault(p => p.MaVaccine == DGV.SelectedCells[0].OwningRow.Cells["MaVaccine"].Value.ToString());
                string MaVaccine1 = DGV.SelectedCells[0].OwningRow.Cells["MaVaccine"].Value.ToString();
                string TenVaccine1 = DGV.SelectedCells[0].OwningRow.Cells["TenVaccine"].Value.ToString();
                string MaLo1 = DGV.SelectedCells[0].OwningRow.Cells["MaLo"].Value.ToString();
                int SoLuong1 = (int)DGV.SelectedCells[0].OwningRow.Cells["SoLuong"].Value;
                string NhaSanXuat1 = DGV.SelectedCells[0].OwningRow.Cells["NhaSanXuat"].Value.ToString();
                int SoLuongDeXuat1 = (int)DGV.SelectedCells[0].OwningRow.Cells["SoLuongDeXuat"].Value;
                DateTime? NgaySanXuat1 = DGV.SelectedCells[0].OwningRow.Cells["NgaySanXuat"].Value == null ?
                    null : (DateTime?)DGV.SelectedCells[0].OwningRow.Cells["NgaySanXuat"].Value;
                int HanSuDung1 = (int)DGV.SelectedCells[0].OwningRow.Cells["HanSuDung"].Value;
                int ChuKyTiem1 = (int)DGV.SelectedCells[0].OwningRow.Cells["ChuKyTiem"].Value;
                if (s == null)
                {
                    MessageBox.Show("Xin vui lòng không sửa Mã Vaccine!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Show();
                    return;
                }
                s.MaVaccine = MaVaccine1;
                s.TenVaccine = TenVaccine1;
                s.MaLo = MaLo1;
                s.SoLuong = SoLuong1;
                s.NhaSanXuat = NhaSanXuat1;
                s.SoLuongDeXuat = SoLuongDeXuat1;
                s.NgaySanXuat = NgaySanXuat1;
                s.HanSuDung = HanSuDung1;
                s.ChuKyTiem = ChuKyTiem1;
                db.SubmitChanges();
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Show();
                r = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Phải chọn Vaccine để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn Vaccine muốn xóa hoặc thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var s = db.Vaccines.SingleOrDefault(p => p.MaVaccine == DGV.SelectedCells[0].OwningRow.Cells["MaVaccine"].Value.ToString());
                db.Vaccines.DeleteOnSubmit(s);
                db.SubmitChanges();
                MessageBox.Show("Xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Show();
                r = null;
            }
            catch (Exception)
            {
                MessageBox.Show("Vaccine này đã được sử dụng nên không thể xoá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            db = new dbTYTDataContext();
            var searchResults = from p in db.Vaccines
                                where p.MaVaccine.Contains(textBoxTimKiem.Text)
                                || p.TenVaccine.Contains(textBoxTimKiem.Text)
                                || p.MaLo.Contains(textBoxTimKiem.Text)
                                || p.SoLuong.ToString().Contains(textBoxTimKiem.Text)
                                || p.NhaSanXuat.Contains(textBoxTimKiem.Text)
                                || p.SoLuongDeXuat.ToString().Contains(textBoxTimKiem.Text)
                                || p.NgaySanXuat.ToString().Contains(textBoxTimKiem.Text)
                                || p.HanSuDung.ToString().Contains(textBoxTimKiem.Text)
                                || p.ChuKyTiem.ToString().Contains(textBoxTimKiem.Text)
                                select p;
            DGV.DataSource = searchResults.ToList();
        }

        private void buttonXemDanhSach_Click(object sender, EventArgs e)
        {
            Show();
        }
    }
}
