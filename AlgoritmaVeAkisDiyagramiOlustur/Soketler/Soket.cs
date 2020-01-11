using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace AlgoritmaVeAkisDiyagramiOlustur
{
    class Soket
    {
        private string soketYolu;
        private string soketAdi;
        private Form frm;
        private int x = 0;
        private int y = 0;
        public int cx = 0;
        public int cy = 0;
        private string pinClr;
        private string shape = "r";
        private int pinSayac = 0;
        public int cizimSayac = 0;

        //--------------------------constructor--------------------//
        public Soket()
        {

        }

        public Soket(Form _frm)
        {
            frm = _frm;
        }

        public Soket(string _soketYolu, Form _frm, string _soketAdi)
        {
            soketYolu = _soketYolu;
            frm = _frm;
            soketAdi = _soketAdi;
        }

        //----------------------------------------------------------//

        public void soketOlustur()
        {
            formTemizle();
            pinSayac = 0;
            PictureBox p = new PictureBox();
            p.Name = "pict_" + soketAdi;
            p.Width = 850;
            p.Height = 600;
            p.Location = new Point(280, 75);
            p.SizeMode = PictureBoxSizeMode.CenterImage;
            p.BackgroundImage = Image.FromFile(soketYolu);
            p.BackgroundImageLayout = ImageLayout.Stretch;
            p.MouseDown += new MouseEventHandler(pictSoket_MouseDown);
            frm.Controls.Add(p);
        }

        private void pictSoket_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox p = (PictureBox)sender;

            Graphics g = p.CreateGraphics();
            SolidBrush firca = new SolidBrush(Color.Red);
            g.FillRectangle(firca, new Rectangle(Cursor.Position.X - 285, Cursor.Position.Y - 102, 4, 4));
            if (cizimSayac == 0)
            {
                x = Cursor.Position.X - 285;
                y = Cursor.Position.Y - 102;
            }
            else if (cizimSayac == 1)
            {
                cx = Cursor.Position.X - 283;
                cy = Cursor.Position.Y - 97;

                g.DrawLine(bozukPin(), x, y, x, cy);
                g.DrawLine(bozukPin(), x, y, cx, y);
                g.DrawLine(bozukPin(), cx, cy, x, cy);
                g.DrawLine(bozukPin(), cx, cy, cx, y);
                gsrSaveSoket();
                cizimSayac = -1;
            }
            cizimSayac++;
        }

        private Pen bozukPin()
        {
            //ColorTranslator.FromHtml("#FF0000")
            Pen RedPen = new Pen(Color.Red, 4);
            pinClr = "#FF0000";
            return RedPen;
        }

        private Pen saglamPin()
        {
            Pen GreenPen = new Pen(Color.Green, 4);
            pinClr = "#00FF00";
            return GreenPen;
        }

        private Pen disabledPin()
        {
            Pen WhitePen = new Pen(Color.White, 4);
            pinClr = "#FFFFFF";
            return WhitePen;
        }

        public void formTemizle()
        {
            foreach (Control item in frm.Controls)
            {
                if (item is PictureBox)
                {
                    item.Dispose();
                }
            }
        }

        public void soketResmiEkle(ListBox listSoketler)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Soket Files|*.jpg;*.jpeg;";
            dosya.ShowDialog();
            try
            {
                if (File.Exists(Application.StartupPath + "\\" + dosya.SafeFileName) == false)
                    File.Copy(dosya.FileName, Application.StartupPath + "\\" + dosya.SafeFileName);
                else
                    MessageBox.Show("Bu dosya zaten var.");
            }
            catch
            {
            }
            soketleriListele(listSoketler);
        }

        public void soketResmiSil(ListBox listSoketler)
        {
            //FileStream fs = new FileStream(Application.StartupPath + "\\" + listSoketler.Text, FileMode.Open);
            //fs.Flush();
            //fs.Close();
            //File.Delete(Application.StartupPath + "\\" + listSoketler.Text); //şimdi sil
            using (System.IO.StreamReader sr = new System.IO.StreamReader(Application.StartupPath + "\\" + listSoketler.Text))
            {
                string not = sr.ReadToEnd();
                File.Delete(Application.StartupPath + "\\" + listSoketler.Text); //şimdi sil
            }
            //File.Open(Application.StartupPath + "\\" + listSoketler.Text, FileMode.Open).Close();
            //File.Delete(Application.StartupPath + "\\" + listSoketler.Text);
            soketleriListele(listSoketler);
        }

        public void soketleriListele(ListBox listSoketler)
        {
            listSoketler.Items.Clear();
            string[] dosyalar = Directory.GetFiles(Application.StartupPath);
            foreach (string dosya in dosyalar)
            {
                if (dosya.EndsWith(".jpg") || dosya.EndsWith(".jpeg"))
                    listSoketler.Items.Add(dosya.Split('\\')[dosya.Split('\\').Length - 1]);
                //soket isimlerini yazdır.
            }
        }

        public void gsrSaveSoket()
        {
            if (File.Exists(Application.StartupPath + "\\" + soketAdi.Split('.')[0] + ".gsr") == false)
            {
                XmlTextWriter xmlCreated = new XmlTextWriter(soketAdi.Split('.')[0] + ".gsr", UTF8Encoding.UTF8);
                xmlCreated.WriteStartDocument();
                xmlCreated.WriteStartElement("soket");
                xmlCreated.WriteEndDocument();
                xmlCreated.Close();
            }

            XDocument xDoc = XDocument.Load(Application.StartupPath + "\\" + soketAdi.Split('.')[0] + ".gsr");

            XElement rootElement = xDoc.Root;

            XElement newElement = new XElement(soketAdi.Split('.')[0]);

            pinSayac++;

            XAttribute pinAttribute = new XAttribute("pin", pinSayac);
            XElement xElement = new XElement("x", x);
            XElement yElement = new XElement("y", y);
            XElement wElement = new XElement("cx", cx);
            XElement hElement = new XElement("cy", cy);
            XElement clrElement = new XElement("clr", pinClr);
            XElement shpElement = new XElement("shp", shape);


            newElement.Add(pinAttribute, xElement, yElement, wElement, hElement, clrElement, shpElement);

            rootElement.Add(newElement);

            xDoc.Save(Application.StartupPath + "\\" + soketAdi.Split('.')[0] + ".gsr");
        }

        public override string ToString()
        {
            return "X: " + x + " Y: " + y + " cx: " + cx + " cy: " + cy + " clr: " + pinClr + " Shape: " + shape;
        }

    }
}