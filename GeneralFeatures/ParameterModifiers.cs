using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralFeatures.Models;

namespace GeneralFeatures {
    class ParameterModifiers {

        static int Add(int x, int y) {
            var value = x + y;
            x = 0;
            y = 0;
            return value;
        }

        static int AddAndReset(ref int x, ref int y) {
            var value = x + y;
            x = 0;
            y = 0;
            return value;
        }

        static int AddAndSubtract(int x,int y,out int value1) {
            value1 = x - y;
            var value2 = x + y;
            return value2;
        }

        static void ResetProductCategory(Product product) {
            product.Category = "UNASSIGNED";
            //below operation will not be visible for the caller
            product = new Product {
                Name = "UNNAMED",
                Price = 0,
                Category = "UNASSIGNED"
            };
        }

        static void ResetProduct(ref Product product) {
            product = new Product {
                Name = "UNNAMED",
                Price = 0,
                Category = "UNASSIGNED"
            };
        }

        static int AddAll(params int[] numbers) {
            var value = 0;
            foreach (var number in numbers) {
                value += number;
            }
            return value;
        }

        static int AddTwo(int x, int y = 2) {
            return x + y;
        }

        public static void Main() {
            int x = 10;
            int y = 20;
            int value,value1,value2;

            value = Add(x, y);
            Console.WriteLine(value);
            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine();

            value = Add(x: 1,y: 9);
            Console.WriteLine(value);
            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine();

            value = AddAndReset(ref x, ref y);
            Console.WriteLine(value);
            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine();

            value2 = AddAndSubtract(20, 10, out value1);
            Console.WriteLine(value1);
            Console.WriteLine(value2);
            Console.WriteLine();

            Console.WriteLine(AddAll(new int[] {1,4,7,9 }));
            Console.WriteLine(AddAll(1,4,7,9));
            Console.WriteLine();

            Console.WriteLine(AddTwo(3));
            Console.WriteLine();

            var product = new Product {
                Name = "Tie",
                Price = 10,
                Category = "Clothes"
            };
            ResetProductCategory(product);
            Console.WriteLine(product);
            ResetProduct(ref product);
            Console.WriteLine(product);

            Console.ReadLine();
        }
    }
}
