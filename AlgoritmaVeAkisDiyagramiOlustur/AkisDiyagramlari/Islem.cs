using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmaVeAkisDiyagramiOlustur.AkisDiyagramlari
{
    class Islem
    {
        int y = 50;
        int counter = 1;
        bool pictIslemSurukle;

        public void pictIslemOlustur(AnaForm frm)
        {

            PictureBox p = new PictureBox();
            p.Name = "pictIslem" + counter;
            p.Width = 150;
            p.Height = 76;
            p.SizeMode = PictureBoxSizeMode.StretchImage;
            p.Image = Properties.Resources.islem;
            counter++;
            y += 10;
            p.Location = new System.Drawing.Point(360, y);
            p.MouseDown += new MouseEventHandler(pictIslem_mouseDown);
            p.MouseUp += new MouseEventHandler(pictIslem_mouseUp);
            p.MouseMove += new MouseEventHandler(pictIslem_mouseMove);
            p.MouseDoubleClick += new MouseEventHandler(pictIslem_mouseDoubleClick);
            frm.Controls.Add(p);

        }

        private void pictIslem_mouseDoubleClick(object sender, MouseEventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            p.Dispose();
        }

        private void pictIslem_mouseMove(object sender, MouseEventArgs e)
        {
            if (pictIslemSurukle)
            {
                PictureBox p = (PictureBox)sender;
                p.Location = new Point(Cursor.Position.X - 60, Cursor.Position.Y - 50);
            }
        }

        private void pictIslem_mouseUp(object sender, MouseEventArgs e)
        {
            pictIslemSurukle = false;
        }

        private void pictIslem_mouseDown(object sender, MouseEventArgs e)
        {
            pictIslemSurukle = true;
        }
    }
}
