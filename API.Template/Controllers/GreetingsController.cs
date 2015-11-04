using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Template.Models;

namespace API.Template.Controllers
{
    public class GreetingsController : ApiController
    {
        private static List<Greeting> greetings = new List<Greeting>();

        //GET /api/greetings
        public IEnumerable<Greeting> GetGreeting() {
            return greetings;
        }

        //POST /api/greetings
        public HttpResponseMessage PostGreeting(Greeting greeting) {
            greetings.Add(greeting);
            var response = this.Request.CreateResponse();
            response.StatusCode = HttpStatusCode.Created;
            response.Headers.Location = new Uri(this.Request.RequestUri, "greetings/" + greeting.Name);
            return response;
        }

        //GET /api/greetings/<name>
        public string GetGreeting(string id) {
            var greeting = greetings.FirstOrDefault(g => g == null ? false : g.Name == id);
            if (greeting == null) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return greeting.Message;
        }
    }
}
