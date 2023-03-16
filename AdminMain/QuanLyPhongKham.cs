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
    public partial class QuanLyPhongKham : Form
    {
        public QuanLyPhongKham()
        {
            InitializeComponent();
        }

        private dbTYTDataContext db;
        private DataGridViewRow r;
        private void Show()
        {
            db = new dbTYTDataContext();
            DGV.DataSource = db.PhongKhams.Select(c => c);
        }

        private void QuanLyPhongKham_Load(object sender, EventArgs e)
        {
            db = new dbTYTDataContext();
            var mh = from s in db.HoGiaDinhs
                     select s.MaHo;

            comboBoxMaHo.DataSource = mh.ToList();

            Show();
            DGV.Columns["MaPhongKham"].HeaderText = "Mã phòng khám";
            DGV.Columns["TenPhongKham"].HeaderText = "Tên phòng khám";
            DGV.Columns["NoiDung"].HeaderText = "Mô tả";
            DGV.Columns["MaThanhVien"].HeaderText = "Mã trưởng phòng khám";
            DGV.Columns["ThanhVien"].HeaderText = "ThanhVien";
            DGV.Columns["ThanhVien"].Visible = false;
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
            if (string.IsNullOrEmpty(textBoxMaPhongKham.Text))
            {
                MessageBox.Show("Mã phòng khám không thể trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxMaPhongKham.Select();
                return;
            }
            else if (string.IsNullOrEmpty(textBoxTenPhongKham.Text))
            {
                MessageBox.Show("Tên phòng khám không thể trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxTenPhongKham.Select();
                return;
            }
            else if (string.IsNullOrEmpty(textBoxMoTa.Text))
            {
                MessageBox.Show("Mô tả không thể trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxMoTa.Select();
                return;
            }
            else
            {
                var s = db.PhongKhams.Where(p => p.MaPhongKham == textBoxMaPhongKham.Text).Count();
                if (s > 0)
                {
                    MessageBox.Show("Mã phòng khám đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxMaPhongKham.Select();
                    return;
                }
            }

            PhongKham pk = new PhongKham();
            pk.MaPhongKham = textBoxMaPhongKham.Text;
            pk.TenPhongKham = textBoxTenPhongKham.Text;
            pk.NoiDung = textBoxMoTa.Text;
            pk.MaThanhVien = textBoxMaTruongPhongKham.Text;
            db.PhongKhams.InsertOnSubmit(pk);
            db.SubmitChanges();
            MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Show();
            textBoxMaPhongKham.Text = textBoxTenPhongKham.Text = textBoxMoTa.Text = null;
            panelThongTin.Visible = false;
        }

        private void buttonLamMoi_Click(object sender, EventArgs e)
        {
            textBoxMaPhongKham.Text = textBoxTenPhongKham.Text = textBoxMoTa.Text = null;
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn Phòng khám muốn sửa hoặc thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                db = new dbTYTDataContext();
                var s = db.PhongKhams.SingleOrDefault(p => p.MaPhongKham == DGV.SelectedCells[0].OwningRow.Cells["MaPhongKham"].Value.ToString());
                string MaPhongKham1 = DGV.SelectedCells[0].OwningRow.Cells["MaPhongKham"].Value.ToString();
                string TenPhongKham1 = DGV.SelectedCells[0].OwningRow.Cells["TenPhongKham"].Value.ToString();
                string NoiDung1 = DGV.SelectedCells[0].OwningRow.Cells["NoiDung"].Value.ToString();
                string MaThanhVien1 = DGV.SelectedCells[0].OwningRow.Cells["MaThanhVien"].Value.ToString();
                if (s == null)
                {
                    MessageBox.Show("Xin vui lòng không sửa Mã phòng khám!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Show();
                    return;
                }
                s.MaPhongKham = MaPhongKham1;
                s.TenPhongKham = TenPhongKham1;
                s.NoiDung = NoiDung1;
                s.MaThanhVien = MaThanhVien1;
                db.SubmitChanges();
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Show();
                r = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Phải chọn Phòng khám để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn Phòng khám muốn xóa hoặc thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var s = db.PhongKhams.SingleOrDefault(p => p.MaPhongKham == DGV.SelectedCells[0].OwningRow.Cells["MaPhongKham"].Value.ToString());
                db.PhongKhams.DeleteOnSubmit(s);
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
            var searchResults = from p in db.PhongKhams
                                where p.MaPhongKham.Contains(textBoxTimKiem.Text)
                                || p.TenPhongKham.Contains(textBoxTimKiem.Text)
                                || p.NoiDung.ToString().Contains(textBoxTimKiem.Text)
                                select new
                                {
                                    p.MaPhongKham,
                                    p.TenPhongKham,
                                    p.NoiDung
                                };
            DGV.DataSource = searchResults.ToList();
        }

        private void buttonXemDanhSach_Click(object sender, EventArgs e)
        {
            Show();
        }

        private void comboBoxMaHo_SelectedIndexChanged(object sender, EventArgs e)
        {
            db = new dbTYTDataContext();
            string selectedMaHo = comboBoxMaHo.SelectedItem.ToString();

            var ttv = from s in db.ThanhViens
                      where s.MaHo == selectedMaHo
                      select s.HoTen;

            comboBoxTenTruongPhongKham.DataSource = ttv.ToList();
            Show();
        }

        private void comboBoxTenTruongPhongKham_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tenthanhvien = comboBoxTenTruongPhongKham.SelectedItem.ToString();
            var mtv = (from s in db.ThanhViens
                       where s.HoTen == tenthanhvien
                       select s).FirstOrDefault();
            if (mtv != null)
            {
                comboBoxTenTruongPhongKham.Text = mtv.MaThanhVien;
            }
            Show();
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
