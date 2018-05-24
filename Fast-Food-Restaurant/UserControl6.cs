using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fast_Food_Restaurant.DAO2;
using Fast_Food_Restaurant.DTO;
namespace Fast_Food_Restaurant
{
    public partial class UserControl6 : UserControl
    {
        public UserControl6()
        {
            InitializeComponent();
            Load_();
        }
        private void Load_()
        {
            Load_THUCPHAM();
            LoadTenNPPIntoCombobox(comboBox2);
        }
        private void LoadTenNPPIntoCombobox(ComboBox cb)
        {
            cb.DataSource = NhaPhanPhoiDAO.Instance.GetListNhaPhanPhoi();
            cb.DisplayMember = "TENNPP";

        }
        private void Load_THUCPHAM()
        {
            dataGridView1.DataSource = FastFoodDAO.Instance.Load_THUCPHAM();
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            txtmama.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtname.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtmoney.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtdvt.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
           // comboBox2.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void InsertBut_Click(object sender, EventArgs e)
        {
            string msnv = txtmama.Text;
            string manpp2 = (comboBox2.SelectedItem as NhaPhanPhoi).IdNPP;
            string money = txtmoney.Text;
           
            FastFoodDAO.Instance.ThemTHUCPHAM(txtmama.Text, txtname.Text, txtmoney.Text,txtdvt.Text,manpp2);
            Load_THUCPHAM();
        }

        private void AlterButton_Click(object sender, EventArgs e)
        {
            string manpp2 = (comboBox2.SelectedItem as NhaPhanPhoi).IdNPP;
            FastFoodDAO.Instance.AlterTHUCPHAM(manpp2, txtname.Text, txtmoney.Text, txtdvt.Text,txtmama.Text);
            Load_THUCPHAM();
        }

        private void txtmama_TextChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                string manpp = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                NhaPhanPhoi nhaphanphoi = NhaPhanPhoiDAO.Instance.GetNhaPhanPhoiByID(manpp);
                comboBox2.SelectedItem = nhaphanphoi;
                int index = -1;
                int i = 0;
                foreach (NhaPhanPhoi item in comboBox2.Items)
                {
                    if (item.IdNPP == nhaphanphoi.IdNPP)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
                comboBox2.SelectedIndex = index;
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            string matp = txtmama.Text;
            FastFoodDAO.Instance.deleteTHUCPHAM(matp);
        }
    }
}
