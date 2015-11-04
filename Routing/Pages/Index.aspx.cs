using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Models;
using Common;

namespace Routing.Pages {
    public partial class Index : System.Web.UI.Page {

        private int PageSize = 3;

        protected IEnumerable<Product> Products {
            get {
                return Repository.Products;
            }
        }

        public int MaxPage {
            get {
                return (int)Math.Ceiling((decimal)Products.Count() / PageSize);
            }
        }

        protected int CurrentPage {
            get {
                int page = int.TryParse((string)RouteData.Values["page"], out page) ? page : 1;
                return page > MaxPage ? MaxPage : page;
            }
        }

        protected IEnumerable<Product> GetProducts() {
            return Products
                .OrderBy(product => product.ProductID)
                .Skip((CurrentPage - 1) * 3)
                .Take(PageSize);
        }

        protected void Page_Load(object sender, EventArgs e) {

        }
        
    }
}