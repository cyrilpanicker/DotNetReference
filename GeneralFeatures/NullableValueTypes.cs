using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralFeatures {
    class DatabaseReader {
        public int? number = null;
        public bool? boolean = true;
        public int? GetNumber() { return number; }
        public bool? GetBoolean() { return boolean; }
    }
    class NullableValueTypes {
        public static void Main() {
            int? numberFromDatabase = new DatabaseReader().GetNumber();
            bool? booleanFromDatabase = new DatabaseReader().GetBoolean();
            var number = numberFromDatabase ?? 0;
            var boolean = booleanFromDatabase ?? false;
            Console.WriteLine(number);
            Console.WriteLine(boolean);
            Console.ReadLine();
        }
    }
}
