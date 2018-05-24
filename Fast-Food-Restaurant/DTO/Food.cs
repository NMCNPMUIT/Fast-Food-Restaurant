using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Fast_Food_Restaurant.DAO2
{
    public class Food
    {
        public Food(string maTP, string tenTP, string maNPP, float gia, string donvi)
        {
            this.MaTP = maTP;
            this.TenTP = tenTP;
            this.MaNPP = maNPP;
            this.Gia = gia;
            this.Donvi = donvi;
        }

        public Food(DataRow row)
        {
            this.MaTP = row["MATP"].ToString();
            this.TenTP = row["TENTP"].ToString();
            this.MaNPP = row["MANPP"].ToString();
            this.Gia = (float)Convert.ToDouble(row["GIA"].ToString());
            this.Donvi = row["DONVI"].ToString();
    }
        
        private string donvi;

        public string Donvi
        {
        get { return donvi; }
        set { donvi = value; }
    }
        private float gia;

        public float Gia
        {
            get { return gia; }
            set { gia = value; }
        }

        private string maNPP;

        public string MaNPP
        {
            get { return maNPP; }
            set { maNPP = value; }
        }

        private string tenTP;

        public string TenTP
        {
            get { return tenTP; }
            set { tenTP = value; }
        }

        private string maTP;

        public string MaTP
        {
            get { return MaTP; }
            set { MaTP = value; }
        }
    }
}
