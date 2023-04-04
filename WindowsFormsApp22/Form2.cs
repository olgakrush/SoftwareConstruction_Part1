using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Graph
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            g = CreateGraphics();
            gr = new MyGraph(g);
        }
        Graphics g;
        MyGraph gr;
        Node n_start= null;
        Node n_end=null;
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            if(radioButton1.Checked)//create graph
            {
                if(n_start==null)
                {
                    n_start = new Node(textBox1.Text, e.X, e.Y);
                    n_start.draw(g, e.X, e.Y);
                }
                else
                if (n_end == null)
                {
                    n_end = new Node(textBox2.Text, e.X, e.Y);
                    gr.CreateGraph(n_start, n_end);
                    gr.draw();
                    radioButton1.Enabled = false;
                    radioButton1.Checked = false;
                    n_start = null;
                    n_end = null;
                }
            }
            //new node
            if (radioButton2.Checked)
            {
                if (n_start == null)
                {
                    n_start = gr.find(e.X, e.Y);
                    label1.Text=n_start==null?"null":n_start.Value.ToString();
                }
                else
                if (n_end == null)
                {
                    n_end = new Node(textBox2.Text, e.X, e.Y);
                    gr.addNode(n_start, n_end);
                    gr.draw();                   
                   
                    n_start = null;
                    n_end = null;
                
                }
            }
            //add branch
            //new node
            if (radioButton3.Checked)
            {
                if (n_start == null)
                {
                    n_start = gr.find(e.X, e.Y);
                    label1.Text = n_start == null ? "null" : n_start.Value.ToString();
                }
                else
                if (n_end == null)
                {
                    n_end = gr.find(e.X, e.Y);
                    label2.Text = n_end == null ? "null" : n_start.Value.ToString();
                    if (n_end != null)
                    {
                        gr.addBranch(n_start, n_end);
                        gr.draw();   
                        n_start = null;
                        n_end = null;
                    }               
                }
            }
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {


        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox2.Select();
        }
    }
}
