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
    public partial class ThongTinTruongPhongKham : Form
    {
        public ThongTinTruongPhongKham()
        {
            InitializeComponent();
        }

        private dbTYTDataContext db;
        public string mtv;

        private void ThongTinTruongPhongKham_Load(object sender, EventArgs e)
        {
            dbTYTDataContext db = new dbTYTDataContext();
            var thanhVien = (from tv in db.ThanhViens
                             where tv.MaThanhVien == mtv
                             select tv).FirstOrDefault();

            textBoxMaTruongPhong.Text = thanhVien.MaThanhVien;
            textBoxHoTen.Text = thanhVien.HoTen;
            textBoxNgaySinh.Text = ((DateTime)thanhVien.NgaySinh).ToString("dd/MM/yyyy");
            textBoxGioiTinh.Text = thanhVien.GioiTinh;
            textBoxDienThoai.Text = thanhVien.DienThoai;
        }
    }
}
