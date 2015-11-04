using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.Models {
    public class Cart {

        private List<CartLine> lineCollection;

        public IEnumerable<CartLine> Lines {
            get {
                return lineCollection;
            }
        }
        public decimal Total {
            get {
                return lineCollection.Sum(line => line.Product.Price * line.Quantity);
            }
        }

        public void AddItem(Product product, int quantity) {
            var line = lineCollection
                .Where(l => l.Product.ProductID == product.ProductID)
                .FirstOrDefault();

            if(line != null) {
                line.Quantity += quantity;
            } else {
                lineCollection.Add(new CartLine {
                    Product = product,
                    Quantity = quantity
                });
            }
        }

        public void RemoveLine(Product product) {
            lineCollection.RemoveAll(line => line.Product.ProductID == product.ProductID);
        }

        public void Clear() {
            lineCollection.Clear();
        }
    }
}