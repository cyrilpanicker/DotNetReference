using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProgramming {
    class ParallelTasks {
        public static void Main() {

            var twitterTask = new HttpClient().GetStringAsync("https://twitter.com")
                .ContinueWith(task => {
                    if (task.Status == TaskStatus.RanToCompletion) {
                        Console.WriteLine("twitter task completed");
                    } else if (task.Status == TaskStatus.Canceled) {
                        Console.WriteLine("twitter task has been cancelled");
                    } else {
                        Console.WriteLine("exception occurred in twitter task : " + task.Exception.InnerException.Message);
                    }
                    return task.Result;
                });

            var googleTask = new HttpClient().GetStringAsync("https://www.google.com")
                .ContinueWith(task => {
                    if (task.Status == TaskStatus.RanToCompletion) {
                        Console.WriteLine("google task completed");
                    } else if (task.Status == TaskStatus.Canceled) {
                        Console.WriteLine("google task has been cancelled");
                    } else {
                        Console.WriteLine("exception occurred in google task : " + task.Exception.InnerException.Message);
                    }
                    return task.Result; 
                });

            Task.Factory.ContinueWhenAll(new Task<string>[] { twitterTask, googleTask }, tasks => {
                Console.WriteLine();
                Console.WriteLine("all dependent tasks completed");
                Console.WriteLine();
                Console.WriteLine("twitter message : "+tasks[0].Result.Substring(0,100));
                Console.WriteLine();
                Console.WriteLine("google message : "+tasks[1].Result.Substring(0,100));
            });

            Task.WhenAll(twitterTask, googleTask)
                .ContinueWith(task=> {
                    Console.WriteLine();
                    Console.WriteLine("all dependent tasks completed");
                    Console.WriteLine();
                    foreach (var result in task.Result) {
                        Console.WriteLine("message : "+result.Substring(0,100));
                    }
                });
            Console.ReadLine();
        }
    }
}
