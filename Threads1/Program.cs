using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threads1
{
    class Program
    {
        private static void funkForThread()
        {
            Console.WriteLine("Thread ID = {0}", Thread.CurrentThread.ManagedThreadId);

            Console.ForegroundColor = ConsoleColor.Yellow;

            for (int i = 0; i < 30; i++)
            {
                Thread.Sleep(50);
                Console.Write("X");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void Main(string[] args)
        {
            var thread = new Thread(funkForThread);
            thread.Start();

            thread.Join();//waiting for thread

            Console.WriteLine();
            Console.WriteLine("row after 'thread.Join();'");

            Console.ForegroundColor = ConsoleColor.Green;

            for (int i = 0; i < 30; i++)
            {
                Thread.Sleep(50);
                Console.Write("Y");
            }

            Console.ForegroundColor = ConsoleColor.Gray;

            Console.ReadKey();
        }
    }
}
