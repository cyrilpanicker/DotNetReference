using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.Models.Repository {
    public class ProductRepository {
        private ObjectDbContext Context = new ObjectDbContext { };
        public IEnumerable<Product> Products {
            get { return Context.Products; }
        }
    }
}