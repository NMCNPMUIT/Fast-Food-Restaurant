using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fast_Food_Restaurant.DTO;
using System.Data;
namespace Fast_Food_Restaurant.DAO2
{
    public class NhaPhanPhoiDAO
    {
        private static NhaPhanPhoiDAO instance;

        public static NhaPhanPhoiDAO Instance
        {
            get { if (instance == null) instance = new NhaPhanPhoiDAO(); return NhaPhanPhoiDAO.instance; }
            private set { NhaPhanPhoiDAO.instance = value; }
        }

        private NhaPhanPhoiDAO() { }

        public List<NhaPhanPhoi> GetListNhaPhanPhoi()
        {
            List<NhaPhanPhoi> list = new List<NhaPhanPhoi>();

            string query = "select * from NHAPHANPHOI";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                NhaPhanPhoi NhaPhanPhoi = new NhaPhanPhoi(item);
                list.Add(NhaPhanPhoi);
            }
           return list;
        }

        public NhaPhanPhoi GetNhaPhanPhoiByID(string id)
        {
            NhaPhanPhoi NhaPhanPhoi = null;

            string query = string.Format("select * from NHAPHANPHOI where MANPP = N'{0}' " , id);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                NhaPhanPhoi = new NhaPhanPhoi(item);
                return NhaPhanPhoi;
            }

            return NhaPhanPhoi;
        }
    }
}
