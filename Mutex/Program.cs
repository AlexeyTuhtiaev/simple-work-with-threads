using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MutexUsing
{
    class Program
    {
        private static Mutex mutex = new Mutex();

        static void Main(string[] args)
        {
            
            int i = 0;
            while(true)
            {
                //mutex.WaitOne();
                Thread thread = new Thread(new ThreadStart(Function));
                thread.Name = String.Format("Поток {0}", i + 1);
                thread.Start();
                i++;
                //mutex.ReleaseMutex();
            }
        }

        private static void Function()
        {
            for (int i = 0; i < 2; i++)
            {
                UseResource();
            }
        }

       
        private static void UseResource()
        {
            mutex.WaitOne();

            Console.ForegroundColor = (ConsoleColor)(new Random().Next(1,10));

            Console.WriteLine("{0} вошел в защищенную область.", Thread.CurrentThread.Name);
            Thread.Sleep(1000); // Выполнение некоторой работы...
            Console.WriteLine("{0} покидает защищенную область.\r\n", Thread.CurrentThread.Name);

            mutex.ReleaseMutex();

            Thread.Sleep(1000);
        }
    }
}
