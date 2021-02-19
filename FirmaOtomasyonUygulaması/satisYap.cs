using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirmaOtomasyonUygulaması
{
    public partial class satisYap : Form
    {
        satisYapilan yapsatis = new satisYapilan();


        public satisYap()
        {
            InitializeComponent();
        }

        private void satisYap_Load(object sender, EventArgs e)
        {
            alıcıadıliste();
            alıcısoyadıliste();
            alınanürünliste();
            alınanürünfiyat();
            alınanmiktar();
            

        }

        private void kytbutton_Click(object sender, EventArgs e)
        {
            try
            {
                yapsatis.alıcıAd = comboBox1.Text.Trim();
                yapsatis.alıcıSoyad = comboBox2.Text.Trim();
                yapsatis.alınanÜrün = comboBox3.Text.Trim();
                yapsatis.fiyat = Convert.ToInt32(comboBox4.Text);
                yapsatis.miktar = Convert.ToInt32(comboBox5.Text);
               
                
                
                MessageBox.Show( "SATIŞ GERÇEKLEŞTİRİLDİ.");

            }
            catch (Exception)
            {

                MessageBox.Show("EKSİK BİLGİ GİRDİNİZ.LÜTFEN DÜZELTİN");
            }
            using (firmaEntities db = new firmaEntities())
            {
                if (yapsatis.id == 0)
                {
                    db.satisYapilan.Add(yapsatis);
                }
                db.SaveChanges();
            }
            button1.Visible = Enabled;
        }





        void alıcıadıliste()
        {
            müsteriKayit müsteriekle = new müsteriKayit();
            List<müsteriKayit> müsteri = new List<müsteriKayit>();
            using (firmaEntities firmaEntities = new firmaEntities())
            {
                müsteri = firmaEntities.müsteriKayit.ToList();
            }
            foreach (var x in müsteri)
            {
                comboBox1.Items.Add(x.isim);
            }
        }
        void alıcısoyadıliste()
        {
            müsteriKayit müsteriekle = new müsteriKayit();
            List<müsteriKayit> müsteri = new List<müsteriKayit>();
            using (firmaEntities firmaEntities = new firmaEntities())
            {
                müsteri = firmaEntities.müsteriKayit.ToList();
            }
            foreach (var x in müsteri)
            {
                comboBox2.Items.Add(x.soyisim);
            }

        }
        void alınanürünliste()
        {
            ürünKayit Firmaürün = new ürünKayit();
            List<ürünKayit> ürün = new List<ürünKayit>();
            using (firmaEntities firmaEntities = new firmaEntities())
            {
                ürün = firmaEntities.ürünKayit.ToList();
            }
            foreach (var x in ürün)
            {
                comboBox3.Items.Add(x.ürünadi);
            }
        }
        void alınanürünfiyat()
        {
            ürünKayit Firmaürün = new ürünKayit();
            List<ürünKayit> ürün = new List<ürünKayit>();
            using (firmaEntities firmaEntities = new firmaEntities())
            {
                ürün = firmaEntities.ürünKayit.ToList();
            }
            foreach (var x in ürün)
            {
                comboBox4.Items.Add(x.fiyat);
            }
        }
        void alınanmiktar()
        {
            ürünKayit Firmaürün = new ürünKayit();
            List<ürünKayit> ürün = new List<ürünKayit>();
            using (firmaEntities firmaEntities = new firmaEntities())
            {
                ürün = firmaEntities.ürünKayit.ToList();
            }
            foreach (var x in ürün)
            {
                comboBox5.Items.Add(x.miktar);
            }
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            SatısListele listele = new SatısListele();
            listele.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();
            this.Hide();
        }
    }
}



