using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fast_Food_Restaurant
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            userControl41.BringToFront();
        }

        private void barBtn_monan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            userControl11.BringToFront();
        }

        private void barBtn_qlnhanvien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            userControl41.BringToFront();
        }

        private void barBtn_qlncc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            userControl51.BringToFront();
        }

        private void barBtn_thucpham_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            userControl61.BringToFront();
        }

    }
}
