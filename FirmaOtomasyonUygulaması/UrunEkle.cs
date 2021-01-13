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
    public partial class UrunEkle : Form
    {
        ürünKayit ürünekle = new ürünKayit();
        public UrunEkle()
        {
            InitializeComponent();
        }

        private void UrunEkle_Load(object sender, EventArgs e)
        {

        }

        private void kytbutton_Click(object sender, EventArgs e)
        {
            try
            {
                ürünekle.ürünadi = ürünadıtxb.Text.Trim();
                ürünekle.barkotno = Convert.ToInt32(barkottxb.Text);
                ürünekle.fiyat = Convert.ToInt32(fiyattxb.Text);
                ürünekle.miktar = Convert.ToInt32(miktartxb.Text);
                MessageBox.Show("Ürün Eklendi");

            }
            catch (Exception)
            {

                MessageBox.Show("Ürün eklenemedi. Bu hatayı alıyorsanız ; sayı biçiminde belirtilen kısma yazı yazmışsınızdır. LÜTFEN DÜZELTİN");
            }
            using (firmaEntities db = new firmaEntities())
            {
                if (ürünekle.id == 0)
                {
                    db.ürünKayit.Add(ürünekle);
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
