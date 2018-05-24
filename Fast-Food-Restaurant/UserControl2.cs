using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QUANLYBANHANG.DAO;
namespace QUANLYBANHANG
{
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
            Load_DSNV();
        }

        public void Load_DSNV()
        {
            dataGridView1.DataSource = QuanLyBanHangDAO.Instance.Load_DSNV();
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);
        }

        private void AddNV_Click(object sender, EventArgs e)
        {
            if (radioNam.Checked)
                QuanLyBanHangDAO.Instance.ThemNVMoi(txtmsnv.Text, txtname.Text, txtsdt.Text, dateTimePickerNgayvl.Text, txtchucvu.Text, dateTimePickerNgaySinh.Text, radioNam.Text.ToString());
            else
                QuanLyBanHangDAO.Instance.ThemNVMoi(txtmsnv.Text, txtname.Text, txtsdt.Text, dateTimePickerNgayvl.Text, txtchucvu.Text, dateTimePickerNgaySinh.Text, radioNu.Text.ToString());
                Load_DSNV();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
       /* private void AlterNV_Click(object sender, EventArgs e)
        {
            if (radioNam.Checked)
                QuanLyBanHangDAO.Instance.SuaNV(txtname.Text, txtsdt.Text, dateTimePickerNgayvl.Text, txtchucvu.Text, dateTimePickerNgaySinh.Text, radioNam.Text.ToString());
            else
                QuanLyBanHangDAO.Instance.SuaNV(txtname.Text, txtsdt.Text, dateTimePickerNgayvl.Text, txtchucvu.Text, dateTimePickerNgaySinh.Text, radioNu.Text.ToString());
            
        }*/
        public void ifRadioChecked()
        {
            if (dataGridView1.SelectedRows[0].Cells[6].Value.ToString() == "Nam")
                radioNam.Checked = true;
            else radioNu.Checked = true;
        }
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            txtmsnv.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtname.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtsdt.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            dateTimePickerNgayvl.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtchucvu.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            dateTimePickerNgaySinh.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            ifRadioChecked();
        }

        private void AlterNV_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Bạn có muốn cập nhật?", "Thông báo",MessageBoxButtons.YesNo);
            if (result1 == DialogResult.No)
                return ;
            if (radioNam.Checked)    
                QuanLyBanHangDAO.Instance.SuaNV(txtmsnv.Text ,txtname.Text, txtsdt.Text, dateTimePickerNgayvl.Text, txtchucvu.Text, dateTimePickerNgaySinh.Text, radioNam.Text.ToString());
            else
                QuanLyBanHangDAO.Instance.SuaNV(txtmsnv.Text, txtname.Text, txtsdt.Text, dateTimePickerNgayvl.Text, txtchucvu.Text, dateTimePickerNgaySinh.Text, radioNu.Text.ToString());
            
            Load_DSNV();
        }
    }
}
