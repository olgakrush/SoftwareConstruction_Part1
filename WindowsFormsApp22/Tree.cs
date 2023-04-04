using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace WindowsFormsApp22
{
    class Node
    {
        object Value;
        public int x, y;
        public int h, w;
        public Brach branch_in;//input brach
        public List<Brach> branches_out = new List<Brach>();//output braches
        public Node(object v)
        {
            h = 20;
            w = 20;
            Value = v;
        }
        public void draw(Graphics device, int x,int y)
        {
            this.x = x;
            this.y = y;
            device.DrawEllipse(Pens.Brown, x, y, h, w);
            device.DrawString(Value.ToString(),new Font("Arial",12),Brushes.Black, x, y);
        }
    }
    class Brach
    {
        public Node begin;
        public Node end;       
        public Brach(Node n1, Node n2)
        {
            begin = n1;
            end = n2;
        }
        public void draw(Graphics device)
        {
            Pen p = new Pen(Color.Red, 5);
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            device.DrawLine(p, begin.x+begin.w, begin.y+begin.h/2, end.x, end.y);
        }
    }
    class Tree
    {
        public Node root = null;
        public List<Brach> branches = new List<Brach>();
        public List<Node> nodes = new List<Node>();
        Graphics device;//to draw tree
        public Tree()
        {

        }
        public Tree(Graphics device)
        {
            this.device = device;
        }
        public void addNode(object Value)//add root
        {
            root = root == null? new Node(Value):root;
            root.x = 10; root.y = 10;
            nodes.Add(root);
        }
        public void addNode(object Value, Node n, int x, int y)//add root
        {
            Node tmp = new Node(Value);
            tmp.branch_in = new Brach(n,tmp);
            branches.Add(tmp.branch_in);
            nodes.Add(tmp);
            tmp.draw(device, x, y);
        }

        public void draw()
        {
            foreach(Node n in nodes)
            {
                n.draw(device, n.x, n.y);
            }
            foreach (Brach b in branches)
            {
                b.draw(device);
            }
        }

        public bool IsParent(Node n1, Node n2)
        {

            return false;
        }
        public bool IsLinked(Node n1, Node n2)
        {

            return false;
        }
        public List<Node> Path(Node n1, Node n2)
        {

            return null;
        }
        public bool IsLast(Node n)
        {
            return n.branches_out.Count==0;
        }
        public void delete_node(int i)
        {
            Brach b = nodes[i].branch_in;
           // b.begin
           foreach(Brach bb in nodes[i].branches_out)
            {
                bb.begin = b.begin;
            }
            branches.Remove(b);
            nodes.Remove(nodes[i]);
        }
    }
}
