using System;
using System.Collections.Generic;
using System.Drawing;


namespace Graph
{     
     class Node
     {
        public object Value;
        public int x, y;
        public int h, w;
        public List<Brach> branches_in = new List<Brach>();//input brach
        public List<Brach> branches_out = new List<Brach>();//output braches
        public Node(object v)
        {
            h = 20;
            w = 20;
            Value = v;
        }
        public Node(object v, int x, int y)
        {
            h = 20;
            w = 20;
            this.x = x;
            this.y = y;
            Value = v;
        }
        public void draw(Graphics device, int x, int y)
        {
            this.x = x;
            this.y = y;
            device.DrawEllipse(Pens.Brown, x, y, h, w);
            device.DrawString(Value.ToString(), new Font("Arial", 12), Brushes.Black, x, y);
        }
    }
    class Brach
    {
        public Node begin;
        public Node end;
        public object data;
        public Brach(Node n1, Node n2)
        {
            begin = n1;
            end = n2;
        }
        public void draw(Graphics device)
        {
            Pen p = new Pen(Color.Red, 5);
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            device.DrawLine(p, begin.x + begin.w, begin.y + begin.h / 2, end.x, end.y);
        }
    }
    class MyGraph
    {        
        public List<Brach> branches = new List<Brach>();
        public List<Node> nodes = new List<Node>();
        Graphics device;//to draw tree
        MyGraph g;
        public MyGraph()
        {
            
        }
        public MyGraph(Graphics device)
        {
            this.device = device;
        }
        public void CreateGraph(Node n1, Node n2)//add new nodes and brach between them
        {
            Brach b = new Brach(n1, n2);
            n1.branches_out.Add(b);
            n2.branches_in.Add(b);
            branches.Add(b);
            nodes.Add(n1);
            nodes.Add(n2);
        }
        public void addNode(Node in_node, Node new_node)//add to the existing node new branch to the new node
        {
            Brach b = new Brach(in_node, new_node);
            in_node.branches_out.Add(b);
            new_node.branches_in.Add(b);
            branches.Add(b);
            nodes.Add(new_node);
        }
        public void addBranch(Node in_node, Node out_node)//add branch
        {
            Brach b = new Brach(in_node, out_node);
            in_node.branches_out.Add(b);
            out_node.branches_in.Add(b);
            branches.Add(b);
        }

        public void draw()
        {
            foreach (Node n in nodes)
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
            return n.branches_out.Count == 0;
        }
        public void delete_node(int i)
        {
          /*  Brach b = nodes[i].branch_in;
            // b.begin
            foreach (Brach bb in nodes[i].branches_out)
            {
                bb.begin = b.begin;
            }
            branches.Remove(b);
            nodes.Remove(nodes[i]);*/
        }
        public Node find(int x, int y)
        {
            foreach (Node n in nodes)
            {
                if (x >= n.x && y >= n.y && x<=n.x+n.w && y<=n.y+n.h)
                    return n;
            }
            return null;
        }
    }
}
