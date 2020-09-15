using System;
using System.Threading;

namespace LISTING_1_18_Creating_threads
{
    class Program
    {
        static void ThreadHello()
        {
            Console.WriteLine("Hello from the thread");
            Thread.Sleep(5000);
        }

        static void Main(string[] args)
        {
            Thread thread = new Thread(ThreadHello);

            //ここを通過したら実行される。スレッドは、糸のように一筋の流れ
          　thread.Start();
        }
    }
}
