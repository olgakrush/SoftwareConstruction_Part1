using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp22
{
    class transportAdapter
    {
        public car tractTocar(track t)
        {
            car c = new car();
            //adapting
            if(t.seets < c.seets)
              c.seets = t.seets;//if t.seets<c.seets -> c.seets = t.seets
            if (t.weel_diam < c.weel_diam)
                c.weel_diam = t.weel_diam;//if t.seets<c.seets -> c.seets = t.seets
            if (t.speed < c.speed)
                c.speed = t.speed;//if t.seets<c.seets -> c.seets = t.seets

            c.trailer_mount = false;
            return c;
        }
        public track carTotract(car c)
        {
            track t = new track();
            //adapting
            if (c.seets < t.seets)
                t.seets = c.seets;//if t.seets<c.seets -> c.seets = t.seets
            if (c.weel_diam < t.weel_diam)
                t.weel_diam = c.weel_diam;//if t.seets<c.seets -> c.seets = t.seets
            if (c.speed < t.speed)
                t.speed = c.speed;//if t.seets<c.seets -> c.seets = t.seets

            t.cargo_v = 10;
            return t;
        }
    }
    class transport
    {
        public int speed;
        public int weel_diam;
        public int seets;

        override public string ToString()
        {
            return "(speed="+speed.ToString()+ ", weel_diam"+ weel_diam.ToString()+ ", seets"+seets.ToString();
        }
    }
    class car:transport
    {
        public bool trailer_mount;
        public car()
        {
            seets = 5;
            weel_diam = 14;
            speed = 300;
            trailer_mount = true;
        }
        override public string ToString()
        {
            return base.ToString() + "- trailer_mount=" + trailer_mount.ToString();
        }
    }
    class track:transport
    {
        public int cargo_v;
        public track()
        {
            seets = 3;
            weel_diam = 21;
            speed = 200;
            cargo_v = 50;
        }
        override public string ToString()
        {
            return base.ToString() + "- cargo_v=" + cargo_v.ToString();
        }
    }
}
