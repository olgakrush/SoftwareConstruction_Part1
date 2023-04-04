using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Graph;

namespace WindowsFormsApp22
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();           
            g = this.CreateGraphics();//Graphics.FromImage(pictureBox1.Image);
            t = new Tree(g);
            t.addNode("root");
            
        }
        MyStack stack = new MyStack();
        MyQueue queue = new MyQueue();
        Tree t; 
        Graphics g;
        Image im;

        private void button1_Click(object sender, EventArgs e)
        {
            stack.push(textBox1.Text);
            textBox2.Text = stack.ToString();
            //listBox1.Items[0].
           // textBox2.Text = textBox2.Text.Substring(2, textBox2.Text.Length) + textBox2.Text[1];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = stack.pop().ToString();
                textBox2.Text = stack.ToString();
            }
            catch
            {
                MessageBox.Show("Stack is empty");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int a = 25689;
            stack.Clear();
            while(a>0)
            {
                stack.push(a % 10);
                a /= 10;
            }
            textBox2.Text = stack.ToString();
            int i = 0;
            while(!stack.IsEmpty())
            {
                a += Convert.ToInt32(stack.pop())*(int)Math.Pow(10,i);
                i++;
            }
            textBox1.Text = a.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {            
            int a = 25689;
            queue.Clear();
            while (a > 0)
            {
                queue.push(a % 10);
                a /= 10;
            }
            textBox2.Text = queue.ToString();
            queue.Clear();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            if (!queue.IsEmpty())
            {
                switch (Convert.ToInt32(queue.pop()))
                {
                    case 0: pictureBox1.Left += 10; break;
                    case 1: pictureBox1.Top += 10; break;
                    case 2:
                        if (pictureBox1.Tag.ToString() == "1")
                        {
                            pictureBox1.Image = new Bitmap(@"Resources\sticker2.png");
                            pictureBox1.Tag = 2;
                        }
                        else
                        {
                            pictureBox1.Image = new Bitmap(@"Resources\sticker1.png");
                            pictureBox1.Tag = 1;
                        }
                        break;
                }
                listBox1.Items.RemoveAt(0);
            }
            else
            {
                timer1.Stop();
                listBox1.Items.Clear();
            }
            //listBox1.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            queue.push(((Button)sender).Tag);
            listBox1.Items.Add(((Button)sender).Text);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) ||
                        (!string.IsNullOrEmpty(((TextBox)sender).Text) && e.KeyChar == ','))
            {
                return;
            }

            e.Handled = true;
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (t.nodes.Count > 0)
                    t.addNode(textBox1.Text, t.nodes[comboBox1.SelectedIndex], e.X, e.Y);
                else
                    t.addNode(textBox1.Text, t.root, e.X, e.Y);
                comboBox1.Items.Add(textBox1.Text);
                textBox1.Text = "";
                t.draw();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           // e.
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //e.
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
        }

        private void textBox3_MouseDown(object sender, MouseEventArgs e)
        {
            source = sender;
            ((TextBox)sender).DoDragDrop(((TextBox)sender).Text, DragDropEffects.Copy);
            Text = "end drop";
        }
        Object source;
        private void textBox4_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void textBox4_DragDrop(object sender, DragEventArgs e)
        {           
            ((TextBox)sender).Text = e.Data.GetData(DataFormats.Text).ToString();
        }
        //---------------------------
        MyList m = new MyList();
        private void button10_Click(object sender, EventArgs e)
        {
            m = m.InsertAtEnd(tbListAdd.Text);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            tbListPrint.Text = m.Print();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //g.RotateTransform()
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
           
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Rectangle_ r = new Rectangle_();
            r.init(10, 10, 5, 50, 30);
            r.center = new Point(-5, -5);
            Rectangle_ r1 = (Rectangle_) r.clone();
            listBox3.Items.Add(r.ToString());
            listBox3.Items.Add(r1.ToString());
            r1.x = 100;
            r1.center.X = 0;
            listBox3.Items.Add(r.ToString());
            listBox3.Items.Add(r1.ToString());
            
        }

        private void button15_Click(object sender, EventArgs e)
        {
            car c = new car();
            track t = new track();
            listBox4.Items.Add(c.ToString());
            listBox4.Items.Add(t.ToString());
            listBox4.Items.Add("---------------");
            transportAdapter tr = new transportAdapter();
            c = tr.tractTocar(t);
            listBox4.Items.Add(c.ToString());
        }

        private void button14_Click(object sender, EventArgs e)
        {
            car c = new car();
            track t = new track();
            listBox4.Items.Add(c.ToString());
            listBox4.Items.Add(t.ToString());
            listBox4.Items.Add("---------------");
            transportAdapter tr = new transportAdapter();
            t=tr.carTotract(c);
            listBox4.Items.Add(t.ToString());
  
        }
    }
}
