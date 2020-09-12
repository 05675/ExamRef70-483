using System;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_11_Create_a_task
{
    class Program
    {
        public static void DoWork()
        {
            Console.WriteLine("Work starting");
            Thread.Sleep(2000);
            Console.WriteLine("Work finished");
        }

        static void Main(string[] args)
        {
            Task newTask = new Task(() => DoWork());
            newTask.Start();
            newTask.Wait();
        }
    }
    //ここまでの章で取り上げた並列化ツールは、非常に抽象度の高いレベルで動作しています。
    //ここでは、タスクを作成して管理する方法を考えてみましょう。
}
