using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp22
{
    class MyList
    {
        public object data=null;
        public MyList poinerNext=null;
        public MyList head=null;
        public MyList()
        {
          data = null;
          poinerNext = null;          
         }
        /*
        InsertAtEnd — Вставка заданного элемента в конец списка
InsertAtHead — Вставка элемента в начало списка
Delete — удаляет заданный элемент из списка
DeleteAtHead — удаляет первый элемент списка
Search — возвращает заданный элемент из списка
isEmpty — возвращает True, если связанный список пуст
          */
        public String Print()
        {
            String res = "";
            MyList cur = head;
            do {
                if (cur.data != null)
                    res += cur.data.ToString()+"\r\n";
                cur = cur.poinerNext;
            }
            while (cur.poinerNext != null);
            res += cur.data.ToString() + " \r\n";
            return res;
        }
       public MyList InsertAtEnd(object data)
        {
            MyList newItem = new MyList();
            newItem.data = data;
            if (head == null)
            {
                head = newItem;
                data = newItem.data;
                this.poinerNext = null;
            }
            else
            {
                if (head.poinerNext == null)
                    head.poinerNext = newItem;
                this.poinerNext = newItem;
            }
            newItem.head = head;
            return newItem;
        }
    }
}
