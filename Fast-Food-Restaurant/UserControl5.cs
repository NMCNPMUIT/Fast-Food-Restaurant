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
    public partial class UserControl5 : UserControl
    {
        public UserControl5()
        {
            InitializeComponent();
            Load_NPP();
        }
        public void Load_NPP()
        {
            dataGridView1.DataSource = FastFoodDAO.Instance.Load_NPP();
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            txtmsnv.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtname.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtdiachi.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void Addbutton_Click(object sender, EventArgs e)
        {
            FastFoodDAO.Instance.ThemNPP(txtmsnv.Text, txtname.Text, txtdiachi.Text);
            Load_NPP();
        }

        private void AlterButton_Click(object sender, EventArgs e)
        {
            FastFoodDAO.Instance.AlterNPP(txtmsnv.Text, txtname.Text, txtdiachi.Text);
            Load_NPP();
        }
    }
}
