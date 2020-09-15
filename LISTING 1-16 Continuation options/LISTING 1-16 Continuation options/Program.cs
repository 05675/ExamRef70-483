using System;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_16_Continuation_options
{
    class Program
    {
        public static void HelloTask()
        {
            Thread.Sleep(1000);

            //意図的に例外を投げる
            throw new Exception("Fail");
            Console.WriteLine("Hello");
        }

        public static void WorldTask()
        {
            Thread.Sleep(1000);
            Console.WriteLine("World");
        }

        public static void ExceptionTask()
        {
            Console.WriteLine("Exception thrown");
        }

        static void Main(string[] args)
        {
            Task task = Task.Run(() => HelloTask());

            //HelloTaskが成功した時に以下は動作する
            task.ContinueWith((prevTask) => WorldTask(), TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith((prevTask) => ExceptionTask(), TaskContinuationOptions.OnlyOnFaulted);

            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();
        }
    }
}
