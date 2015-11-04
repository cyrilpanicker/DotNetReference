using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralFeatures {
    class NamedAndOptionalParameters {

        public static double CurrencyExchanger(double amount, double rate=1) {
            return amount * rate;
        }

        public static void Main() {
            Console.WriteLine(CurrencyExchanger(500, 63));
            Console.WriteLine(CurrencyExchanger(500));
            Console.WriteLine(CurrencyExchanger(rate: 2, amount: 500));
            Console.WriteLine(CurrencyExchanger(amount: 500));
        }
    }
}
