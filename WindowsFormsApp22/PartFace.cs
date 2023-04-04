using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp22
{
    class PartFace
    {
        public System.Drawing.Graphics g;
        public System.Drawing.Bitmap pic;
        public int x, y, h, w;
        public void show()
        {
            g.DrawImage(pic, new System.Drawing.Point(x, y));
        }
        public void hide()
        {
            g.FillRectangle(System.Drawing.Brushes.Gray, new System.Drawing.Rectangle(x, y,w,h)); ;
        }
        void move(int dir, int delta)
        {
            hide();
            switch(dir)
            {
                case 0://left
                    x -= delta; break;
            }
        }


    }
    class Barber:PartFace
    {

    }
    class Face
    {
        List<PartFace> faceparts = new List<PartFace>();

    }
}
