using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralFeatures.Models;

namespace GeneralFeatures {
    static class Iterator {

        public static IEnumerable<Product> FilterByCategory(this IEnumerable<Product> products, string category) {
            foreach (var product in products) {
                if (product.Category == category) {
                    yield return product;
                }
            }
        }

        public static void Main() {
            var cart = new ShoppingCart {
                Products = new List<Product> {
                    new Product {Name="Pencil",Category="Stationery" },
                    new Product {Name="Tie",Category="Clothes" },
                    new Product {Name="Pen",Category="Stationery" }
                }
            };
            foreach (var product in cart.FilterByCategory("Stationery")) {
                Console.Write(product.Name + ", ");
            }
            Console.WriteLine();
        }
    }
}
