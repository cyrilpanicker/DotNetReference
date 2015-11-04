using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.Models {
    public class CartLine {
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}