using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ParallelProgramming {
    class TaskCancellation {
        public static void Main() {

            var tokenSource1 = new CancellationTokenSource();
            var tokenSource2 = new CancellationTokenSource();
            var compositeTokenSource = CancellationTokenSource.CreateLinkedTokenSource(tokenSource1.Token, tokenSource2.Token);

            var task1 = new Task(() => {
                while (true) {
                    if (tokenSource1.Token.IsCancellationRequested) {
                        Console.WriteLine("task1 cancelled");
                        throw new OperationCanceledException(tokenSource1.Token);
                    } else {
                        Console.WriteLine("task1 processing");
                    }
                    Thread.Sleep(250);
                }
            }, tokenSource1.Token);
            task1.Start();

            var task2 = new Task(() => {
                while (true) {
                    tokenSource1.Token.ThrowIfCancellationRequested();
                    Console.WriteLine("task2 processing");
                    Thread.Sleep(250);
                }
            }, tokenSource1.Token);
            task2.Start();

            var task3 = new Task(() => {
                while (true) {
                    if (tokenSource2.Token.IsCancellationRequested) {
                        Console.WriteLine("task3 cancelled");

                        throw new OperationCanceledException(tokenSource2.Token);
                    } else {
                        Console.WriteLine("task3 processing");
                    }
                    Thread.Sleep(250);
                }
            }, tokenSource2.Token);
            task3.Start();

            tokenSource1.Token.Register(() => {
                Console.WriteLine("task cancellation delegate called");
            });

            new Task(() => {
                tokenSource1.Token.WaitHandle.WaitOne();//blocks until token source is cancelled
                Console.WriteLine("wait handle released");
            }, tokenSource1.Token).Start();

            new Task(() => {
                compositeTokenSource.Token.WaitHandle.WaitOne();
                Console.WriteLine("wait handle released on composite token");
            }, compositeTokenSource.Token).Start();


            Console.ReadLine();
            Console.WriteLine("Cancellation statuses : {0}, {1}, {2}", task1.IsCanceled, task2.IsCanceled, task3.IsCanceled);
            Console.WriteLine("cancelling tokensource1");
            tokenSource1.Cancel();

            Console.ReadLine();
            Console.WriteLine("Cancellation statuses : {0}, {1}, {2}", task1.IsCanceled, task2.IsCanceled, task3.IsCanceled);
            Console.WriteLine("cancelling tokensource2");
            tokenSource2.Cancel();

            Console.ReadLine();
            Console.WriteLine("Cancellation statuses : {0}, {1}, {2}", task1.IsCanceled, task2.IsCanceled, task3.IsCanceled);
            Console.ReadLine();
        }
    }
}
