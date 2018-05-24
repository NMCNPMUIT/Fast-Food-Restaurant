using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Fast_Food_Restaurant.DAO
{
    public class fHoaDonNhapHangDAO
    {
        private static fHoaDonNhapHangDAO instance;

        public static fHoaDonNhapHangDAO Instance
        {
            get { if (instance == null) instance = new fHoaDonNhapHangDAO(); return instance; }

            private set { instance = value; }
        }
        private fHoaDonNhapHangDAO() { }
        public void ThemHoaDonNhapHang( string maphieu,string maNPP, string maNV, DateTime ngaynhap)
        {
            string sql = "insert into PHIEUNHAP_TP values('" + maphieu + "','" + ngaynhap + "','" + maNPP + "' ,'" + maNV + "' ,'" + 0 + "')";
            object data = DataProvider.Instance.ExecuteNonQuery(sql); 
        }

        public void ThemCTNH(string maphieu, string maTP, int soluong, int dongia)
        {
            string sql = "insert into CT_PHIEUNHAP_TP values('" + maphieu + "','" + maTP + "','" + soluong + "','" + dongia + "')";
            object data = DataProvider.Instance.ExecuteNonQuery(sql);
        }

        public DataTable HienthiCTHD(string maphieu,string maTP)
        {
            string sql = "select * from CT_PHIEUNHAP_TP where MAPHIEU= '" + maphieu + "' and MATP='"+maTP+"'";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            return data;
        }

        public DataTable loadcomboboxNhaPhanPhoi()
        {
            string sql = "select MANPP from NHAPHANPHOI";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            return data;

        }

        public DataTable loadMAPHIEU(string maphieu)
        {
            string sql = "select count(*) as SoLuong from PHIEUNHAP_TP where MAPHIEU='" + maphieu+"'";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            return data;

        }

        public DataTable loadMATP(string maphieu,string maTP)
        {
            string sql = "select count(*) as SoLuong from CT_PHIEUNHAP_TP where MAPHIEU='" + maphieu + "' and MATP='"+maTP+"'";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            return data;

        }

        public DataTable loadcomboboxNhanVien()
        {
            string sql = "select MANV from NHANVIEN";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            return data;
        }
        public DataTable loadcomboboxThucpham()
        {
            string sql = "select MATP from THUCPHAM";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            return data;
        }
        public string tongtien(string MAPHIEU)
        {
            string sql = "SELECT THANHTIEN from PHIEUNHAP_TP  WHERE MAPHIEU='"+MAPHIEU+"'";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            string dt = data.Columns[0].Table.Rows[0].ItemArray[0].ToString();
            return dt;
        }

        public DataTable combobox_thucpham( string manpp)
        {
            string sql = " select MATP from THUCPHAM WHERE MANPP='"+ manpp +"'";
            DataTable data= DataProvider.Instance.ExecuteQuery(sql);
            return data;
        }

        public string textbox_dongia(string matp)
        {
            string sql = " select GIA from THUCPHAM WHERE MATP='" + matp + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            string dt = data.Columns[0].Table.Rows[0].ItemArray[0].ToString();
            return dt;
        }
    }
}
