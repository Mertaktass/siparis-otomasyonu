using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace siparis_otomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            Ebat kucuk = new Ebat { Adi = "Küçük", Carpan = 1 };
            Ebat orta = new Ebat { Adi = "Orta", Carpan = 1.25 };
            Ebat buyuk = new Ebat { Adi = "Büyük", Carpan = 1.75 };

            cmbebat.Items.Add(kucuk);
            cmbebat.Items.Add(orta );
            cmbebat.Items.Add(buyuk);


            Pizza klasik = new Pizza { Adi = "Klasik", Fiyat = 14 };
            Pizza karisik = new Pizza { Adi = "Karisik", Fiyat = 18 };
            Pizza turkish = new Pizza { Adi = "Turkish", Fiyat = 20 };
            Pizza akdeniz = new Pizza { Adi = "Akdeniz", Fiyat = 21 };
            Pizza super = new Pizza { Adi = "Süper", Fiyat = 25 };

            listpizzalar.Items.Add(klasik);
            listpizzalar.Items.Add(karisik );
            listpizzalar.Items.Add(turkish );
            listpizzalar.Items.Add(akdeniz );
            listpizzalar.Items.Add(super );

            string[] kelimeler = { "Klasik", "karisik", "Turkish", "akdeniz" };
            var bykkcharf = from k in kelimeler
                            select new { bykharf = k.ToUpper(), kck = k.ToLower() };
       foreach (var s in bykkcharf )
       {
           Console.WriteLine("büyükharf:{0},küçükharf:{1}", s.bykharf, s.kck);
       }
         }
        Siparis s;
        
            
        private void btnhesapla_Click(object sender, EventArgs e)
        {
            Pizza p =(Pizza ) listpizzalar.SelectedItem;
            p.Ebati = (Ebat)cmbebat.SelectedItem;
            p.Malzemeler = new List<string>();
            foreach (CheckBox  ctrl in groupBox1 .Controls  )
            {
                if (ctrl .Checked )
                {
                    p.Malzemeler.Add(ctrl.Text);
                }
            }
            decimal tutar = nudadet.Value * p.Tutar;
            txtTutar.Text = tutar.ToString();
            s = new Siparis();
            s.Pizza = p;
            s.Adet =(int) nudadet.Value;
        }
        
        private void btnSepeteekle_Click(object sender, EventArgs e)
        {
          if (s != null )
          {
              listSepet.Items.Add(s);
          }
        }

        public delegate void MesajVerHandler(string mesaj);
        public event MesajVerHandler mesajgönderildi;
        void kutudamesajver(string msg)
        {
            MessageBox.Show(msg);
        }
        
        private void btnSiparisonay_Click(object sender, EventArgs e)
        {
            MesajVerHandler mesajverici = new MesajVerHandler(kutudamesajver);

            mesajverici.Invoke("sipariş onaylandı");
        }

       
    }
}
