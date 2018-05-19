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
    public partial class fHoaDonNhapHang : DevExpress.XtraEditors.XtraForm
    {
        public fHoaDonNhapHang()
        {
            InitializeComponent();
        }

        private void listView_DSPhieunhap_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Collections.IEnumerator ie = listView_DSPhieunhap.SelectedItems.GetEnumerator();
            if (ie.MoveNext())
            {
                ListViewItem item = (ListViewItem)ie.Current;
                textBox_MP.Text = item.SubItems[1].Text;
                comboBoxMANCC.Text = item.SubItems[2].Text;
                textBox_MNV.Text = item.SubItems[3].Text;
                dateTimePicker_NN.Text = item.SubItems[4].Text;
                textBox_tongtien.Text = item.SubItems[5].Text;

            }
        }
    }
}