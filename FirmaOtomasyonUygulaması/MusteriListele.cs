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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace FirmaOtomasyonUygulaması
{

    public partial class MusteriListele : Form
    {
        müsteriKayit Firmamüsteri = new müsteriKayit();
        public MusteriListele()
        {
            InitializeComponent();
        }

        private void MusteriListele_Load(object sender, EventArgs e)
        {

        }

        private void kytbutton_Click(object sender, EventArgs e)
        {
            databaseekranagetir();
            dataGridView1.Visible = Enabled;
        }
        void databaseekranagetir()
        {
            using (firmaEntities Firmamüsteri = new firmaEntities())
            {
                dataGridView1.DataSource = Firmamüsteri.müsteriKayit.ToList<müsteriKayit>();
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            dataveritexboxgetir();

        }
        void dataveritexboxgetir()
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                Firmamüsteri.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
                using (firmaEntities müsteri = new firmaEntities())
                {
                    Firmamüsteri = müsteri.müsteriKayit.Where(x => x.id == Firmamüsteri.id).FirstOrDefault();

                    isimtxb.Text = Firmamüsteri.isim;
                    soyisimtxb.Text = Firmamüsteri.soyisim;
                    mailtxb.Text = Firmamüsteri.email;
                    telefontxb.Text = Convert.ToInt32(Firmamüsteri.telefonNo).ToString();
                }
            }
        }
        void delete()
        {
            if (MessageBox.Show("Kaydı silmek istediğinize Emin Misiniz?", "KAYIT SİLME EKRANI UYARI", MessageBoxButtons.YesNo) == DialogResult.Yes)
                using (firmaEntities db = new firmaEntities())
                {
                    var entry = db.Entry(Firmamüsteri);
                    if (entry.State == EntityState.Detached)
                        db.müsteriKayit.Attach(Firmamüsteri);
                    db.müsteriKayit.Remove(Firmamüsteri);
                    db.SaveChanges();
                    databaseekranagetir();
                    MessageBox.Show("Kayıt Silindi.");


                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            delete();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            guncelle();
        }

        void guncelle()
        {
            using (firmaEntities db = new firmaEntities())
            {
                Firmamüsteri = db.müsteriKayit.Where(x => x.id == Firmamüsteri.id).FirstOrDefault();
                Firmamüsteri.isim = isimtxb.Text.Trim();
                Firmamüsteri.soyisim = soyisimtxb.Text.Trim();
                Firmamüsteri.email = mailtxb.Text.Trim();
                Firmamüsteri.telefonNo = Convert.ToInt32(telefontxb.Text);
                db.SaveChanges();
                databaseekranagetir();
                MessageBox.Show("Güncellendi");
            }

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
                        doc.Add(new iTextSharp.text.Paragraph("ISIM :"+ isimtxb.Text));
                        doc.Add(new iTextSharp.text.Paragraph("SOYISIM :"+soyisimtxb.Text));
                        doc.Add(new iTextSharp.text.Paragraph("MAIL :" + mailtxb.Text));
                        doc.Add(new iTextSharp.text.Paragraph("TELEFON :" + telefontxb.Text));
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();
            this.Hide();
        }
    }

}
