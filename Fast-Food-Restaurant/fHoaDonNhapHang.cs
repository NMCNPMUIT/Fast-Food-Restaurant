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
            loadcombobox();
        }

        private void clear()
        {
            textBox_SL.Text = "";
            textBox_DG.Text = "";
            comboBox_TP.Text = "";

        }
        private void button_them_Click(object sender, EventArgs e)
        {
            if (DTO.fHoaDonNhapHangDTO.Instance.loadMaPhieu(textBox_MP.Text)!="0")
            {
                MessageBox.Show("Mã phiếu đã có. Mời nhập lại!", "Thông báo");
                textBox_MP.Text = "";
            }
            else
            {
                clear();
                if (textBox_MP.Text != "" && comboBox_NPP.Text != "" && comboBox_NV.Text != "")
                {
                    this.dataGridView_CTPNhap.Rows.Clear();
                    DTO.fHoaDonNhapHangDTO.Instance.ThemHDNH(textBox_MP.Text, comboBox_NPP.Text, comboBox_NV.Text, dateTimePicker_NN);
                    MessageBox.Show("Thêm thành công", "Thông báo");
                    clear();
                }
                else
                    MessageBox.Show("Bạn nhập chưa đủ thông tin", "Thông báo");
            }
            

        }

        private void button_themCT_Click(object sender, EventArgs e)
        {
            if (DTO.fHoaDonNhapHangDTO.Instance.loadMATP(textBox_MP.Text,comboBox_TP.Text) != "0")
            {
                MessageBox.Show("Thực phẩm đã mua trong phiếu này rồi. Mời nhập lại!", "Thông báo");
               
            }
            else
            {
                if (comboBox_TP.Text != "" && textBox_SL.Text != "")
                {
                    DTO.fHoaDonNhapHangDTO.Instance.themCTPNH(textBox_maphieuCT.Text, comboBox_TP.Text, int.Parse(textBox_SL.Text), int.Parse(textBox_DG.Text));
                    DTO.fHoaDonNhapHangDTO.Instance.hienthi(dataGridView_CTPNhap, textBox_maphieuCT.Text, comboBox_TP.Text);
                    clear();
                    MessageBox.Show("Thêm thành công", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Bạn nhập chưa đủ thông tin", "Thông báo");
                }
                
            }
            
        }

        
        public void loadcombobox()
        {
            DTO.fHoaDonNhapHangDTO.Instance.loadNPP(comboBox_NPP);
            DTO.fHoaDonNhapHangDTO.Instance.loadNV(comboBox_NV);
            //DTO.fHoaDonNhapHangDTO.Instance.loadTP(comboBox_TP,comboBox_NPP.Text);
        }

        private void button_tongtien_Click(object sender, EventArgs e)
        {
            textBox_tongtien.Text = DTO.fHoaDonNhapHangDTO.Instance.loadTongTien(textBox_MP.Text);
        }

        private void textBox_MP_TextChanged(object sender, EventArgs e)
        {
            textBox_maphieuCT.Text = textBox_MP.Text;
            //comboBox_TP.Text = "";
        }

        private void comboBox_TP_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox_DG.Text = DTO.fHoaDonNhapHangDTO.Instance.loadDonGia(comboBox_TP.Text);
        }

        private void comboBox_NPP_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_TP.Items.Clear();
            DTO.fHoaDonNhapHangDTO.Instance.loadTP(comboBox_TP, comboBox_NPP.Text);
        }

        private void textBox_DG_TextChanged(object sender, EventArgs e)
        {
            textBox_DG.Text = string.Format("{0:0,0}", textBox_DG.Text);
        }

        //private void textBox_DG_TextChanged(object sender, EventArgs e)
        //{
        //    //DTO.fHoaDonNhapHangDTO.Instance.loadDonGia(textBox_DG.Text,comboBox_TP.Text);
        //}
    }
}