using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Fast_Food_Restaurant.DAO
{
    class fPhieuBanHangDAO
    {
        private static fPhieuBanHangDAO instance;

        public static fPhieuBanHangDAO Instance
        {
            get { if (instance == null) instance = new fPhieuBanHangDAO(); return instance; }

            private set { instance = value; }
        }
        private fPhieuBanHangDAO() { }

        public void ThemHoaDonBanHang(string maHD, string maNV, string maBA, DateTime ngaynhap)
        {
            string sql;
            if (maBA!="")
            {
                 sql = "insert into HOADON values('" + maHD + "','" + ngaynhap + "','" + maNV + "' ,'" + maBA + "' ,'" + 0 + "')";
            }
            else
            {
                 sql = "insert into HOADON values('" + maHD + "','" + ngaynhap + "','" + maNV + "' , NULL ,'" + 0 + "')";
            }
            object data = DataProvider.Instance.ExecuteNonQuery(sql);
        }

        public void ThemCTHD(string maHD, string maMA, int soluong, int dongia)
        {
            string sql = "insert into CTHD values('" + maHD + "','" + maMA + "','" + soluong + "','" + dongia + "')";
            object data = DataProvider.Instance.ExecuteNonQuery(sql);
        }

        public DataTable loadMAHD(string maHD)
        {
            string sql = "select count(*) as SoLuong from HOADON where MAHD='" + maHD + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            return data;
        }

        public DataTable countMAMA(string maHD, string maMA)
        {
            string sql = "select count(*) as SoLuong from CTHD where MAHD='" + maHD + "' and MAMA='"+maMA+"'";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            return data;

        }
        public DataTable loadcomboboxNhanVien()
        {
            string sql = "select MANV from NHANVIEN";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            return data;
        }

        
       public DataTable loadcomboboxMonAn()
        {
            string sql = "select MAMA from MONAN";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            return data;
        }

        public DataTable HienthiCTHD(string maHD, string maMA)
        {
            string sql = "select * from CTHD where MAHD= '" + maHD + "' and MAMA='" + maMA + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            return data;
        }
        public string textbox_dongia(string maMA)
        {
            string sql = " select GIATIEN from MONAN WHERE MAMA='" + maMA + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            string dt = data.Columns[0].Table.Rows[0].ItemArray[0].ToString();
            return dt;
        }

        public string tongtien(string MAHD)
        {
            string sql = "SELECT THANHTIEN from HOADON  WHERE MAHD='" + MAHD + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            string dt = data.Columns[0].Table.Rows[0].ItemArray[0].ToString();
            return dt;
        }
    }
}
