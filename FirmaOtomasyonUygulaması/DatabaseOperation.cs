using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace FirmaOtomasyonUygulaması
{
    public class DatabaseOperation : MusteriListele
    {
        void databaseoperation()
        {
            using (firmaEntities Firmamüsteri = new firmaEntities())
            {
                DataGridView.DataSource = Firmamüsteri.müsteriKayit.ToList<müsteriKayit>();
            }
        }
    }
}
