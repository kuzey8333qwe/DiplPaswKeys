using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            txtKayitNo.Text = "0";
            hoşgeldinizToolStripMenuItem.Text += CLS.Myglobals.Aktif_kullanici_adi; //giren kişiyye dinamik olarak hoşgeldin der
            Griddoldur(); //form açıldııgnda data griddeki veriler veritabanından çekilsin diye
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
            temizle();
            Griddoldur();
        }

        private void btn_yeni_Click(object sender, EventArgs e)
        {
            txtKayitNo.Text = "0";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txtKayitNo.Text = row.Cells["sif_RECno"].Value.ToString();
                txtKullaniciAdiMail.Text = row.Cells["sif_kul_adi_mail"].Value.ToString();
                txtSifre.Text = row.Cells["sif_kul_sifre"].Value.ToString();
                txtNotlar.Text = row.Cells["sif_notlar"].Value.ToString();
                txtSiteAdi.Text = row.Cells["sif_site_adi"].Value.ToString();
                txtSiteUrl.Text = row.Cells["sif_site_url"].Value.ToString();            //data gridden üstüne tıklanıldııgnda textboxlar dolsun diye
            }
        }
        void temizle()
        {
            txtKayitNo.Text = "";
            txtKullaniciAdiMail.Text = "";
            txtSifre.Text = "";
            txtNotlar.Text = "";
            txtSiteAdi.Text = "";
            txtSiteUrl.Text = "";
        }
        private void btn_temizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
