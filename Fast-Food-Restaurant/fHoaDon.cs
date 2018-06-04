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
    public partial class   fHoaDon : DevExpress.XtraEditors.XtraForm
    {
        public fHoaDon()
        {
            InitializeComponent();
            loadcombobox();
        }
        
        private void clear()
        {
            textBox_dongia.Text = "";
            textBox_soluong.Text = "";
            comboBox_MaMA.Text = "";

        }

        public void loadcombobox()
        {
            DTO.fPhieuBanHangDTO.Instance.loadNV(comboBox_MaNV);
            DTO.fPhieuBanHangDTO.Instance.loadMaMA(comboBox_MaMA);
            
        }

        private void textBox_mhd_TextChanged(object sender, EventArgs e)
        {
            textBox_mhdCT.Text = textBox_mhd.Text;
        }

        private void button_themHD_Click(object sender, EventArgs e)
        {
            if (DTO.fPhieuBanHangDTO.Instance.loadMaHD(textBox_mhdCT.Text) != "0")
            {
                MessageBox.Show("Mã phiếu đã có. Mời nhập lại!", "Thông báo");
                textBox_mhdCT.Text = "";
            }
            else
            {
                clear();
                if (textBox_mhdCT.Text != "" && comboBox_MaNV.Text != "" )
                {
                    this.dataGridView_CTPNhap.Rows.Clear();
                    DTO.fPhieuBanHangDTO.Instance.ThemHD(textBox_mhdCT.Text, comboBox_MaNV.Text, textBox_mba.Text, dateTimePicker_ngayHD);
                    MessageBox.Show("Thêm thành công", "Thông báo");
                    clear();
                }
                else
                    MessageBox.Show("Bạn nhập chưa đủ thông tin", "Thông báo");
            }
        }

        private void buttonthem_Click(object sender, EventArgs e)
        {
            if (DTO.fPhieuBanHangDTO.Instance.countMaMA(textBox_mhdCT.Text, comboBox_MaMA.Text) != "0")
            {
                MessageBox.Show("Món ăn này đã mua được mua trong phiếu này rồi. Mời nhập lại!", "Thông báo");

            }
            else
            {
                if (comboBox_MaMA.Text != "" && textBox_soluong.Text != "")
                {
                    string dongia = textBox_dongia.Text.Replace(",", "");
                    int x = Convert.ToInt32(dongia);
                    DTO.fPhieuBanHangDTO.Instance.themCTHD(textBox_mhdCT.Text, comboBox_MaMA.Text, int.Parse(textBox_soluong.Text), x);
                    DTO.fPhieuBanHangDTO.Instance.hienthi(dataGridView_CTPNhap, textBox_mhdCT.Text, comboBox_MaMA.Text);
                    clear();
                    MessageBox.Show("Thêm thành công", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Bạn nhập chưa đủ thông tin", "Thông báo");
                }

            }

        }

        private void ChuyenTien(string text, TextBox text_tien)
        {
            var value = decimal.Parse(text);
            var info = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
            text_tien.Text = String.Format("{0:0,0}", value);
        }
        
        private void comboBox_MaMA_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dongia = DTO.fPhieuBanHangDTO.Instance.loadDonGia(comboBox_MaMA.Text);
   
            var value = decimal.Parse(DTO.fPhieuBanHangDTO.Instance.loadDonGia(comboBox_MaMA.Text));
            var info = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
            textBox_dongia.Text = String.Format("{0:0,0}", value);
        }
  
        private void button_tinhtien_Click(object sender, EventArgs e)
        {
            textBox_tongtien.Text = DTO.fPhieuBanHangDTO.Instance.loadTongTien(textBox_mhd.Text);
        }

        private void button_tiendu_Click(object sender, EventArgs e)
        {
            int tongtien = int.Parse(DTO.fPhieuBanHangDTO.Instance.loadTongTien(textBox_mhd.Text));
            int tiendu = int.Parse(textBox_tiennhan.Text) - tongtien;
            textBox_tiendu.Text = tiendu.ToString();
            ChuyenTien(textBox_tiendu.Text, textBox_tiendu);
        }

        private void textBox_tongtien_TextChanged(object sender, EventArgs e)
        {
            ChuyenTien(textBox_tongtien.Text, textBox_tongtien);
        }

        private void button_thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

}
