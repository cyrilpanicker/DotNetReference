using GeneralFeatures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralFeatures {
    class LINQ {
        public static void Main() {

            var cart = new ShoppingCart {
                Products = new List<Product> {
                    new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
                    new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
                    new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
                    new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
                }
            };


            //query-syntax
            var sortedPriceList = from product in cart
                                  orderby product.Price descending
                                  select product.Price;
            foreach (var price in sortedPriceList) {
                Console.Write(price + ", ");
            }
            Console.WriteLine();


            //dot-notation-syntax
            var topThreeprices = cart
                .OrderByDescending(product => product.Price)
                .Take(3)
                .Select(product => product.Price);
            foreach (var price in topThreeprices) {
                Console.Write(price + ", ");
            }
            Console.WriteLine();

            var namePriceMap = cart
                .Select(product => new {
                    Name = product.Name,
                    Price = product.Price
                });
            foreach (var product in namePriceMap) {
                Console.Write(product.Name + " : " + product.Price + ", ");
            }
            Console.WriteLine();
        }
    }
}
