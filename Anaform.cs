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
    }
}
