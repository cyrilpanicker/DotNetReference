using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using Common.Models;

namespace UserControls {
    public partial class ProductTable : System.Web.UI.UserControl {

        protected IEnumerable<Product> Products {
            get {
                return Repository.Products;
            }
        }

        protected void Page_Load(object sender, EventArgs e) {

        }
    }
}