using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp22
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            h = new Hero(pictureBox3);
            enemies = new PictureBox[] { pictureBox1, pictureBox2, pictureBox4, pictureBox5 };
            t = new Thread(send);
        }
        int dir = 5;
        AppleHandler h1 = null;
        AppleHandler h2 = null;
        //-----------
        Observer ob = new Observer();
        Hero h;
        PictureBox[] enemies;
        Thread t;
        //--------------
        void send()
        {
            h.sendNotify();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            h1.request(new Product(1));
            label1.Text = h1.products.Count.ToString();
        }

        void radius_enemy()
        {
            foreach (PictureBox p in enemies)
            {
                double d = Math.Pow(p.Left - h.pic.Left, 2) + Math.Pow(p.Top - h.pic.Top, 2);
                Text = d.ToString();
                if (Math.Pow(p.Left - h.pic.Left, 2) + Math.Pow(p.Top - h.pic.Top, 2) < h.R*h.R)//(x-x0)^2+(y-y0)^2<R
                    if(!h.IsIn(p)) 
                         h.AddSubscriber(p);
                else
                    h.RemSubscriber(p);
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {//start settings
            h1 = new ConreteAppleHandler1();
            h2 = new ConreteAppleHandler2();
            h1.setNext(h2);

            radius_enemy();
           // t.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            h1.request(new Product(2));
            label2.Text = h2.products.Count.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /* ob.sendNotify();
             foreach(PictureBox p in enemies)
             {

             }*/
            radius_enemy();
            h.pic.Left += dir;

            h.sendNotify();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           if(ob.IsIn((Button)sender))
                ob.RemSubscriber((Button)sender);
            else
                ob.AddSubscriber((Button)sender);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {


        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void Form3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                dir = -5;
            if (e.KeyCode == Keys.Right)
                dir = 5;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            PartFace p = new PartFace();
            p.g = this.CreateGraphics();
            p.pic = new Bitmap(pictureBox1.Image);
            p.show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
