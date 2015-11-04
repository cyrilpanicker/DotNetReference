using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProgramming {
    class TaskContinuation {
        public static void Main() {

            Func<Task<string>> helloAsync = () => {
                return Task.Factory.StartNew<string>(() => {
                    Thread.Sleep(1000);
                    return "hello";
                });
            };

            Func<Task<string>> hiAsync = () => {
                return Task.Factory.StartNew<string>(() => {
                    Thread.Sleep(1000);
                    return "hi";
                });
            };

            Func<int, Task> exceptionAsync = (int input) => {
                return Task.Factory.StartNew(() => {
                    Thread.Sleep(5000);
                    if (input % 2 == 0) {
                        throw new OperationCanceledException();
                    }
                });
            };


            helloAsync()
                .ContinueWith((task1) => {
                    Console.WriteLine("1st handler : " + task1.Result);
                    return hiAsync();
                })
                .ContinueWith(task => {
                    Console.WriteLine("2nd handler");
                    ((Task<string>)task.Result).ContinueWith(task1 => {
                        Console.WriteLine("3rd handler : " + task1.Result);
                    });
                });

            var helloTask = helloAsync();
            if (helloTask.IsCompleted) {
                Console.WriteLine(helloTask.Result);
            } else {
                helloTask.ContinueWith(_ => {
                    Console.WriteLine(_.Result);
                });
            }

            exceptionAsync(2)
                .ContinueWith(_ => {
                    Console.WriteLine("exceptionAsync executed");
                });

            exceptionAsync(1)
                .ContinueWith(_ => {
                    Console.WriteLine("exceptionAsync executed successfully");
                }, TaskContinuationOptions.NotOnFaulted);

            exceptionAsync(2)
                .ContinueWith(_=>{
                    Console.WriteLine("exceptionAsync failed");
                },TaskContinuationOptions.OnlyOnFaulted);

            Console.ReadLine();

        }
    }
}
