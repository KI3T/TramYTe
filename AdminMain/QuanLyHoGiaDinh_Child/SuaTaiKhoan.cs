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
    public partial class SuaTaiKhoan : Form
    {
        public SuaTaiKhoan()
        {
            InitializeComponent();
        }

        private dbTYTDataContext db;
        private DataGridViewRow r;
        private void Show()
        {
            db = new dbTYTDataContext();
            DGV.DataSource = db.TaiKhoanDangNhaps.Select(c => c);
        }

        private void SuaTaiKhoan_Load(object sender, EventArgs e)
        {
            Show();
            DGV.Columns["TaiKhoan"].HeaderText = "Tài khoản";
            DGV.Columns["MatKhau"].HeaderText = "Mật khẩu";
            DGV.Columns["MaHo"].HeaderText = "Mã hộ";
            DGV.Columns["Quyen"].HeaderText = "Quyền";
            DGV.Columns["HoGiaDinh"].HeaderText = "HoGiaDinh";
            DGV.Columns["HoGiaDinh"].Visible = false;
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                r = DGV.Rows[e.RowIndex];
            }
        }

        private void buttonXacNhan_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn Tài khoản muốn sửa hoặc thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                db = new dbTYTDataContext();
                var s = db.TaiKhoanDangNhaps.SingleOrDefault(p => p.TaiKhoan == DGV.SelectedCells[0].OwningRow.Cells["TaiKhoan"].Value.ToString());
                string TaiKhoan1 = DGV.SelectedCells[0].OwningRow.Cells["TaiKhoan"].Value.ToString();
                string MatKhau1 = DGV.SelectedCells[0].OwningRow.Cells["MatKhau"].Value.ToString();
                string MaHo1 = DGV.SelectedCells[0].OwningRow.Cells["MaHo"].Value.ToString();
                string Quyen1 = DGV.SelectedCells[0].OwningRow.Cells["Quyen"].Value.ToString();
                if (s == null)
                {
                    MessageBox.Show("Xin vui lòng không sửa Tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Show();
                    return;
                }
                s.TaiKhoan = TaiKhoan1;
                s.MatKhau = MatKhau1;
                s.MaHo = MaHo1;
                s.Quyen = Quyen1;
                db.SubmitChanges();
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Show();
                r = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Phải chọn Tài khoản để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            db = new dbTYTDataContext();
            var query = db.TaiKhoanDangNhaps
            .Where(p => p.TaiKhoan.Contains(textBoxTimKiem.Text))
            .Union(db.TaiKhoanDangNhaps.Where(p => p.MatKhau.Contains(textBoxTimKiem.Text)))
            .Union(db.TaiKhoanDangNhaps.Where(p => p.MaHo.ToString().Contains(textBoxTimKiem.Text)))
            .Union(db.TaiKhoanDangNhaps.Where(p => p.Quyen.ToString().Contains(textBoxTimKiem.Text)));
            DGV.DataSource = query.ToList();
        }

        private void buttonXemDanhSach_Click(object sender, EventArgs e)
        {
            Show();
        }
    }
}
