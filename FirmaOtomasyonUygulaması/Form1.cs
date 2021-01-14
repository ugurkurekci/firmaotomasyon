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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            lblSaatt.Text = DateTime.Now.ToLongTimeString();
            lblTarihh.Text = DateTime.Now.ToLongDateString();
        }


        private void MusteriEkle_Click_1(object sender, EventArgs e)
        {
            MusteriEkle musteriekle = new MusteriEkle();
            musteriekle.Show();
            this.Hide();
        }

        private void MusteriListele_Click_1(object sender, EventArgs e)
        {
            MusteriListele musteri = new MusteriListele();
            musteri.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            UrunEkle urunEkle = new UrunEkle();
            urunEkle.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            urunListele urunListele = new urunListele();
            urunListele.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            satisYap satis = new satisYap();
            satis.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            SatısListele listele = new SatısListele();
            listele.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            PersonelEkle personel = new PersonelEkle();
            personel.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            PersonelListele listele = new PersonelListele();
            listele.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hakkinda hakkinda = new Hakkinda();
            hakkinda.Show();
            this.Hide();

        }
    }
}
