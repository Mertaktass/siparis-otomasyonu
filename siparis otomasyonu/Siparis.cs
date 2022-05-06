using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace siparis_otomasyonu
{
    class Siparis
    {
      
        public Pizza Pizza { get; set; }
        public int Adet { get; set; }
        public decimal ToplamTutar { get; set; }

        public override string ToString()
        {

            string spr = "";
            spr += Pizza.Ebati.Adi + ",";
            spr += Pizza.Adi + ",";
            foreach (string mlz in Pizza.Malzemeler)
            {
                spr += string.Format("{0},", mlz);
            }
            spr += string.Format("{0} x {1} = {2}", Adet, Pizza.Tutar, Adet * Pizza.Tutar);
            
            return spr;
            
        }
    }
}
