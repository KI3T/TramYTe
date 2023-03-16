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
    public partial class TaoThongBao : Form
    {
        public TaoThongBao()
        {
            InitializeComponent();
        }

        private dbTYTDataContext db;
        private void TaoThongBao_Load(object sender, EventArgs e)
        {
            db = new dbTYTDataContext();
            var kp = from s in db.HoGiaDinhs
                     select s.MaHo;

            comboBoxMaHo.DataSource = kp.ToList();
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
            textBoxTenThongBao.Text = textBoxNoiDung.Text = null;
        }

        private void buttonLamMoi_Click(object sender, EventArgs e)
        {
            textBoxTenThongBao.Text = textBoxNoiDung.Text = null;
        }
    }
}
