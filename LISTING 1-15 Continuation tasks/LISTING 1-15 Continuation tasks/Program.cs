using System;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_15_Continuation_tasks
{
    class Program
    {
        public static void HelloTask()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Hello");
        }

        public static void WorldTask()
        {
            Thread.Sleep(1000);
            Console.WriteLine("World");
        }

        static void Main(string[] args)
        {
            Task task = Task.Run(() => HelloTask());
            task.ContinueWith( (prevTask) => WorldTask());

            //上記のTaskより、以下の処理が先に行われる
            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();
        }
    }
}
