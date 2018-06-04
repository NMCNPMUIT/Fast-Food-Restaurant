using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Fast_Food_Restaurant.DTO
{
    public class fPhieuBanHangDTO
    {
        private static fPhieuBanHangDTO instance;

        public static fPhieuBanHangDTO Instance
        {
            get { if (instance == null) instance = new fPhieuBanHangDTO(); return instance;}

            set{instance = value;}
        }

        public void ThemHD(string a, string b, string c,DateTimePicker d)
        {
            DAO.fPhieuBanHangDAO.Instance.ThemHoaDonBanHang(a, b, c, d.Value);
        }
        public string loadMaHD(string maHD)
        {
            DataTable table = DAO.fPhieuBanHangDAO.Instance.loadMAHD(maHD);
            return table.Columns[0].Table.Rows[0].ItemArray[0].ToString();
        }

        public string countMaMA(string maHD,string maMA)
        {
            DataTable table = DAO.fPhieuBanHangDAO.Instance.countMAMA(maHD,maMA);
            return table.Columns[0].Table.Rows[0].ItemArray[0].ToString();
        }

        public void loadNV(ComboBox nv)
        {
            nv.DropDownStyle = ComboBoxStyle.DropDown;
            DataTable table = DAO.fPhieuBanHangDAO.Instance.loadcomboboxNhanVien();
            for (int i = 0; i < table.Columns[0].Table.Rows.Count; i++)
            {
                nv.Items.Add(table.Columns[0].Table.Rows[i].ItemArray[0].ToString());
            }
            nv.DisplayMember = "MANV";
            nv.ValueMember = "MANV";
        }

        public void loadMaMA(ComboBox nv)
        {
            nv.DropDownStyle = ComboBoxStyle.DropDown;
            DataTable table = DAO.fPhieuBanHangDAO.Instance.loadcomboboxMonAn();
            for (int i = 0; i < table.Columns[0].Table.Rows.Count; i++)
            {
                nv.Items.Add(table.Columns[0].Table.Rows[i].ItemArray[0].ToString());
            }
            nv.DisplayMember = "MAMA";
            nv.ValueMember = "MAMA";
        }
        public void themCTHD(string a, string b, int c, int d)
        {
            DAO.fPhieuBanHangDAO.Instance.ThemCTHD(a, b, c, d);
        }

        public void hienthi(DataGridView dataGridView_CTPNhap, string a, string b)
        {
            DataTable table = DAO.fPhieuBanHangDAO.Instance.HienthiCTHD(a, b);
            int n = dataGridView_CTPNhap.Rows.Add();
            for (int i = 0; i < table.Columns.Count; i++)
            {
                dataGridView_CTPNhap.Rows[n].Cells[i].Value = table.Columns[0].Table.Rows[0].ItemArray[i].ToString();
            }
        }

        public string loadDonGia(string maMA)
        {
            return DAO.fPhieuBanHangDAO.Instance.textbox_dongia(maMA);
        }

        public string loadTongTien(string maphieu)
        {
            return DAO.fPhieuBanHangDAO.Instance.tongtien(maphieu);
        }

    }
}
