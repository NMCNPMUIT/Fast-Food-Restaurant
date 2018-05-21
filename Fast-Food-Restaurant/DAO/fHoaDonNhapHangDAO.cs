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

            set { instance = value; }
        }
        private fHoaDonNhapHangDAO() { }
        public void ThemHoaDonNhapHang( string maphieu,string maNPP, string maNV, DateTimePicker ngaynhap,int tongtien)
        {
            string sql = "insert into PHIEUNHAP_TP values('" + maphieu + "','" + ngaynhap + "','" + maNPP + "' ,'" + maNV + "','" + tongtien + "'";
            int data = DataProvider.Instance.ExecuteNonQuery(sql);
        }

        public void ThemCTHD(string maphieu, string maTP, string soluong, string dongia)
        {
            string sql = "update CT_PHIEUNHAP_TP set where MAPHIEU= '" + maphieu + "' and MATP='" + maTP + "'and SL='" + soluong + "' and DONGIA='" + dongia + "'";
            object data = DataProvider.Instance.ExecuteQuery(sql);
        }


        public DataTable HienthiCTHD(string maphieu, string maTP, string soluong, string dongia)
        {
            string sql = "select * from CT_PHIEUNHAP_TP where MAPHIEU= '" + maphieu + "' and MATP='" + maTP + "'and SL='" + soluong + "' and DONGIA='" + dongia + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            return data;
        }
    }
}
