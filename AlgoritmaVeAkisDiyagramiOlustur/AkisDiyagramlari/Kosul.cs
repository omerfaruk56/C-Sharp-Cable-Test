using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmaVeAkisDiyagramiOlustur.AkisDiyagramlari
{
    class Kosul
    {
        int y = 50;
        int counter = 1;
        bool pictKosulSurukle;

        public void pictKosulOlustur(AnaForm frm)
        {

            PictureBox p = new PictureBox();
            p.Name = "pictKosul" + counter;
            p.Width = 150;
            p.Height = 152;
            p.SizeMode = PictureBoxSizeMode.StretchImage;
            p.Image = Properties.Resources.eger;
            counter++;
            y += 50;
            p.Location = new System.Drawing.Point(520, y);
            p.MouseDown += new MouseEventHandler(pictKosul_mouseDown);
            p.MouseUp += new MouseEventHandler(pictKosul_mouseUp);
            p.MouseMove += new MouseEventHandler(pictKosul_mouseMove);
            p.MouseDoubleClick += new MouseEventHandler(pictKosul_mouseDoubleClick);
            frm.Controls.Add(p);

        }
        //---------------------------Events---------------------------------//

        private void pictKosul_mouseDoubleClick(object sender, MouseEventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            p.Dispose();
        }

        private void pictKosul_mouseMove(object sender, MouseEventArgs e)
        {
            if (pictKosulSurukle)
            {
                PictureBox pict = (PictureBox)sender;
                pict.Location = new Point(Cursor.Position.X - 60, Cursor.Position.Y - 50);
            }
        }

        private void pictKosul_mouseUp(object sender, MouseEventArgs e)
        {
            pictKosulSurukle = false;
        }

        private void pictKosul_mouseDown(object sender, MouseEventArgs e)
        {
            pictKosulSurukle = true;

        }
    }
}