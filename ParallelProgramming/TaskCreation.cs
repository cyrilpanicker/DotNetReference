using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ParallelProgramming {
    class TaskCreation {
        public static void Main() {

            //tasks with no data input
            Task.Factory.StartNew(() => {
                Console.WriteLine("Hello World1!");
            });
            new Task(() => {
                Console.WriteLine("Hello World2!");
            }).Start();
            new Task(delegate {
                Console.WriteLine("Hello World3!");
            }).Start();
            new Task(new Action(delegate {
                Console.WriteLine("Hello World4!");
            })).Start();


            //tasks with data input
            new Task((taskName) => {
                Console.WriteLine((string)taskName + " complete.");
            }, "Task1").Start();
            new Task(delegate (object taskName) {
                Console.WriteLine((string)taskName + " complete.");
            }, "Task2").Start();
            new Task(new Action<object>(delegate (object taskName) {
                Console.WriteLine((string)taskName + " complete.");
            }),"Task3").Start();


            //tasks with return value and data input
            var task1 = Task.Factory.StartNew<string>((name) => {
                Thread.Sleep(2000);
                return "Hello " + (string)name;
            }, "Tom");
            Console.WriteLine(task1.Result);//blocks until Result is available
            var task2 = new Task<string>((name) => {
                Thread.Sleep(2000);
                return "Hello " + (string)name;
            },"Cyril");
            task2.Start();
            Console.WriteLine(task2.Result);//blocks until Result is available

            var completedTask = Task.FromResult<int>(10);
            Console.WriteLine(completedTask.IsCompleted + " " + completedTask.Result);

            Console.WriteLine("Main method complete");
            Console.ReadKey();
        }
    }
}
