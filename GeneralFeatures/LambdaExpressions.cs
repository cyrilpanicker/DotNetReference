using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralFeatures.Models;

namespace GeneralFeatures {
    static class LambdaExpressions {

        public static IEnumerable<Product> Filter1(this IEnumerable<Product> products, Func<Product, bool> filter) {
            foreach (var product in products) {
                if (filter(product)) {
                    yield return product;
                }
            }
        }

        public static void Main() {

            var cart = new ShoppingCart {
                Products = new List<Product> {
                    new Product {Name="Pencil",Category="Stationery", Price=9.0M },
                    new Product {Name="Tie",Category="Clothes", Price=100.00M },
                    new Product {Name="Pen",Category="Stationery", Price=12.0M }
                }
            };

            var filteredList = cart.Filter1(product => product.Category == "Stationery" && product.Price > 10.00M);
            foreach (var product in filteredList) {
                Console.Write(product.Name + ", ");
            }
            Console.WriteLine();

            Func<Product, bool> clothesFilter = product => product.Category == "Clothes";
            foreach (var product in cart.Filter1(clothesFilter)) {
                Console.Write(product.Name + ", ");
            }
            Console.WriteLine();
        }
    }
}
