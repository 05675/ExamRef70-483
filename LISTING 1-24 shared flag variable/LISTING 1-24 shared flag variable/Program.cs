using System;
using System.Threading;

namespace LISTING_1_24_shared_flag_variable
{
    class Program
    {
        static bool tickRunning = true;  // flag variable 

        static void Main(string[] args)
        {
            tickRunning = true;

            Thread tickThread = new Thread(() =>
            {
                while (tickRunning)
                {
                    Console.WriteLine("Tick");
                    Thread.Sleep(1000);
                }
            });

            tickThread.Start();

            Console.WriteLine("Press a key to stop the clock");
            Console.ReadKey();
            tickRunning = false;
            Console.WriteLine("Press a key to exit");
            Console.ReadKey();
        }
        //共有フラグ変数。
        //スレッドが中止されると、即座に停止します。
        //これは、ファイルが開いていてリソースが割り当てられている状態で、
        //プログラムをあいまいな状態にしておくことを意味している可能性があります。
        //スレッドを中止するより良い方法は、共有フラグ変数を使用することです。
        //1-24は、これを行う方法を示しています。変数tickRunningは、tickthreadでループを制御します。
        //tickrunningがfalseに設定されている場合、スレッドは終了します。
    }
}
