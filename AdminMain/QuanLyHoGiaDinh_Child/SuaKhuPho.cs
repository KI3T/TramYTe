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
    public partial class SuaKhuPho : Form
    {
        public SuaKhuPho()
        {
            InitializeComponent();
        }

        private dbTYTDataContext db;
        private DataGridViewRow r;
        private void Show()
        {
            db = new dbTYTDataContext();
            DGV.DataSource = db.KhuPhos.Select(c => c);
        }

        private void SuaKhuPho_Load(object sender, EventArgs e)
        {
            Show();
            DGV.Columns["MaKhuPho"].HeaderText = "Mã khu phố";
            DGV.Columns["TenKhuPho"].HeaderText = "Tên khu phố";
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
                MessageBox.Show("Vui lòng chọn Khu phố muốn sửa hoặc thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                db = new dbTYTDataContext();
                var s = db.KhuPhos.SingleOrDefault(p => p.MaKhuPho == DGV.SelectedCells[0].OwningRow.Cells["MaKhuPho"].Value.ToString());
                string MaKhuPho1 = DGV.SelectedCells[0].OwningRow.Cells["MaKhuPho"].Value.ToString();
                string TenKhuPho1 = DGV.SelectedCells[0].OwningRow.Cells["TenKhuPho"].Value.ToString();
                if (s == null)
                {
                    MessageBox.Show("Xin vui lòng không sửa Mã phòng khám!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Show();
                    return;
                }
                s.MaKhuPho = MaKhuPho1;
                s.TenKhuPho = TenKhuPho1;
                db.SubmitChanges();
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Show();
                r = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Phải chọn Khu phố để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            db = new dbTYTDataContext();
            var query = db.KhuPhos
            .Where(p => p.MaKhuPho.Contains(textBoxTimKiem.Text))
            .Union(db.KhuPhos.Where(p => p.TenKhuPho.Contains(textBoxTimKiem.Text)));
            DGV.DataSource = query.ToList();
        }

        private void buttonXemDanhSach_Click(object sender, EventArgs e)
        {
            Show();
        }
    }
}
