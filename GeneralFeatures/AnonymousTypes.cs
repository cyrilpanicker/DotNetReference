using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralFeatures.Models;

namespace GeneralFeatures {
    class AnonymousTypes {
        public static void Main() {

            var object1 = new { };
            var object2 = new { };
            var object3 = new { Id = "A001" };
            var object4 = new { Id = "A002" };
            var product = new Product { Name = "SomeProduct" };
            object2 = object1;  //legal
            object3 = object4;  //legal
            //object2 = object3;  //error
            //object2 = product;  //error
            Console.WriteLine(object3.Id);
            Console.WriteLine(product.Name);

            var list = new[] {
                new {Id="1"},
                new {Id="2"}
            };

            foreach (var item in list) {
                Console.Write(item.Id + ", ");
            }
            Console.WriteLine();
        }
    }
}
