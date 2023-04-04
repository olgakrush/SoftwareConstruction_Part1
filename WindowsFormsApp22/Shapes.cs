using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp22
{
    
    public abstract class Shape
    {
        public int x, y;
        public int color;
        public Shape()
        {

        }
        public Shape(Shape s)
        {
            this.x = s.x;
            this.y = s.y;
            this.color = s.color;
        }
        abstract public Shape clone();
    }

    public class Rectangle_:Shape
    {
        int h, w;
        public Point center;
        public Rectangle_()
        {

        }
        Rectangle_(Rectangle_ r):base(r)
        {
            this.h = r.h;
            this.w = r.w;
            this.center = r.center;
        }
        public void init(int x, int y, int color, int h, int w)
        {
            this.x = x;
            this.y = y;
            this.color = color;
            this.h = h;
            this.w = w;
        }
        public override Shape clone()
        {
            return new Rectangle_(this);
        }
        public override string ToString()
        {
            return "("+x.ToString() + "," + y.ToString() + "," + color.ToString() + "," + h.ToString() + ","
                + w.ToString()+","+center.ToString()+")";

        }
    }
}
