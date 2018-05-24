using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Fast_Food_Restaurant.DAO2
{
    class FastFoodDAO
    {
        private FastFoodDAO() { }

        private static FastFoodDAO instance;

        public static FastFoodDAO Instance
        {
            get
            {
                if (instance == null) instance = new FastFoodDAO();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }
        #region tab QuanLyNhanVien
        public DataTable Load_DSNV()
        {
            string query = "SELECT * FROM NHANVIEN ";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public void ThemNV(string _manv, string _ten, string _sdt, string _ngayvl, string _chucvu, string _ngaySinh, string _gioiTinh)
        {
            string query = string.Format("exec spInsertIntoNhanVien @MaNV=N'{0}', @Hoten=N'{1}', @SDT=N'{2}', @NgayVL=N'{3}',@Chucvu=N'{4}', @NgaySinh=N'{5}', @Gioitinh=N'{6}'", _manv, _ten, _sdt, _ngayvl, _chucvu, _ngaySinh, _gioiTinh);
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void SuaNV(string _manv, string _ten, string _sdt, string _ngayvl, string _chucvu, string _ngaySinh, string _gioiTinh)
        {
            string query = string.Format("exec spAlterNV @MANV = N'{0}' , @Hoten=N'{1}', @SDT=N'{2}', @NgayVL=N'{3}',@Chucvu=N'{4}', @NgaySinh=N'{5}', @Gioitinh=N'{6}'", _manv, _ten, _sdt, _ngayvl, _chucvu, _ngaySinh, _gioiTinh);
            // string query = string.Format("Exec spAlterNV @_manv , @_ten , @_sdt , @_ngayvl , @_chucvu , @_ngaySinh , @_gioiTinh   ");
            DataProvider.Instance.ExecuteQuery(query);  //, new object[] { _ten, _sdt, _ngayvl, _chucvu, _ngaySinh, _gioiTinh });
        }

        public void XoaHoaDonKhoiCTHD(string _MaHD)
        {
            string query = string.Format("DELETE CTHD WHERE MaHD=(SELECT MaHD FROM HOADON WHERE MAHD=N'{0}' )", _MaHD);
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public DataTable Load_MonAn()
        {
            string query = "SELECT * FROM MONAN";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable Load_NPP()
        {
            string query = "SELECT * FROM NHAPHANPHOI";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public void ThemMONAN(string mama, string tenma, string giatien)
        {
        
             string query = string.Format("exec spInsertIntoMonAn @MAMA = N'{0}' , @TENMA = N'{1}' , @GIATIEN = N'{2}'  ", mama , tenma , giatien);
            DataProvider.Instance.ExecuteQuery(query);
        }
        public void AlterMONAN(string mama, string tenma, string giatien)
        {
            string query = string.Format("Exec spAlterMONAN @TENMA = N'{1}' , @GIATIEN = N'{2}' , @MAMA = N'{0}' ", mama, tenma, giatien);
            DataProvider.Instance.ExecuteQuery(query);
        }
        public void ThemNPP(string manpp, string tennpp, string diachi)
        {
            string query = string.Format("exec spInsertIntoNPP @MANPP = N'{0}' , @TENNPP = N'{1}' , @DIACHI = N'{2}'  ", manpp, tennpp, diachi);
            DataProvider.Instance.ExecuteQuery(query);
        }
        public void AlterNPP(string manpp, string tennpp, string diachi)
        {
            string query = string.Format("exec spAlterNPP @MANPP = N'{0}' , @TENNPP = N'{1}' , @DIACHI = N'{2}'  ", manpp, tennpp, diachi);
            DataProvider.Instance.ExecuteQuery(query);
        }
        public List<string> getTenNPPFromDataBase()
        {
            string query = "select TENNPP from dbo.NHAPHANPHOI";
            return DataProvider.Instance.ExecuteReaderListString(query);

        }
        
        public DataTable Load_THUCPHAM()
        {
            string query = "SELECT * FROM THUCPHAM";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public void ThemTHUCPHAM(string matp, string tentp, string gia, string donvi, string manpp)
        {
            string query = string.Format("INSERT INTO dbo.THUCPHAM(MATP, TENTP, GIA, DONVI, MANPP) VALUES(N'{0}' , N'{1}' , N'{2}' , N'{3}' , N'{4}')", matp, tentp, gia, donvi, manpp);
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void AlterTHUCPHAM(string manpp, string tentp, string gia, string donvi, string matp)
        {
            string query = string.Format("UPDATE dbo.THUCPHAM SET MANPP =N'{0}' ,TENTP =N'{1}' ,GIA =N'{2}' ,DONVI =N'{3}'  WHERE MATP =N'{4}' ", manpp, tentp, gia, donvi, matp);
            //string query = string.Format("exec spAlterIntoTHUCPHAM @MATP = N'{0}' , @TENTP = N'{1}' , @GIA = N'{2}' , @DONVI =N'{3}' , @MANPP = N'{4}'  ", matp, tentp, gia, donvi,manpp);
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void deleteCT_PHIEUNHAPTPbyTHUCPHAM_ID(string id)
        {
            string query = string.Format("DELETE CT_PHIEUNHAP_TP where MATP = N'{0}'", id);
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void deleteTHUCPHAM(string matp)
        {
            deleteCT_PHIEUNHAPTPbyTHUCPHAM_ID(matp);
            string query = string.Format("Delete THUCPHAM where matp =N'{0}' ", matp);
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        #endregion
    }
}
