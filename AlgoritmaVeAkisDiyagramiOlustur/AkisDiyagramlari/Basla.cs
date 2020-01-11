using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmaVeAkisDiyagramiOlustur.AkisDiyagramlari
{
    class Basla
    {
        int y = 50;
        int counter = 1;
        bool pictBaslaSurukle;

        public void pictBaslaOlustur(AnaForm frm)
        {

            PictureBox p = new PictureBox();
            p.Name = "pictBasla" + counter;
            p.Width = 150;
            p.Height = 76;
            p.SizeMode = PictureBoxSizeMode.StretchImage;
            p.Image = Properties.Resources.basla;
            counter++;
            y += 10;
            p.Location = new System.Drawing.Point(200, y);
            p.MouseDown += new MouseEventHandler(pictBasla_mouseDown);
            p.MouseUp += new MouseEventHandler(pictBasla_mouseUp);
            p.MouseMove += new MouseEventHandler(pictBasla_mouseMove);
            p.MouseDoubleClick += new MouseEventHandler(pictBasla_mouseDoubleClick);
            frm.Controls.Add(p);

        }

        //--------------------Events-------------------------------------//

        private void pictBasla_mouseDoubleClick(object sender, MouseEventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            p.Dispose();
        }

        public void pictBasla_mouseDown(object sender, EventArgs e)
        {
            pictBaslaSurukle = true;
        }

        public void pictBasla_mouseUp(object sender, EventArgs e)
        {
            pictBaslaSurukle = false;
        }

        public void pictBasla_mouseMove(object sender, EventArgs e)
        {
            if (pictBaslaSurukle)
            {
                PictureBox pict = (PictureBox)sender;
                pict.Location = new Point(Cursor.Position.X - 60, Cursor.Position.Y - 50);
            }
        }
    }
}