using System;
using System.Linq;

namespace LISTING_1_6_Informing_parallelization
{
    class Program
    {
        class Person
        {
            public string Name { get; set; }
            public string City { get; set; }
        }

        static void Main(string[] args)
        {
            Person[] people = new Person[] {
                new Person { Name = "Alan", City = "Hull" },
                new Person { Name = "Beryl", City = "Seattle" },
                new Person { Name = "Charles", City = "London" },
                new Person { Name = "David", City = "Seattle" },
                new Person { Name = "Eddy", City = "Paris" },
                new Person { Name = "Fred", City = "Berlin" },
                new Person { Name = "Gordon", City = "Hull" },
                new Person { Name = "Henry", City = "Seattle" },
                new Person { Name = "Isaac", City = "Seattle" },
                new Person { Name = "James", City = "London" }};

            var result = from person in people.AsParallel()
                         .WithDegreeOfParallelism(4)
                         .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                         where person.City == "Seattle"
                         select person;

            foreach (var person in result)
                Console.WriteLine(person.Name);

            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();
        }

        //プログラムは、リスト1-6に示されているように、並列化プロセスをさらに知らせるために、他のメソッド呼び出しを使用することができます。
        //このコールアスパラレルは、パフォーマンスが向上しているかどうかに関わらず、クエリの並列化を要求します。
        //最大4つのプロセッサでクエリを実行するように要求します。
        //非並列クエリは，入力データと同じ順序の出力データを生成します。
        //つまり、リスト1-5のクエリは以下のような出力を生成します。
    }
}
