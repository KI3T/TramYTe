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
    public partial class SuaHoGiaDinh : Form
    {
        public SuaHoGiaDinh()
        {
            InitializeComponent();
        }

        private dbTYTDataContext db;
        private DataGridViewRow r;
        private void Show()
        {
            db = new dbTYTDataContext();
            DGV.DataSource = db.HoGiaDinhs.Select(c => c);
        }

        private void SuaHoGiaDinh_Load(object sender, EventArgs e)
        {
            Show();
            DGV.Columns["MaHo"].HeaderText = "Mã hộ";
            DGV.Columns["DiaChi"].HeaderText = "Địa chỉ";
            DGV.Columns["Email"].HeaderText = "Email";
            DGV.Columns["MaKhuPho"].HeaderText = "Mã khu phố";
            DGV.Columns["KhuPho"].HeaderText = "KhuPho";
            DGV.Columns["KhuPho"].Visible = false;
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
                MessageBox.Show("Vui lòng chọn Hộ gia đình muốn sửa hoặc thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                db = new dbTYTDataContext();
                var s = db.HoGiaDinhs.SingleOrDefault(p => p.MaHo == DGV.SelectedCells[0].OwningRow.Cells["MaHo"].Value.ToString());
                string MaHo1 = DGV.SelectedCells[0].OwningRow.Cells["MaHo"].Value.ToString();
                string DiaChi1 = DGV.SelectedCells[0].OwningRow.Cells["DiaChi"].Value.ToString();
                string Email1 = DGV.SelectedCells[0].OwningRow.Cells["Email"].Value.ToString();
                string MaKhuPho1 = DGV.SelectedCells[0].OwningRow.Cells["MaKhuPho"].Value.ToString();
                if (s == null)
                {
                    MessageBox.Show("Xin vui lòng không sửa Mã phòng khám!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Show();
                    return;
                }
                s.MaHo = MaHo1;
                s.DiaChi = DiaChi1;
                s.Email = Email1;
                s.MaKhuPho = MaKhuPho1;
                db.SubmitChanges();
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Show();
                r = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Phải chọn Hộ gia đình để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            db = new dbTYTDataContext();
            var query = db.HoGiaDinhs
            .Where(p => p.MaHo.Contains(textBoxTimKiem.Text))
            .Union(db.HoGiaDinhs.Where(p => p.DiaChi.Contains(textBoxTimKiem.Text)))
            .Union(db.HoGiaDinhs.Where(p => p.Email.ToString().Contains(textBoxTimKiem.Text)))
            .Union(db.HoGiaDinhs.Where(p => p.MaKhuPho.ToString().Contains(textBoxTimKiem.Text)));
            DGV.DataSource = query.ToList();
        }

        private void buttonXemDanhSach_Click(object sender, EventArgs e)
        {
            Show();
        }
    }
}
