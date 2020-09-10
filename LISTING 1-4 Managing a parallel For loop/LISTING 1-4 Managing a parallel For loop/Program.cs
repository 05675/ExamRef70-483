using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_4_Managing_a_parallel_For_loop
{
    class Program
    {
        static void WorkOnItem(object item)
        {
            Console.WriteLine("Started working on: " + item);
            Thread.Sleep(100);
            Console.WriteLine("Finished working on: " + item);
        }

        static void Main(string[] args)
        {
            var items = Enumerable.Range(0, 50).ToArray();

            //ループの実行ステータス
            ParallelLoopResult result = Parallel.For(0, items.Count(), (int i, ParallelLoopState loopState) =>
            {
                if (i == 20)
                    loopState.Break();

                WorkOnItem(items[i]);
            });

            Console.WriteLine("Completed: " + result.IsCompleted);      //ループの完了報告
            Console.WriteLine("Items: " + result.LowestBreakIteration); //どこでブレークされたか判断

            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();
        }
    }
}
