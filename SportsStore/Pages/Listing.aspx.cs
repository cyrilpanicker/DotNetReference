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

        private ProductRepository Repository = new ProductRepository { };
        private int PageSize = 4;
        private IEnumerable<Product> FilteredProducts {
            get {
                if(CurrentCategory == null) {
                    return Repository.Products;
                } else {
                    return Repository.Products
                        .Where(product => product.Category == CurrentCategory);
                }
            }
        }

        protected CartLine CartLine = new CartLine { };
        protected int MaxPage {
            get {
                return (int)Math.Ceiling((decimal)FilteredProducts.Count() / PageSize);
            }
        }
        protected int CurrentPage {
            get {
                int currentPage;
                var currentPageString = (string)RouteData.Values["page"] ?? (string)Request.QueryString["page"];
                return currentPageString != null && int.TryParse(currentPageString, out currentPage) ? currentPage : 1;
            }
        }
        protected string CurrentCategory {
            get {
                return (string)RouteData.Values["category"] ?? (string)Request.QueryString["category"];
            }
        }
        public IEnumerable<Product> ProductsByPage {
            get {
                return FilteredProducts
                    .OrderBy(product => product.ProductID)
                    .Skip((CurrentPage - 1) * PageSize)
                    .Take(PageSize);
            }
        }

        protected void Page_Load(object sender, EventArgs e) {

        }

        public System.Collections.IEnumerable Unnamed_GetData() {
            return null;
        }
    }
}