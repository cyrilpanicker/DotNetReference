using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralFeatures {

    enum EngineerType : byte {
        DE=1,
        SDE,
        PE
    }

    class Enums {

        static string GetEmployeeDesignation(EngineerType type) {
            switch (type) {
                case EngineerType.DE:return "Development Engineer";
                case EngineerType.SDE:return "Senior Development Engineer";
                case EngineerType.PE:return "Principal Engineer";
                default:return null;
            }
        }

        public static void Main() {
            var principalEngineer = EngineerType.PE;
            Console.WriteLine(principalEngineer.GetType());
            Console.WriteLine(Enum.GetUnderlyingType(principalEngineer.GetType()));
            Console.WriteLine(principalEngineer.ToString());
            Console.WriteLine((byte)principalEngineer);
            Console.WriteLine(GetEmployeeDesignation(EngineerType.SDE));
            var values = Enum.GetValues(principalEngineer.GetType());
            foreach (var value in values) {
                Console.WriteLine(value +" : "+(byte)value);
            }
            Console.ReadLine();
        }
    }
}
