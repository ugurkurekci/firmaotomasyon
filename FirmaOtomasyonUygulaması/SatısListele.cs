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
    public partial class SatısListele : Form
    {
        satisYapilan yapsatis = new satisYapilan();
        public SatısListele()
        {
            InitializeComponent();
        }

        private void SatısListele_Load(object sender, EventArgs e)
        {

        }
        void databaseoperation()
        {
            using (firmaEntities satislistesi = new firmaEntities())
            {
                dataGridView1.DataSource = satislistesi.satisYapilans.ToList<satisYapilan>();
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
                yapsatis.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
                using (firmaEntities firmalistesi = new firmaEntities())
                {
                    yapsatis = firmalistesi.satisYapilans.Where(x => x.id == yapsatis.id).FirstOrDefault();

                    alıcıadıtxb.Text = yapsatis.alıcıAd;
                    alıcısoyadtxb.Text = yapsatis.alıcıSoyad;
                    alınanürüntxb.Text = yapsatis.alınanÜrün;

                    fiyattxb.Text = Convert.ToInt32(yapsatis.fiyat).ToString();
                    miktartxb.Text = Convert.ToInt32(yapsatis.miktar).ToString();
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
                    var entry = db.Entry(yapsatis);
                    if (entry.State == EntityState.Detached)
                        db.satisYapilans.Attach(yapsatis);
                    db.satisYapilans.Remove(yapsatis);
                    db.SaveChanges();
                    databaseoperation();
                    MessageBox.Show("Kayıt Silindi.");


                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            delete();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            delete();
        }

        void update()
        {
            using (firmaEntities db = new firmaEntities())
            {
                yapsatis = db.satisYapilans.Where(x => x.id == yapsatis.id).FirstOrDefault();
                yapsatis.alıcıAd = alıcıadıtxb.Text.Trim();
                yapsatis.alıcıSoyad = alıcısoyadtxb.Text.Trim();
                yapsatis.alınanÜrün = alınanürüntxb.Text.Trim();

                yapsatis.fiyat = Convert.ToInt32(fiyattxb.Text);
                yapsatis.miktar = Convert.ToInt32(miktartxb.Text);
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
                        doc.Add(new iTextSharp.text.Paragraph("ALICI ISIM :" + alıcıadıtxb.Text));
                        doc.Add(new iTextSharp.text.Paragraph("ALICI SOYISIM :" + alıcısoyadtxb.Text));
                        doc.Add(new iTextSharp.text.Paragraph("ALINAN URUN :" + alınanürüntxb.Text));
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


