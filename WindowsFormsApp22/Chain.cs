using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp22
{
    public class Product
    {
        public int size;
        public Product(int s)
        {
            size = s;
        }
    }
    public interface Handler
    {
        void setNext(Handler a);
        void request(Product p);
    }
    public class AppleHandler: Handler
    {
        protected Handler next;
        public List<Product> products = new List<Product>();
        public void setNext(Handler a)
        {
            next = a;
        }

        public virtual void request(Product p)
        {
            if(next!=null)
            {
                next.request(p);
            }
        }
    }
    public class ConreteAppleHandler1: AppleHandler
    {
        public  override void request(Product p)
        {
            if (p.size == 1)
            {
                if(products.Count==0)
                 products.Add(p);
               // products.Add(p);
               // MessageBox.Show("add 1 size product to the First box");
               //base.request(p);
            } 
            else
            {
                base.request(p);
            }
        }
    }
    public class ConreteAppleHandler2: AppleHandler
    {
        public override void request(Product p)
        {
            if (p.size == 2)
            {
               // if (products.Count == 0)
                    products.Add(p);
              //  MessageBox.Show("add 2 size product to the Second box");
            }
            else
            {
                base.request(p);
            }
        }
    }
}
