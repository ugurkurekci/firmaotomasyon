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
    public partial class Login : Form
    {

        LoginData login = new LoginData();

        public Login()
        {
            InitializeComponent();
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            using (firmaEntities firma = new firmaEntities())
            {
                var giris = firma.LoginData.Where(x => x.username == usernametxb.Text && x.password == passwordtxb.Text).Count();
                if (giris > 0)
                {
                    MessageBox.Show("Başarılı");
                    Form1 form = new Form1();
                    form.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Başarısız");
                    return;
                }
            }




        }
    }
}

