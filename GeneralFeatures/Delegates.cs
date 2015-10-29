using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralFeatures.Models;

namespace GeneralFeatures {
    static class Delegates {

        public static IEnumerable<Product> Filter(this IEnumerable<Product> products, Func<Product, bool> filter) {
            foreach (var product in products) {
                if (filter(product)) {
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

            Func<Product, bool> clothesFilter = delegate (Product product) {
                return product.Category == "Clothes";
            };
            foreach (var product in cart.Filter(clothesFilter)) {
                Console.Write(product.Name + ", ");
            }
            Console.WriteLine();

            var stationeryItems = cart.Filter(delegate (Product product) {
                return product.Category == "Stationery";
            });
            foreach (var product in stationeryItems) {
                Console.Write(product.Name + ", ");
            }
            Console.WriteLine();

        }
    }
}
