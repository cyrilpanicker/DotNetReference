using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace API.Client {
    class Program {
        static void Main(string[] args) {
            var greeting = new HttpClient()
                .GetAsync(new Uri("http://localhost:52189/api/greetings"))
                .Result
                .Content
                .ReadAsStringAsync()
                .Result;
            Console.WriteLine(greeting);
            Console.ReadLine();
        }
    }
}
