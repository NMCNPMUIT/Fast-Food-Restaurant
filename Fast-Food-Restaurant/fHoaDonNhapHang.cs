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
        
        private void button_them_Click(object sender, EventArgs e)
        {
                DAO.fHoaDonNhapHangDAO.Instance.ThemHoaDonNhapHang(textBox_MP.Text,textBox_maNPP.Text,textBox_MNV.Text,dateTimePicker_NN, int.Parse(textBox_tongtien.Text));
                MessageBox.Show("Thêm thành công", "Thông báo");
        }

        private void button_themCT_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắc muốn thêm Hóa Đơn Nhập Hàng", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                dataGridView_CTPNhap.DataSource = DTO.fHoaDonNhapHangDTO.Instance.hienthi(textBox_maphieuCT.Text, textBox_MTP.Text, textBox_SL.Text, textBox_DG.Text);
                MessageBox.Show("Thêm thành công", "Thông báo");
            }
        }
    }
}