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

    public partial class PersonelListele : Form
    {
        yetkiliData yetkilipersonel = new yetkiliData();
        public PersonelListele()
        {
            InitializeComponent();
        }

        private void PersonelListele_Load(object sender, EventArgs e)
        {


        }
        void databaseoperation()
        {
            using (firmaEntities Firmamüsteri = new firmaEntities())
            {
                dataGridView1.DataSource = Firmamüsteri.yetkiliDatas.ToList<yetkiliData>();
            }
        }

        private void kytbutton_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = Enabled;
            databaseoperation();
        }
        void datatextboxoutput()
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                yetkilipersonel.tc = Convert.ToInt32(dataGridView1.CurrentRow.Cells["tc"].Value);
                using (firmaEntities personel = new firmaEntities())
                {
                    yetkilipersonel = personel.yetkiliDatas.Where(x => x.tc == yetkilipersonel.tc).FirstOrDefault();

                    isimtxb.Text = yetkilipersonel.yetkiliAdı;
                    soyisimtxb.Text = yetkilipersonel.yetkiliSoyadı;
                    maastxb.Text = Convert.ToInt32(yetkilipersonel.yetkiliMaası).ToString();
                    isbaslangıctxb.Text = yetkilipersonel.yetkiliİsBaslangic;
                    issonlandirmatxb.Text = yetkilipersonel.yetkiliisBitis;
                }
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            datatextboxoutput();
        }
        void delete()
        {
            if (MessageBox.Show("Kaydı silmek istediğinize Emin Misiniz?", "KAYIT SİLME EKRANI UYARI", MessageBoxButtons.YesNo) == DialogResult.Yes)
                using (firmaEntities db = new firmaEntities())
                {
                    var entry = db.Entry(yetkilipersonel);
                    if (entry.State == EntityState.Detached)
                        db.yetkiliDatas.Attach(yetkilipersonel);
                    db.yetkiliDatas.Remove(yetkilipersonel);
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
                yetkilipersonel = db.yetkiliDatas.Where(x => x.tc == yetkilipersonel.tc).FirstOrDefault();
                yetkilipersonel.yetkiliAdı = isimtxb.Text.Trim();
                yetkilipersonel.yetkiliSoyadı = soyisimtxb.Text.Trim();
                yetkilipersonel.yetkiliMaası = Convert.ToInt32(maastxb.Text);
                yetkilipersonel.yetkiliİsBaslangic = isbaslangıctxb.Text.Trim();
                yetkilipersonel.yetkiliisBitis = issonlandirmatxb.Text.Trim();
                db.SaveChanges();
                databaseoperation();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            update();
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
                        doc.Add(new iTextSharp.text.Paragraph("ISIM :" + isimtxb.Text));
                        doc.Add(new iTextSharp.text.Paragraph("SOYISIM :" + soyisimtxb.Text));
                        doc.Add(new iTextSharp.text.Paragraph("MAAŞ :" + maastxb.Text));
                        doc.Add(new iTextSharp.text.Paragraph("İŞ BAŞLANGIÇ TARİHİ :" + isbaslangıctxb.Text));
                        doc.Add(new iTextSharp.text.Paragraph("İŞ SONLANDIRMA TARİHİ :" + issonlandirmatxb.Text));
                        MessageBox.Show("PDF OLUŞTURULDU");
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();
            this.Hide();
        }
    }
}

