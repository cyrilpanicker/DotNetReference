using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProgramming {
    class WaitingForTasks {
        public static void Main() {
            var task1 = new Task(() => {
                Console.WriteLine("task1 started");
                Thread.Sleep(2000);
                Console.WriteLine("task1 completed");
            });
            var task2 = new Task(() => {
                Console.WriteLine("task2 started");
                task1.Wait();
                Console.WriteLine("task2 completed");
            });
            var task3 = new Task(() => {
                Console.WriteLine("task3 started");
                Thread.Sleep(1000);
                Console.WriteLine("task3 completed");
            });
            var combinedTask = new Task(() => {
                Console.WriteLine("combined task started");
                Task.WaitAll(task1, task2, task3);
                Console.WriteLine("combined task completed");
            });
            var tasksWatcher = new Task(() => {
                Console.WriteLine("tasks-watcher started");
                Task.WaitAny(task1, task2, task3);
                Console.WriteLine("tasks-watcher compeleted");
            });

            task1.Start();
            task2.Start();
            task3.Start();
            tasksWatcher.Start();
            combinedTask.Start();

            Console.ReadLine();
        }
    }
}
