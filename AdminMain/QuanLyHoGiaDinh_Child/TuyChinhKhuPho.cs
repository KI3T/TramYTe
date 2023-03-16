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
    public partial class TuyChinhKhuPho : Form
    {
        public TuyChinhKhuPho()
        {
            InitializeComponent();
        }

        private dbTYTDataContext db;
        private DataGridViewRow r;
        private void Show()
        {
            db = new dbTYTDataContext();
            var khupho = from a in db.KhuPhos
                         join b in db.HoGiaDinhs on a.MaKhuPho equals b.MaKhuPho into g
                         select new
                         {
                             a.MaKhuPho,
                             a.TenKhuPho,
                             SoLuongHoGiaDinh = g.Count()
                         };
            DGV.DataSource = khupho.ToList();
        }

        private void TuyChinhKhuPho_Load(object sender, EventArgs e)
        {
            Show();
            DGV.Columns["MaKhuPho"].HeaderText = "Mã khu phố";
            DGV.Columns["TenKhuPho"].HeaderText = "Tên khu phố";
            DGV.Columns["SoLuongHoGiaDinh"].HeaderText = "Số lượng hộ gia đình";
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
            if (string.IsNullOrEmpty(textBoxMaKhuPho.Text))
            {
                MessageBox.Show("Mã khu phố không thể trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxMaKhuPho.Select();
                return;
            }
            else if (string.IsNullOrEmpty(textBoxTenKhuPho.Text))
            {
                MessageBox.Show("Tên khu phố không thể trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxTenKhuPho.Select();
                return;
            }
            else
            {
                var s = db.KhuPhos.Where(p => p.MaKhuPho == textBoxMaKhuPho.Text).Count();
                if (s > 0)
                {
                    MessageBox.Show("Mã khu phố đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxMaKhuPho.Select();
                    return;
                }
            }

            KhuPho kp = new KhuPho();
            kp.MaKhuPho = textBoxMaKhuPho.Text;
            kp.TenKhuPho = textBoxTenKhuPho.Text;
            db.KhuPhos.InsertOnSubmit(kp);
            db.SubmitChanges();
            MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Show();
            textBoxMaKhuPho.Text = textBoxTenKhuPho.Text = null;
            panelThongTin.Visible = false;
        }

        private void buttonLamMoi_Click(object sender, EventArgs e)
        {
            textBoxMaKhuPho.Text = textBoxTenKhuPho.Text = null;
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            SuaKhuPho f = new SuaKhuPho();
            f.Show();
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn Khu phố muốn xóa hoặc thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var s = db.KhuPhos.SingleOrDefault(p => p.MaKhuPho == DGV.SelectedCells[0].OwningRow.Cells["MaKhuPho"].Value.ToString());
                db.KhuPhos.DeleteOnSubmit(s);
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
            var searchResults = from a in db.KhuPhos
                         join b in db.HoGiaDinhs on a.MaKhuPho equals b.MaKhuPho into g
                         where a.MaKhuPho.Contains(textBoxTimKiem.Text)
                         || a.TenKhuPho.Contains(textBoxTimKiem.Text)
                         select new
                         {
                             a.MaKhuPho,
                             a.TenKhuPho,
                             SoLuongHoGiaDinh = g.Count()
                         };
            DGV.DataSource = searchResults.ToList();
        }

        private void buttonXemDanhSach_Click(object sender, EventArgs e)
        {
            Show();
        }
    }
}
