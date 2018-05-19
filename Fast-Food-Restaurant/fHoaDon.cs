using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Fast_Food_Restaurant
{
    public partial class fHoaDon : DevExpress.XtraEditors.XtraForm
    {
        public fHoaDon()
        {
            InitializeComponent();
        }
        void ShowHoadon()
        {
            listView_CTPbanhang.Items.Clear();

        }
        private void button_tinhtien_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonthem_Click(object sender, EventArgs e)
        {

            System.Collections.IEnumerator ie = listView_CTPbanhang.SelectedItems.GetEnumerator();

            if (ie.MoveNext())
            {
                ListViewItem item = (ListViewItem)ie.Current;
                item.SubItems[1].Text = "anh";
                item.SubItems[2].Text = "anh";
                item.SubItems[3].Text = "anh";
                item.SubItems[4].Text = "anh";
            }
        }
    }
}