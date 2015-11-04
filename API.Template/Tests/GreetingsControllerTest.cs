using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xunit;
using System.Web.Http;
using System.Net.Http;
using API.Template.Models;
using API.Template.Controllers;
using System.Net;

namespace API.Template.Tests {
    public class GreetingsControllerTest {

        [Fact]
        public void PostGreeting() {

            //arrange
            var controller = new GreetingsController();
            controller.Request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:9000/api/greetings");

            //act
            var response = controller.PostGreeting(new Greeting {
                Name = "sample",
                Message = "sample message"
            });

            //assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(new Uri("http://localhost:9000/api/greetings/sample"), response.Headers.Location);
        }

    }
}