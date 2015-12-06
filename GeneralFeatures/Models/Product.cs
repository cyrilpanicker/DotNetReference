using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralFeatures.Models {
    class Product {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public override string ToString() {
            return String.Format("Name : {0}\nPrice : {1}\nCategory : {2}\n", Name, Price, Category);
        }
    }
}
