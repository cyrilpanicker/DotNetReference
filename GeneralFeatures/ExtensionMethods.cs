using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralFeatures.Models;

namespace GeneralFeatures {

    static class ExtensionMethods {

        public static decimal GetTotalPrice(this IEnumerable<Product> products) {
            var total = 0M;
            foreach (var product in products) {
                total += product.Price;
            }
            return total;
        }

        public static void Main() {

            var cart = new ShoppingCart {
                Products = new List<Product> {
                    new Product {
                        Name="Product1",
                        Price=12.5M
                    },
                    new Product {
                        Name="Product2",
                        Price=10.5M
                    }
                }
            };

            Console.WriteLine(cart.GetTotalPrice());
        }
    }
}
