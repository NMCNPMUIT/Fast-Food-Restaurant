using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Fast_Food_Restaurant.DTO
{
    public class fHoaDonNhapHangDTO
    {
        private static fHoaDonNhapHangDTO instance;

        public static fHoaDonNhapHangDTO Instance
        {
            get { if (instance == null) instance = new fHoaDonNhapHangDTO(); return instance; }

           private set { instance = value; }
        }

        private string maphieu;

        public string Maphieu
        {
            get{ return maphieu;}

            set{ maphieu = value;}
        }

        private string mathucpham;

        public string Mathucpham
        {
            get { return mathucpham; }

            set { mathucpham = value; }
        }
        private string soluong;

        public string Soluong
        {
            get { return soluong; }

            set { soluong = value; }
        }

        private string dongia;

        public string Dongia
        {
            get { return dongia; }

            set { dongia = value; }
        }

        public void ThemHDNH(string a, string b, string c, DateTimePicker d)
        {
            DAO.fHoaDonNhapHangDAO.Instance.ThemHoaDonNhapHang(a, b, c, d.Value);

        }

        public void themCTPNH(string a, string b, int c, int d)
        {
            DAO.fHoaDonNhapHangDAO.Instance.ThemCTNH(a, b, c, d);
        }
        public void hienthi(DataGridView dataGridView_CTPNhap, string a,string b)
        {
            DataTable table = DAO.fHoaDonNhapHangDAO.Instance.HienthiCTHD(a,b);
            int n = dataGridView_CTPNhap.Rows.Add();
            for (int i = 0; i < table.Columns.Count; i++)
            {
                dataGridView_CTPNhap.Rows[n].Cells[i].Value = table.Columns[0].Table.Rows[0].ItemArray[i].ToString();
            }
        }

        public void loadNPP(ComboBox npp)
        {
            npp.DropDownStyle = ComboBoxStyle.DropDown;           
            DataTable table = DAO.fHoaDonNhapHangDAO.Instance.loadcomboboxNhaPhanPhoi();
            for(int i = 0;i < table.Columns[0].Table.Rows.Count;i++)
            {
                npp.Items.Add(table.Columns[0].Table.Rows[i].ItemArray[0].ToString());
            }
            npp.DisplayMember = "MANPP";
            npp.ValueMember= "MANPP";

        }

        public void loadNV(ComboBox nv)
        {
            nv.DropDownStyle = ComboBoxStyle.DropDown;
            DataTable table = DAO.fHoaDonNhapHangDAO.Instance.loadcomboboxNhanVien();
            for (int i = 0; i < table.Columns[0].Table.Rows.Count; i++)
            {
                nv.Items.Add(table.Columns[0].Table.Rows[i].ItemArray[0].ToString());
            }
            nv.DisplayMember = "MANV";
            nv.ValueMember = "MANV";
        }
        public void loadTP(ComboBox TP, string manpp)
        {
            TP.DropDownStyle = ComboBoxStyle.DropDown;
            DataTable table = DAO.fHoaDonNhapHangDAO.Instance.combobox_thucpham(manpp);
            for (int i = 0; i < table.Columns[0].Table.Rows.Count; i++)
            {
                TP.Items.Add(table.Columns[0].Table.Rows[i].ItemArray[0].ToString());
            }
            TP.DisplayMember = "MATP";
            TP.ValueMember = "MATP";
        }

        public string loadDonGia(string matp)
        {
            return DAO.fHoaDonNhapHangDAO.Instance.textbox_dongia(matp);
        }
        public string loadTongTien(string maphieu)
        {
            return DAO.fHoaDonNhapHangDAO.Instance.tongtien(maphieu);
        }
        public string loadMaPhieu(string maphieu)
        {
            DataTable table = DAO.fHoaDonNhapHangDAO.Instance.loadMAPHIEU(maphieu);
            return table.Columns[0].Table.Rows[0].ItemArray[0].ToString();        
        }

        public string loadMATP(string maphieu, string matp)
        {
            DataTable table = DAO.fHoaDonNhapHangDAO.Instance.loadMATP(maphieu,matp);
            return table.Columns[0].Table.Rows[0].ItemArray[0].ToString();
        }
    }
}
