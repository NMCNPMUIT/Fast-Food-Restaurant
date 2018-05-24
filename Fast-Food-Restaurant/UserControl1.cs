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
namespace Fast_Food_Restaurant
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            Load_MonAn();
        }
        public void Load_MonAn()
        {
            dataGridView1.DataSource = FastFoodDAO.Instance.Load_MonAn();
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void InsertBut_Click(object sender, EventArgs e)
        {
            FastFoodDAO.Instance.ThemMONAN(txtmama.Text,txtname.Text,txtmoney.Text);
            Load_MonAn();
        }

        private void AlterButton_Click(object sender, EventArgs e)
        {
            FastFoodDAO.Instance.AlterMONAN(txtmama.Text, txtname.Text, txtmoney.Text);
            Load_MonAn();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            txtmama.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtname.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtmoney.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }
    }
}
