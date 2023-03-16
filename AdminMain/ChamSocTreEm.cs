using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TramYTe.Database;

namespace TramYTe.AdminMain
{
    public partial class ChamSocTreEm : Form
    {
        public ChamSocTreEm()
        {
            InitializeComponent();
        }

        private dbTYTDataContext db;

        private void buttonSuyDinhDuong_Click(object sender, EventArgs e)
        {
            DGV.DataSource = null;
            db = new dbTYTDataContext();
            var today = DateTime.Today;
            DGV.DataSource = from a in db.ThanhViens
                             from b in db.DinhDuongs
                             from c in db.TreSuyDinhDuongs
                             let thangTuoi = SqlMethods.DateDiffMonth(a.NgaySinh, DateTime.Now)
                             where a.MaThanhVien == b.MaThanhVien
                                && thangTuoi == c.ThangTuoi
                                && a.GioiTinh == c.GioiTinh
                                && b.CanNang < c.CanNang
                                && thangTuoi <= 60
                             select new
                             {
                                 a.MaHo,
                                 a.HoTen,
                                 ThangTuoi = thangTuoi,
                                 b.ChieuCao,
                                 b.CanNang
                             };
            DGV.Columns["MaHo"].HeaderText = "Mã hộ";
            DGV.Columns["HoTen"].HeaderText = "Họ tên";
            DGV.Columns["ThangTuoi"].HeaderText = "Tháng tuổi";
            DGV.Columns["ChieuCao"].HeaderText = "Chiều cao (cm)";
            DGV.Columns["CanNang"].HeaderText = "Cân nặng (kg)";
        }

        private void buttonKhoeManh_Click(object sender, EventArgs e)
        {
            DGV.DataSource = null;
            db = new dbTYTDataContext();
            var today = DateTime.Today;
            DGV.DataSource = (from a in db.ThanhViens
                              from b in db.DinhDuongs
                              from c in db.TreSuyDinhDuongs
                              from d in db.TreBeoPhis
                              let thangTuoi = SqlMethods.DateDiffMonth(a.NgaySinh, DateTime.Now)
                              where a.MaThanhVien == b.MaThanhVien
                                 && a.GioiTinh == c.GioiTinh
                                 && thangTuoi == c.ThangTuoi
                                 && b.CanNang > c.CanNang
                                 && d.CanNang > b.CanNang
                                 && thangTuoi <= 60
                              select new
                              {
                                  a.MaHo,
                                  a.HoTen,
                                  ThangTuoi = thangTuoi,
                                  b.ChieuCao,
                                  b.CanNang
                              }).Distinct();
            DGV.Columns["MaHo"].HeaderText = "Mã hộ";
            DGV.Columns["HoTen"].HeaderText = "Họ tên";
            DGV.Columns["ThangTuoi"].HeaderText = "Tháng tuổi";
            DGV.Columns["ChieuCao"].HeaderText = "Chiều cao";
            DGV.Columns["CanNang"].HeaderText = "Cân nặng";
        }

        private void buttonBeoPhi_Click(object sender, EventArgs e)
        {
            DGV.DataSource = null;
            db = new dbTYTDataContext();
            var today = DateTime.Today;
            DGV.DataSource = from a in db.ThanhViens
                             from b in db.DinhDuongs
                             from c in db.TreBeoPhis
                             let thangTuoi = SqlMethods.DateDiffMonth(a.NgaySinh, DateTime.Now)
                             where a.MaThanhVien == b.MaThanhVien
                                && thangTuoi == c.ThangTuoi
                                && a.GioiTinh == c.GioiTinh
                                && c.CanNang < b.CanNang
                                && thangTuoi <= 60
                             select new
                             {
                                 a.MaHo,
                                 a.HoTen,
                                 ThangTuoi = thangTuoi,
                                 b.ChieuCao,
                                 b.CanNang
                             };
            DGV.Columns["MaHo"].HeaderText = "Mã hộ";
            DGV.Columns["HoTen"].HeaderText = "Họ tên";
            DGV.Columns["ThangTuoi"].HeaderText = "Tháng tuổi";
            DGV.Columns["ChieuCao"].HeaderText = "Chiều cao";
            DGV.Columns["CanNang"].HeaderText = "Cân nặng";
        }
    }
}
