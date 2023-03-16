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

namespace TramYTe
{
    public partial class ThongBaoHome : Form
    {
        public ThongBaoHome()
        {
            InitializeComponent();
        }

        public string maho;
        private dbTYTDataContext db;

        private void ThongBaoHome_Load(object sender, EventArgs e)
        {
            db = new dbTYTDataContext();
            DGV.DataSource = from b in db.ThongBaos
                             where maho == b.MaHo
                             select new
                             {
                                 b.TenThongBao,
                                 b.NoiDung,
                                 b.ThoiGianGui
                             };
            DGV.Columns["TenThongBao"].HeaderText = "Tiêu đề";
            DGV.Columns["NoiDung"].HeaderText = "Nội dung";
            DGV.Columns["ThoiGianGui"].HeaderText = "Thời gian gửi";
        }
    }
}
