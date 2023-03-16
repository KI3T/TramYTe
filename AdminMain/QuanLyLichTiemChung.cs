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
    public partial class QuanLyLichTiemChung : Form
    {
        public QuanLyLichTiemChung()
        {
            InitializeComponent();
        }

        private dbTYTDataContext db;
        private DataGridViewRow r;
        private void Show()
        {
            db = new dbTYTDataContext();
            DGV.DataSource = from a in db.LichTiemVaccines
                             select a;
        }

        private void QuanLyLichTiemChung_Load(object sender, EventArgs e)
        {
            Show();
            DGV.Columns["MaLichTiem"].HeaderText = "Mã lịch tiêm";
            DGV.Columns["NgayTiem"].HeaderText = "Ngày tiêm";
            DGV.Columns["NoiDung"].HeaderText = "Nội dung";
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
            if (string.IsNullOrEmpty(textBoxNoiDung.Text))
            {
                MessageBox.Show("Nội dung không thể trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxNoiDung.Select();
                return;
            }

            LichTiemVaccine ltvc = new LichTiemVaccine();
            ltvc.NgayTiem = dateTimePickerNgayTiem.Value;
            ltvc.NoiDung = textBoxNoiDung.Text;
            db.LichTiemVaccines.InsertOnSubmit(ltvc);
            db.SubmitChanges();
            MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Show();
            textBoxNoiDung.Text = null;
            panelThongTin.Visible = false;
        }

        private void buttonLamMoi_Click(object sender, EventArgs e)
        {
            textBoxNoiDung.Text = null;
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
                var maLichTiem = Convert.ToInt32(DGV.SelectedCells[0].OwningRow.Cells["MaLichTiem"].Value);
                var s = db.LichTiemVaccines.SingleOrDefault(p => p.MaLichTiem == maLichTiem);
                int MaLichTiem1 = Convert.ToInt32(DGV.SelectedCells[0].OwningRow.Cells["MaLichTiem"].Value);
                DateTime? NgayTiem1 = DGV.SelectedCells[0].OwningRow.Cells["NgayTiem"].Value == null ?
                null : (DateTime?)DGV.SelectedCells[0].OwningRow.Cells["NgayTiem"].Value;
                string NoiDung1 = DGV.SelectedCells[0].OwningRow.Cells["NoiDung"].Value.ToString();
                if (s == null)
                {
                    MessageBox.Show("Xin vui lòng không sửa Mã tiêm chủng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Show();
                    return;
                }
                s.MaLichTiem = MaLichTiem1;
                s.NgayTiem = NgayTiem1;
                s.NoiDung = NoiDung1;
                db.SubmitChanges();
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Show();
                r = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Phải chọn Lịch tiêm chủng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn Lịch tiêm chủng muốn xóa hoặc thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var maLichTiem = Convert.ToInt32(DGV.SelectedCells[0].OwningRow.Cells["MaLichTiem"].Value);
                var s = db.LichTiemVaccines.SingleOrDefault(p => p.MaLichTiem == maLichTiem);
                db.LichTiemVaccines.DeleteOnSubmit(s);
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
            var searchResults = from a in db.LichTiemVaccines
                                where a.MaLichTiem.ToString().Contains(textBoxTimKiem.Text)
                                || a.NgayTiem.ToString().Contains(textBoxTimKiem.Text)
                                || a.NoiDung.Contains(textBoxTimKiem.Text)
                                select a;
            DGV.DataSource = searchResults.ToList();
        }

        private void buttonXemDanhSach_Click(object sender, EventArgs e)
        {
            Show();
        }
    }
}
