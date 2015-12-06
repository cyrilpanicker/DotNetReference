using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProgramming {
    class ControlTaskCompletion {

        static Task<string> HiAsync() {
            return Task.Factory.StartNew<string>(() => {
                Thread.Sleep(2000);
                return "Hi";
            });
        }

        static Task<string> HiAsyncControlled() {
            var deferred = new TaskCompletionSource<string>();
            Thread.Sleep(2000);
            deferred.SetResult("Hi");//completes the task
            return deferred.Task;
        }

        static Task TaskBasedTimer(int milliseconds) {
            var deferred = new TaskCompletionSource<object>();
            var timer = new System.Timers.Timer(milliseconds);
            timer.AutoReset = false;
            timer.Elapsed += (sender,eventArgs) => {
                deferred.SetResult(null);
                timer.Dispose();
            };
            timer.Start();
            return deferred.Task;
        }

        static Action<Task<string>> taskHandler = _ => {
            Console.WriteLine(_.Result);
        };

        public static void Main() {

            HiAsync().ContinueWith(taskHandler);
            HiAsyncControlled().ContinueWith(taskHandler);

            Console.WriteLine("Current Time : "+ DateTime.Now.ToString("h:mm:ss tt"));
            TaskBasedTimer(5000)
                .ContinueWith(_ => {
                    Console.WriteLine("5 seconds elapsed");
                    Console.WriteLine("Current Time : " + DateTime.Now.ToString("h:mm:ss tt"));
                });

            Console.ReadLine();

        }

    }
}
