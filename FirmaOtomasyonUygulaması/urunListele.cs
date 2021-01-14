using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirmaOtomasyonUygulaması
{
    public partial class urunListele : Form
    {
        ürünKayit Firmaürün = new ürünKayit();
        public urunListele()
        {
            InitializeComponent();
        }

        private void urunListele_Load(object sender, EventArgs e)
        {

        }

        void databaseoperation()
        {
            using (firmaEntities Firmamüsteri = new firmaEntities())
            {
                dataGridView1.DataSource = Firmamüsteri.ürünKayit.ToList<ürünKayit>();
            }

        }

        private void kytbutton_Click(object sender, EventArgs e)
        {
            databaseoperation();
            dataGridView1.Visible = Enabled;
        }
        void datatextboxoutput()
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                Firmaürün.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
                using (firmaEntities firmalistesi = new firmaEntities())
                {
                    Firmaürün = firmalistesi.ürünKayit.Where(x => x.id == Firmaürün.id).FirstOrDefault();

                    ürünadıtxb.Text = Firmaürün.ürünadi;
                    barkottxb.Text = Convert.ToInt32(Firmaürün.barkotno).ToString();
                    fiyattxb.Text = Convert.ToInt32(Firmaürün.fiyat).ToString();
                    miktartxb.Text = Convert.ToInt32(Firmaürün.miktar).ToString();
                }
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            datatextboxoutput();
        }
        void delete()
        {
            if (MessageBox.Show("Kaydı silmek istediğinize Emin Misiniz?", "KAYIT SİLME EKRANI UYARI", MessageBoxButtons.YesNo) == DialogResult.Yes)
                using (firmaEntities db = new firmaEntities())
                {
                    var entry = db.Entry(Firmaürün);
                    if (entry.State == EntityState.Detached)
                        db.ürünKayit.Attach(Firmaürün);
                    db.ürünKayit.Remove(Firmaürün);
                    db.SaveChanges();
                    databaseoperation();
                    MessageBox.Show("Kayıt Silindi.");


                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            delete();
        }
        void update()
        {
            using (firmaEntities db = new firmaEntities())
            {
                Firmaürün = db.ürünKayit.Where(x => x.id == Firmaürün.id).FirstOrDefault();
                Firmaürün.ürünadi = ürünadıtxb.Text.Trim();
                Firmaürün.barkotno = Convert.ToInt32(barkottxb.Text);
                Firmaürün.fiyat = Convert.ToInt32(fiyattxb.Text);
                Firmaürün.miktar = Convert.ToInt32(miktartxb.Text);
                db.SaveChanges();
                databaseoperation();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            update();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sf = new SaveFileDialog() { Filter = "PDF File|*.pdf", ValidateNames = true })
            {
                if (sf.ShowDialog() == DialogResult.OK)

                {
                    iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4.Rotate());
                    try
                    {
                        PdfWriter.GetInstance(doc, new FileStream(sf.FileName, FileMode.Create));
                        doc.Open();
                        doc.Add(new iTextSharp.text.Paragraph("URUN ADI :" + ürünadıtxb.Text));
                        doc.Add(new iTextSharp.text.Paragraph("BARKOT NO :" + barkottxb.Text));
                        doc.Add(new iTextSharp.text.Paragraph("FIYAT :" + fiyattxb.Text));
                        doc.Add(new iTextSharp.text.Paragraph("MIKTAR :" + miktartxb.Text));
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        doc.Close();
                    }
                }
            }
        }

    }
}
