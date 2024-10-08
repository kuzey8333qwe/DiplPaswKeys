using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiplPaswKeys
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            DataTable dt = CLS.SQLConnectionClass.Table("SELECT kul_ad FROM KULLANICILAR WHERE kul_kod ='" + txt_kullanici_adi.Text+"' and kul_pw='"+txt_şifre.Text+"'");
            if (dt.Rows.Count>0)
            {
                CLS.Myglobals.Aktif_kullanici_adi = dt.Rows[0]["kul_ad"].ToString();
                CLS.Myglobals.Aktif_kullanici_kodu =txt_kullanici_adi.Text;

                this.Hide(); 
                new Anaform().ShowDialog();

            }
            else 
            {
                MessageBox.Show("Bilgiler Hatalı");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
