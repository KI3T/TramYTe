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
    public partial class QuanLyThongBao : Form
    {
        public QuanLyThongBao()
        {
            InitializeComponent();
        }

        private dbTYTDataContext db;
        private DataGridViewRow r;
        private void Show()
        {
            db = new dbTYTDataContext();
            DGV.DataSource = from a in db.ThongBaos
                             select new
                             {
                                 a.MaThongBao,
                                 a.TenThongBao,
                                 a.NoiDung,
                                 a.MaHo,
                                 a.ThoiGianGui
                             };
            //var entity = db.ThongBaos.ToList();
            //List<thongbaodto> list = new List<thongbaodto>();
            //foreach (var item in entity)
            //{
            //    thongbaodto dto = new thongbaodto();
            //    dto.MaHo = item.MaHo;
            //    dto.TenTB = item.TenThongBao;
            //    dto.MaTB = item.MaThongBao;
            //    dto.NoiDung = item.NoiDung;
            //    list.Add(dto);
            //}
            //DGV.DataSource = list;
        }

        private void QuanLyThongBao_Load(object sender, EventArgs e)
        {
            db = new dbTYTDataContext();
            var kp = from s in db.HoGiaDinhs
                     select s.MaHo;

            comboBoxMaHo.DataSource = kp.ToList();

            Show();
            DGV.Columns["MaThongBao"].HeaderText = "Mã thông báo";
            DGV.Columns["TenThongBao"].HeaderText = "Tiêu đề";
            DGV.Columns["NoiDung"].HeaderText = "Nội dung";
            DGV.Columns["MaHo"].HeaderText = "Mã hộ";
            DGV.Columns["ThoiGianGui"].HeaderText = "Thời gian gửi";
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
            if (string.IsNullOrEmpty(textBoxTenThongBao.Text))
            {
                MessageBox.Show("Tiêu đề không thể trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxTenThongBao.Select();
                return;
            }
            else if (string.IsNullOrEmpty(textBoxNoiDung.Text))
            {
                MessageBox.Show("Nội dung không thể trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxNoiDung.Select();
                return;
            }

            ThongBao tb = new ThongBao();
            tb.TenThongBao = textBoxTenThongBao.Text;
            tb.NoiDung = textBoxNoiDung.Text;
            tb.MaHo = comboBoxMaHo.Text;
            tb.ThoiGianGui = DateTime.Now;
            db.ThongBaos.InsertOnSubmit(tb);
            db.SubmitChanges();
            MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Show();
            textBoxTenThongBao.Text = textBoxNoiDung.Text = null;
            panelThongTin.Visible = false;
        }

        private void buttonLamMoi_Click(object sender, EventArgs e)
        {
            textBoxTenThongBao.Text = textBoxNoiDung.Text = null;
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn Thông báo muốn xóa hoặc thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var maThongBao = Convert.ToInt32(DGV.SelectedCells[0].OwningRow.Cells["MaThongBao"].Value);
                var s = db.ThongBaos.SingleOrDefault(p => p.MaThongBao == maThongBao);
                db.ThongBaos.DeleteOnSubmit(s);
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
            var searchResults = from p in db.ThongBaos
                                where p.MaThongBao.ToString().Contains(textBoxTimKiem.Text)
                                || p.TenThongBao.Contains(textBoxTimKiem.Text)
                                || p.NoiDung.Contains(textBoxTimKiem.Text)
                                || p.ThoiGianGui.ToString().Contains(textBoxTimKiem.Text)
                                || p.MaHo.Contains(textBoxTimKiem.Text)
                                select new
                                {
                                    p.MaThongBao,
                                    p.TenThongBao,
                                    p.NoiDung,
                                    p.MaHo,
                                    p.ThoiGianGui,
                                };
            DGV.DataSource = searchResults.ToList();
        }

        private void buttonXemDanhSach_Click(object sender, EventArgs e)
        {
            Show();
        }
    }
}
