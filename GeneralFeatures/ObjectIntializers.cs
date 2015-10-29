using GeneralFeatures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralFeatures {
    class ObjectIntializers {
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

            var productList = new List<Product> {
                new Product {
                    Name="Product3",
                    Price=89.5M
                },
                new Product {
                    Name="Product4",
                    Price=6.5M
                }
            };

            foreach (var product in cart) {
                Console.Write(product.Name + ", ");
            }
            Console.WriteLine();

            foreach (var product in productList) {
                Console.Write(product.Name + ", ");
            }
            Console.WriteLine();
        }
    }
}
