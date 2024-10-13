using System;
using System.Windows.Forms;

namespace DiplPaswKeys
{
    public partial class Anaform : Form
    {
        public Anaform()
        {
            InitializeComponent();
        }
        private void Anaform_Load(object sender, EventArgs e)
        {
            hoşgeldinizToolStripMenuItem.Text += CLS.Myglobals.Aktif_kullanici_adi; //giren kişiyye dinamik olarak hoşgeldin der
        }
        private void Griddoldur()
        {
            dataGridView1.DataSource = CLS.SQLConnectionClass.Table("select * from SIFRELER");
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Anaform_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void hoşgeldinizToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            MYMODELS.SIFRELER.SIFRE sıf = new MYMODELS.SIFRELER.SIFRE()
            {
                sif_RECno = Convert.ToInt32(txtKayitNo.Text),
                sif_kul_adi_mail = txtKullaniciAdiMail.Text,
                sif_kul_sifre = txtSifre.Text,
                sif_notlar = txtNotlar.Text,
                sif_site_adi = txtSiteAdi.Text,
                sif_site_url = txtSiteUrl.Text,


            };
            txtKayitNo.Text = MYMODELS.SIFRELER.SIFRE_Kaydet(sıf).ToString();
            Griddoldur();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            MYMODELS.SIFRELER.SIFRE_Sil(Convert.ToInt32(txtKayitNo.Text));
            Griddoldur();
        }
    }
}
