using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace AlgoritmaVeAkisDiyagramiOlustur.Soketler
{
    class SoketTest
    {
        //------------GELEN DEĞERLER---------------------//
        int[] gelenDeger = { 1, 0, 1, 1, 0, 1, 0, 0, 2, 2 };
        //------------------------------------------------//
        ArrayList koordinatlar = new ArrayList();
        int btnPinSayac = 0;
        public string bilgilendirme;
        private FlowLayoutPanel flowPanel;
        private Form frm;
        //------------------------Constructor------------------------------------//
        public SoketTest()
        {

        }

        public SoketTest(FlowLayoutPanel _flowPanel)
        {
            flowPanel = _flowPanel;
        }

        public SoketTest(FlowLayoutPanel _flowPanel, Form _frm)
        {
            flowPanel = _flowPanel;
            frm = _frm;
        }

        //----------------------------------------------------------------------//

        void btnPinOlustur(int toplamPin)
        {
            int i;

            flowPanel.Controls.Clear();

            i = 0;
            for (i = 1; i < toplamPin + 1; i++)
            {
                Button btn = new Button();
                btn.Width = 30;
                btn.Height = 30;
                btn.Name = "btn" + i;
                btn.Text = i.ToString();
                btn.BackColor = Color.White;
                btn.Click += new EventHandler(btnPinClick);
                flowPanel.Controls.Add(btn);
            }
        }

        private void btnPinClick(Object sender, EventArgs e)
        {
            Button b = (Button)sender;

            bilgilendirme = koordinatlar[int.Parse(b.Text) - 1].ToString();

            if (btnPinSayac == 0)
            {
                b.BackColor = Color.Red;
                b.Tag = 0;
            }

            else if (btnPinSayac == 1)
            {
                b.BackColor = Color.Green;
                b.Tag = 1;
            }

            else if (btnPinSayac == 2)
            {
                b.BackColor = Color.White;
                b.Tag = 2;
            }

            else if (btnPinSayac == 3)
            {
                btnPinSayac = 0;
                b.BackColor = Color.Red;
                b.Tag = 0;
            }

            btnPinSayac++;
        }

        public void gsrOku(ListBox listSoketler)
        {
            XmlTextReader XMLOku = new XmlTextReader(Application.StartupPath + "\\" + listSoketler.Text.Split('.')[0] + ".gsr");
            string x = "", y = "", cx = "", cy = "";
            int sonuc;
            ArrayList pinler = new ArrayList();
            pinler.Clear();

            try
            {
                while (XMLOku.Read())
                {
                    if (int.TryParse(XMLOku["pin"], out sonuc) == true)
                        pinler.Add(sonuc);

                    if (XMLOku.NodeType == XmlNodeType.Element && XMLOku.Name == "x")
                    {
                        XMLOku.Read();
                        x = XMLOku.Value;
                    }
                    else if (XMLOku.NodeType == XmlNodeType.Element && XMLOku.Name == "y")
                    {
                        XMLOku.Read();
                        y = XMLOku.Value;
                    }
                    else if (XMLOku.NodeType == XmlNodeType.Element && XMLOku.Name == "cx")
                    {
                        XMLOku.Read();
                        cx = XMLOku.Value;
                    }
                    else if (XMLOku.NodeType == XmlNodeType.Element && XMLOku.Name == "cy")
                    {
                        XMLOku.Read();
                        cy = XMLOku.Value;
                        koordinatlar.Add(x + "." + y + "." + cx + "." + cy);
                    }
                }//------------------while end-----------------------//
                btnPinOlustur((int)pinler[pinler.Count - 1]);
                bilgilendirme = listSoketler.Text;
            }
            catch
            {
                flowPanel.Controls.Clear();
                bilgilendirme = "Dosya bulunamadı.";
            }
        }

        void pinCizimYap(int pinX, int pinY, int pinCx, int pinCy)
        {
            foreach (var item in frm.Controls)
            {
                if (item is PictureBox)
                {
                    PictureBox pict = (PictureBox)item;
                    Graphics g = pict.CreateGraphics();

                    SolidBrush firca = new SolidBrush(Color.Red);
                    g.FillRectangle(firca, new Rectangle(Cursor.Position.X - 285, Cursor.Position.Y - 102, 4, 4));

                    g.DrawLine(new Pen(Color.Green, 4), pinX, pinY, pinX, pinCy);
                    g.DrawLine(new Pen(Color.Green, 4), pinX, pinY, pinCx, pinY);
                    g.DrawLine(new Pen(Color.Green, 4), pinCx, pinCy, pinX, pinCy);
                    g.DrawLine(new Pen(Color.Green, 4), pinCx, pinCy, pinCx, pinY);
                }
            }
        }

        public void soketTestEt()
        {
            try
            {
                int i = 0;
                foreach (var item in flowPanel.Controls)
                {
                    if (item is Button)
                    {
                        Button btnBeklenen = (Button)item;

                        if ((int)btnBeklenen.Tag == 2)
                        {
                            MessageBox.Show("Pin " + btnBeklenen.Text + " devre dışı.. !");
                        }
                        else if (gelenDeger[i] == 0)
                        {
                            MessageBox.Show("Pin " + btnBeklenen.Text + " bozuk.. !");
                        }
                        else if (gelenDeger[i] == 1)
                        {
                            MessageBox.Show("Pin " + btnBeklenen.Text + " sağlam.. !");

                        }
                        else if (gelenDeger[i] == 2)
                        {
                            MessageBox.Show("Pin " + btnBeklenen.Text + " devre dışı.. !");
                        }
                    }
                    i++;
                }
            }
            catch
            {

            }

        }
    }
}