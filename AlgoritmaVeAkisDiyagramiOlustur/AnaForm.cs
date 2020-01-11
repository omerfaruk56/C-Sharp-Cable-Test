using AlgoritmaVeAkisDiyagramiOlustur.AkisDiyagramlari;
using AlgoritmaVeAkisDiyagramiOlustur.Soketler;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace AlgoritmaVeAkisDiyagramiOlustur
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }
        Basla b = new Basla();
        Islem i = new Islem();
        Kosul k = new Kosul();
        Soket soket;
        SoketTest SoketTst;

        private void Form1_Load(object sender, EventArgs e)
        {
            soket = new Soket();
            soket.soketleriListele(listBoxSoketler);
            listBoxSoketler.SelectedIndex = 0;

        }

        //--------------------Akış Diyagramları--------------------------//

        private void pictBasla_Click(object sender, EventArgs e)
        {
            b.pictBaslaOlustur(this);
        }

        private void pictIslem_Click(object sender, EventArgs e)
        {
            i.pictIslemOlustur(this);
        }

        private void pictKosul_Click(object sender, EventArgs e)
        {
            k.pictKosulOlustur(this);
        }

        //----------------------Form Kapatma------------------------------//

        private void AnaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Çıkış yapmak istediğinizden emin misiniz ?", "Programı Kapat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Environment.Exit(0);
            else
                e.Cancel = true;
        }

        //------------------------Soketler-------------------------------//

        private void toolStripButtonSoketEkle_Click(object sender, EventArgs e)
        {
            soket.soketResmiEkle(listBoxSoketler);
        }

        private void listBoxSoketler_SelectedIndexChanged(object sender, EventArgs e)
        {
            Soket s = new Soket(Application.StartupPath + "\\" + listBoxSoketler.SelectedItem.ToString(), this, listBoxSoketler.SelectedItem.ToString());
            s.soketOlustur();
            SoketTst = new SoketTest(flowLayoutPanelOzellikler);
            SoketTst.gsrOku(listBoxSoketler);
            lblBilgilendirme.Text = SoketTst.bilgilendirme;
        }

        private void toolStripButtonSoketiTestEt_Click(object sender, EventArgs e)
        {
            SoketTst = new SoketTest(flowLayoutPanelOzellikler, this);
            SoketTst.soketTestEt();
        }

        private void toolStripButtonCiktiKlasor_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.StartupPath);
        }

        private void tümNesmeleriSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            soket = new Soket(this);
            soket.formTemizle();
        }

        private void SagTikSoketiSil_Click(object sender, EventArgs e)
        {
            soket = new Soket(Application.StartupPath + "\\" + listBoxSoketler.Text, this, listBoxSoketler.Text);
            soket.soketResmiSil(listBoxSoketler);
        }
    }
}