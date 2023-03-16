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
    public partial class TuyChinhHoGiaDinh : Form
    {
        public TuyChinhHoGiaDinh()
        {
            InitializeComponent();
        }

        private dbTYTDataContext db;
        private DataGridViewRow r;
        private void Show()
        {
            db = new dbTYTDataContext();
            var hogiadinh = from a in db.HoGiaDinhs
                            join b in db.ThanhViens on a.MaHo equals b.MaHo into g
                            where textBoxMaKhuPho.Text == a.MaKhuPho
                            select new
                            {
                                a.MaHo,
                                a.DiaChi,
                                a.Email,
                                SoLuongThanhVien = g.Count()
                            };
            DGV.DataSource = hogiadinh.ToList();
        }

        private void TuyChinhHoGiaDinh_Load(object sender, EventArgs e)
        {
            db = new dbTYTDataContext();
            var kp = from s in db.KhuPhos
                     select s.TenKhuPho;

            comboBoxKhuPho.DataSource = kp.ToList();

            Show();
            DGV.Columns["MaHo"].HeaderText = "Tên hộ gia đình";
            DGV.Columns["DiaChi"].HeaderText = "Địa chỉ";
            DGV.Columns["Email"].HeaderText = "Email";
            DGV.Columns["SoLuongThanhVien"].HeaderText = "Số lượng thành viên";
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
            if (string.IsNullOrEmpty(textBoxMaHo.Text))
            {
                MessageBox.Show("Mã hộ gia đình không thể trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxMaHo.Select();
                return;
            }
            else if (string.IsNullOrEmpty(textBoxDiaChi.Text))
            {
                MessageBox.Show("Địa chỉ không thể trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxDiaChi.Select();
                return;
            }
            else if (string.IsNullOrEmpty(textBoxEmail.Text))
            {
                MessageBox.Show("Email không thể trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxEmail.Select();
                return;
            }
            else
            {
                var s = db.HoGiaDinhs.Where(p => p.MaHo == textBoxMaHo.Text).Count();
                if (s > 0)
                {
                    MessageBox.Show("Mã hộ gia đình đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxMaHo.Select();
                    return;
                }
            }

            HoGiaDinh hgd = new HoGiaDinh();
            hgd.MaHo = textBoxMaHo.Text;
            hgd.DiaChi = textBoxDiaChi.Text;
            hgd.Email = textBoxEmail.Text;
            hgd.MaKhuPho = comboBoxKhuPho.Text;
            db.HoGiaDinhs.InsertOnSubmit(hgd);
            db.SubmitChanges();
            MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Show();
            textBoxMaHo.Text = textBoxDiaChi.Text = textBoxEmail.Text = null;
            panelThongTin.Visible = false;
        }

        private void buttonLamMoi_Click(object sender, EventArgs e)
        {
            textBoxMaHo.Text = textBoxDiaChi.Text = textBoxEmail.Text = null;
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            SuaHoGiaDinh f = new SuaHoGiaDinh();
            f.Show();
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn Hộ gia đình muốn xóa hoặc thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var s = db.HoGiaDinhs.SingleOrDefault(p => p.MaHo == DGV.SelectedCells[0].OwningRow.Cells["MaHo"].Value.ToString());
                db.HoGiaDinhs.DeleteOnSubmit(s);
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
            var searchResults = from a in db.HoGiaDinhs
                            join b in db.ThanhViens on a.MaHo equals b.MaHo into g
                            where textBoxMaKhuPho.Text == a.MaKhuPho
                            where a.MaHo.Contains(textBoxTimKiem.Text)
                            || a.DiaChi.Contains(textBoxTimKiem.Text)
                            || a.Email.Contains(textBoxTimKiem.Text)
                            select new
                            {
                                a.MaHo,
                                a.DiaChi,
                                a.Email,
                                SoLuongThanhVien = g.Count()
                            };
            DGV.DataSource = searchResults.ToList();
        }

        private void buttonXemDanhSach_Click(object sender, EventArgs e)
        {
            Show();
        }

        private void comboBoxKhuPho_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tenkhupho = comboBoxKhuPho.SelectedItem.ToString();
            var kp = (from s in db.KhuPhos
                      where s.TenKhuPho == tenkhupho
                      select s).FirstOrDefault();
            if (kp != null)
            {
                textBoxMaKhuPho.Text = kp.MaKhuPho;
            }
            Show();
        }
    }
}
