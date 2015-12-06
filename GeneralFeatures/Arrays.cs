using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralFeatures {
    class Arrays {
        public static void Main() {

            var a = new int[3];
            var b = new int[] { 1, 2, 3 };
            //var c = { 1, 2, 3 }; //error
            int[] c = { 1, 2, 3 };
            var d = new[] { 1, 2, 3 };
            //var e = new[] { 1, "two" }; //error
            var e = new object[] { 1, "two" };

            var multArray = new int[3][][];
            multArray[0] = new int[2][];
            multArray[1] = new int[3][];
            multArray[2] = new int[2][];
            multArray[0][0] = new int[] { 1, 2, 3 };
            multArray[0][1] = new int[] { 4, 5};
            multArray[1][0] = new int[] { 6, 7, 8, 9};
            multArray[1][1] = new int[] { 10, 11 };
            multArray[1][2] = new int[] { 12, 13, 14 };
            multArray[2][0] = new int[] { 15, 16, 17 };
            multArray[2][1] = new int[] { 18, 19, 20, 21 };
            for (int i = 0; i < multArray.Length; i++) {
                for (int j = 0; j < multArray[i].Length; j++) {
                    for (int k = 0; k < multArray[i][j].Length; k++) {
                        Console.Write(multArray[i][j][k]+" ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            var rectMultArray = new int[3, 2, 2];
            var number = 1;
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 2; j++) {
                    for (int k = 0; k < 2; k++) {
                        rectMultArray[i, j, k] = number;
                        number++;
                    }
                }
            }
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 2; j++) {
                    for (int k = 0; k < 2; k++) {
                        Console.Write(rectMultArray[i,j,k]+" ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
