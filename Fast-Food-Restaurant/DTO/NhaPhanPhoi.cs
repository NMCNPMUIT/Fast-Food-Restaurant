using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Fast_Food_Restaurant.DTO
{
   public class NhaPhanPhoi
    {
        public NhaPhanPhoi(string idNPP , string tenNPP , string diachi )
        {
            this.IdNPP = idNPP;
            this.TenNPP = tenNPP;
            this.Diachi = diachi;

        }

        public NhaPhanPhoi(DataRow row)
        {
            this.IdNPP = row["MANPP"].ToString();
            this.TenNPP = row["TENNPP"].ToString();
            this.Diachi = row["DIACHI"].ToString();
        }

        private string idNPP;
        
        public string IdNPP
        {
            get { return idNPP; }
            set { idNPP = value; }
        }

        private string tenNPP;

        public string TenNPP
        {
            get { return tenNPP; }
            set { tenNPP = value; }
        }

        private string diachi;
        public string Diachi
        {
            get { return diachi; }
            set { diachi = value; }
        }
    }
}
