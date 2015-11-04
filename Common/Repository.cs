using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;

namespace Common
{
    public class Repository
    {
        public static IEnumerable<Product> Products {
            get {
                return new List<Product> {
                    new Product {
                        ProductID=1,
                        Name="Kayak",
                        Description="A boat for one person",
                        Category="Watersports",
                        Price=275.00M
                    },
                    new Product {
                        ProductID=2,
                        Name="Life Jacket",
                        Description="Protective and fashionable",
                        Category="Watersports",
                        Price=48.95M
                    },
                    new Product {
                        ProductID=3,
                        Name="Soccer Ball",
                        Description="FIFA-approved size and weight",
                        Category="Soccer",
                        Price=19.50M
                    },
                    new Product {
                        ProductID=4,
                        Name="Corner Flags",
                        Description="Give your playing field a professional touch",
                        Category="Soccer",
                        Price=34.95M
                    },
                    new Product {
                        ProductID=5,
                        Name="Stadium",
                        Description="Flat-packed, 35,000-seat stadium",
                        Category="Soccer",
                        Price=79500.00M
                    },
                    new Product {
                        ProductID=6,
                        Name="Thinking Cap",
                        Description="Improve your brain efficiency by 75%",
                        Category="Chess",
                        Price=275.00M
                    },
                    new Product {
                        ProductID=7,
                        Name="Unsteady Chair",
                        Description="Secretly give your opponent a disadvantage",
                        Category="Chess",
                        Price=29.95M
                    },
                    new Product {
                        ProductID=8,
                        Name="Bling-Bling King",
                        Description="Gold-plated, diamond-studded King",
                        Category="Chess",
                        Price=1200.00M
                    },
                    new Product {
                        ProductID=9,
                        Name="Human Chess Board",
                        Description="A fun game for the family",
                        Category="Chess",
                        Price=75.00M
                    }
                };
            }
        }
    }
}
