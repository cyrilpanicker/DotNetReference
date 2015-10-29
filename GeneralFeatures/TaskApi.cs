using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GeneralFeatures {
    class TaskApi {

        public static Task<long?> GetPageLength1() {
            var httpClient = new HttpClient { };
            var requestTask = httpClient.GetAsync("https://github.com/cyrilpanicker");
            Console.WriteLine("1: Request Sent.");
            return requestTask.ContinueWith(responseTask => {
                Console.WriteLine("1: Response Received.");
                return responseTask.Result.Content.Headers.ContentLength;
            });
        }

        public static async Task<long?> GetPageLength2() {
            var httpClient = new HttpClient { };
            var requestTask = httpClient.GetAsync("https://github.com/cyrilpanicker");
            Console.WriteLine("2: Request Sent.");
            var httpMessage = await requestTask;
            Console.WriteLine("2: Response Received.");
            return httpMessage.Content.Headers.ContentLength;
        }

        public static void Main() {
            var parallelTask1 = GetPageLength1().ContinueWith(pageLengthTask => {
                Console.WriteLine("1: Content Length : " + pageLengthTask.Result);
            });
            var parallelTask2 = GetPageLength2().ContinueWith(pageLengthTask => {
                Console.WriteLine("2: Content Length : " + pageLengthTask.Result);
            });
            parallelTask1.Wait();
            parallelTask2.Wait();
        }

    }
}
