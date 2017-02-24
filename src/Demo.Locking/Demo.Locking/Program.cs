using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Demo.Locking
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = new Command();
            command.Execute();
        }

        public class Command
        {
            public void Execute()
            {
                var stopwatch = Stopwatch.StartNew();

                const int lowerBound = 1;
                const int upperBound = 1;

                var delay = TimeSpan.FromSeconds(.5);
                var worker1 = new Worker("Worker1", delay);
                var worker2 = new Worker("Worker2", delay);

                var invoker1 = new LoopProvider(worker1, lowerBound, upperBound);
                var invoker2 = new LoopProvider(worker2, lowerBound, upperBound);

                var task1 = Task.Factory.StartNew(invoker1.Execute);
                var task2 = Task.Factory.StartNew(invoker2.Execute);

                Task.WaitAll(task1, task2);

                Console.WriteLine();
                Console.WriteLine($"Total Elapsed:  {stopwatch.Elapsed}");

                Console.ReadLine();
            }
        }
    }
}
