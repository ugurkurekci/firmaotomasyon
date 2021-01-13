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
    public partial class PersonelEkle : Form
    {
        yetkiliData personelbilgileri = new yetkiliData();
        public PersonelEkle()
        {
            InitializeComponent();
        }

        private void PersonelEkle_Load(object sender, EventArgs e)
        {

        }

        private void kytbutton_Click(object sender, EventArgs e)
        {
            {
                try
                {
                   
                    personelbilgileri.yetkiliAdı = isimtxb.Text.Trim();
                    personelbilgileri.yetkiliSoyadı = soyisimtxb.Text.Trim();
                    personelbilgileri.yetkiliMaası = Convert.ToInt32(maastxb.Text);
                    personelbilgileri.yetkiliİsBaslangic = isbaslangıctxb.Text.Trim();
                    personelbilgileri.yetkiliisBitis = issonlandirmatxb.Text.Trim();

                    MessageBox.Show("Müşteri Eklendi.");
                }
                catch (Exception)
                {

                    MessageBox.Show("Hatalı İşlem Yapıyorsunuz");
                }

                using (firmaEntities db = new firmaEntities())
                {
                    if (personelbilgileri.tc == 0)
                    {
                        db.yetkiliDatas.Add(personelbilgileri);
                    }

                    db.SaveChanges();

                }
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
