using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ParallelProgramming {
    class TaskDelay {
        public static void Main() {
            var tokenSource = new CancellationTokenSource();
            new Task(() => {
                for (int i = 0; i < 10; i++) {
                    Console.WriteLine("processing task1");
                    Thread.Sleep(2000);
                    tokenSource.Token.ThrowIfCancellationRequested();
                }
            }, tokenSource.Token).Start();
            new Task(() => {
                for (int i = 0; i < 10; i++) {
                    Console.WriteLine("processing task2");
                    tokenSource.Token.WaitHandle.WaitOne(2000);
                    tokenSource.Token.ThrowIfCancellationRequested();
                }
            }, tokenSource.Token).Start();
            Console.ReadLine();
            tokenSource.Cancel();
        }
    }
}
