using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirmaOtomasyonUygulaması
{
    public partial class MusteriEkle : Form
    {
        müsteriKayit müsteriekle = new müsteriKayit();
        public MusteriEkle()
        {
            InitializeComponent();
        }

        private void MusteriEkle_Load(object sender, EventArgs e)
        {
            
            telefontxb.MaxLength = 14;
        }

        private void kytbutton_Click(object sender, EventArgs e)
        {
            try
            {
                müsteriekle.isim = isimtxb.Text.Trim();
                müsteriekle.soyisim = soyisimtxb.Text.Trim();
                müsteriekle.email = mailtxb.Text.Trim();
                müsteriekle.telefonNo = Convert.ToInt32(telefontxb.Text);
                MessageBox.Show("Müşteri Eklendi.");
            }
            catch (Exception)
            {

                MessageBox.Show(" TELEFON NUMARASI SAYI BİÇİMİNDE OLMALIDIR");
            }

            using (firmaEntities db = new firmaEntities())
            {
                if (müsteriekle.id==0)
                {
                    db.müsteriKayit.Add(müsteriekle);
                }
               
                db.SaveChanges();
                         
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();
            this.Hide();
        }
    }
}
