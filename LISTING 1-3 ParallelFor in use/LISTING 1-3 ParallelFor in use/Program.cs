using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_3_ParallelFor_in_use
{
    class Program
    {
        static void WorkOnItem(object item)
        {
            Console.WriteLine("Started working on: " + item);
            Thread.Sleep(100);
            Console.WriteLine("Finished working on: " + item);
        }

        //1番目のパラメータは配列で提供される。
        //2番目のパラメータはリスト内の各項目で実行されるアクションを提供します。
        //タスクは開始された順番では完了しないことに注意してください。
        static void Main(string[] args)
        {
            var items = Enumerable.Range(0, 50).ToArray();

            Parallel.For(0, items.Length, i =>
            {
                WorkOnItem(items[i]);
            });

            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();
        }
    }
}
