using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYBANHANG.DAO
{
   public class QuanLyBanHangDAO
    {
        private QuanLyBanHangDAO()        { }

        private static QuanLyBanHangDAO instance;
        //private object _gioiTinh;

        public static QuanLyBanHangDAO Instance
        {
            get
            {
                if (instance == null) instance = new QuanLyBanHangDAO();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }
        #region  tab DanhSachNhanVien 
        public DataTable Load_DSNV()
        {
                string query = "SELECT * FROM NHANVIEN ";
                return DataProvider.Instance.ExecuteQuery(query);
        }


        public void ThemNVMoi(string _manv,string _ten,string _sdt,string _ngayvl,string _chucvu, string _ngaySinh, string _gioiTinh)
        {
            string query = string.Format("exec spInsertIntoNhanVien @MaNV=N'{0}', @Hoten=N'{1}', @SDT=N'{2}', @NgayVL=N'{3}',@Chucvu=N'{4}', @NgaySinh=N'{5}', @Gioitinh=N'{6}'",_manv,_ten,_sdt,_ngayvl,_chucvu,_ngaySinh,_gioiTinh);
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














        #endregion
    }
}
