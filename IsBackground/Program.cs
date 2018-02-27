using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace IsBackground
{
    class Program
    {
        private static void SomeFunction()
        {
            for (int i = 0; i < 500; i++)
            {
                Console.Write(".");
                Thread.Sleep(10);
            }
            Console.WriteLine("Second thread finished");
        }

        static void Main(string[] args)
        {
            Thread thread = new Thread(SomeFunction);
            //thread.IsBackground = true;

            thread.Start();
            Thread.Sleep(500);            

            Console.WriteLine("Main thread finished");
        }
    }
}
