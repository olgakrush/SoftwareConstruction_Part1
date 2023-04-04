using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp22
{
    class MyStack
    {
        //Variant a[100];
        object[] a = new object[100];//fixed array of elements in stack
        int top = 0;//number of the top element
        int size = 100;//max size of stack
        public bool push(object el)
        {
            if (!isFull())
            {
                a[top] = el;
                top++;
                return true;
            }
            return false;
        }
        public object pop()
        {
            if (!IsEmpty())
            {
                top--;
                return a[top];
            }
            return null;
        }
        public bool IsEmpty()
        {
            /*if (top == 0)
                return true;
            else
                return false;*/
            return top == 0;
        }
        public bool isFull()
        {
            return top == size;
        }
        public object getTop()
        {
            return a[top];
        }
        override public string ToString()
        {
            string s = "";
            for(int i=0;i<top;i++)
            {
                s = s + a[i].ToString() + " ";
            }
            return s;
        }
        public void Clear()
        {
           top = 0;
        }
    }
}
