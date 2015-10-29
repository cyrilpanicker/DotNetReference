using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralFeatures.Models;

namespace GeneralFeatures {

    public class Container<T> {
        public T Value { get; set; }
        public bool HasValue { get { return Value != null; } }
    }

    class GenericTyping {
        public static void Main() {

            var productContainer1 = new Container<Product> { };
            var stringContainer1 = new Container<string> { };
            var productContainer2 = new Container<Product> {
                Value = new Product {
                    Name = "p1"
                }
            };
            var stringContainer2 = new Container<string> {
                Value = "cyril"
            };

            Console.WriteLine(productContainer1.HasValue);
            Console.WriteLine(stringContainer1.HasValue);
            Console.WriteLine(productContainer2.HasValue);
            Console.WriteLine(stringContainer2.HasValue);

        }
    }
}
