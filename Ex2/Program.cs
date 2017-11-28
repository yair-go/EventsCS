using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex2
{
    public delegate void PrinterEventHandler();

    public class MyPrinter_1
    {
        public event PrinterEventHandler PageOver;
        private int pageCount = 20;

        /// <summary>
        /// this function will run when
        /// page printer over
        /// </summary>
        private void DoPageOver()
        {
            // do something
            if (PageOver != null)
                PageOver();
        }

        public void Print(int pageNumber)
        {
            this.pageCount -= pageNumber;
            if (pageCount <= 0)
            {
                pageCount = 0;
                DoPageOver();
            }
        }
    }
    class User1
    {
        MyPrinter_1 printer;
        public User1(MyPrinter_1 printer)
        {
            this.printer = printer;
            this.printer.PageOver += User1DoPageOver;  // this.printer.PageOver = User1DoPageOver;
        }

        private void User1DoPageOver()
        {
            // do something
            Console.WriteLine("user 1 do ...");
        }
    }

    class User2
    {
        MyPrinter_1 printer;
        public User2(MyPrinter_1 printer)
        {
            this.printer = printer;
            this.printer.PageOver += User2DoPageOver;
        }

        private void User2DoPageOver()
        {
            // do something
            Console.WriteLine("user 2 do ...");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            MyPrinter_1 p = new MyPrinter_1();
            User1 u1 = new User1(p);
            User2 u2 = new User2(p);
            
            Console.WriteLine("enter page of copy :");
            int x = int.Parse(Console.ReadLine());
            p.Print(x);
        }
    }
}
