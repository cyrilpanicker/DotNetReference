using SportsStore.Models;
using SportsStore.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportsStore.Pages {
    public partial class Listing : System.Web.UI.Page {
        private ProductRepository repository = new ProductRepository { };
        protected void Page_Load(object sender, EventArgs e) {

        }
        protected IEnumerable<Product> GetProducts() {
            return repository.Products;
        }
    }
}