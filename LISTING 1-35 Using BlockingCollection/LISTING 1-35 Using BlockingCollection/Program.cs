using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace LISTING_1_35_Using_BlockingCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            // 5つのアイテムを収納できるブロック(区画)を収集(コレクション)
            BlockingCollection<int> data = new BlockingCollection<int>(10);

            Task.Run(() =>
            {
                // コレクションに10個のアイテムを追加しようとする - 5番目以降のブロック
                for (int i = 0; i < 10; i++)
                {
                    data.Add(i);
                    Console.WriteLine("Data {0} added successfully.", i);
                }
                // これ以上追加するものがないことを示しています
                data.CompleteAdding();
            });

            Console.ReadKey();
            Console.WriteLine("Reading collection");

            Task.Run(() =>
            {
                while (!data.IsCompleted)
                {
                    try
                    {
                        int v = data.Take();
                        Console.WriteLine("Data {0} taken successfully.", v);
                    }
                    catch (InvalidOperationException) { }
                }
            });

            Console.ReadKey();
        }
    }
}
