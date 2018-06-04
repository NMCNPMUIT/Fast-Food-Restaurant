using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Fast_Food_Restaurant.DAO
{
    public class fDoanhthuDAO
    {
        private static fDoanhthuDAO instance;

        public static fDoanhthuDAO Instance
        {
            get{ if (instance == null) instance = new fDoanhthuDAO(); return instance;}

            set{instance = value; }
        }

        public DataTable thongke(string  thang,string nam)
        {
            string sql = "";
            if (thang!="" && nam!="")
            {
                sql = "select DAY(NGHD) as ngày, sum(THANHTIEN) as Tổng from HOADON where month(NGHD)= '" + thang + "' and year(NGHD)='" + nam + "' group By day(NGHD)";
            }
            else if (thang=="" && nam!="")
            {
                sql = "select month(NGHD) as tháng, sum(THANHTIEN) as Tổng from HOADON where  year(NGHD)='" + nam + "' group By month(NGHD)";
            }
           
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            return data;
        }
        public DataTable thongketheoSP(string ngay, string thang,string nam)
        {
            string Sql="";
            if (ngay!="" && thang!="" && nam!="")
            {
                Sql = "select CTHD.MAMA as 'mã món ăn', sum(HOADON.THANHTIEN) as tổng from HOADON join CTHD on HOADON.MAHD = CTHD.MAHD where day(HOADON.NGHD) = '" + ngay + "' and MONTH(HOADON.NGHD) = '" + thang + "' and year(HOADON.NGHD) = '" + nam + "' group By CTHD.MAMA";
            }
            if (ngay == "" && thang != "" && nam != "")
            {
                Sql = "select CTHD.MAMA as 'mã món ăn', sum(HOADON.THANHTIEN) as tổng from HOADON join CTHD on HOADON.MAHD = CTHD.MAHD where  MONTH(HOADON.NGHD) = '" + thang + "' and year(HOADON.NGHD) = '" + nam + "' group By CTHD.MAMA";
            }
            if (ngay == "" && thang == "" && nam != "")
            {
                Sql = "select CTHD.MAMA as 'mã món ăn', sum(HOADON.THANHTIEN) as tổng from HOADON join CTHD on HOADON.MAHD = CTHD.MAHD where year(HOADON.NGHD) = '" + nam + "' group By CTHD.MAMA";
            }
            DataTable data = DataProvider.Instance.ExecuteQuery(Sql);
            return data;
        }
    }
}
