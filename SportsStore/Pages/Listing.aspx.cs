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
        private int PageSize = 4;

        protected int CurrentPage {
            get {
                var page = GetPageFromRequest();
                return page > MaxPage ? MaxPage : page;
            }
        }
        protected int MaxPage {
            get {
                return (int)Math.Ceiling((decimal)repository.Products.Count() / PageSize);
            }
        }

        protected void Page_Load(object sender, EventArgs e) {

        }

        private int GetPageFromRequest() {
            int page;
            var pageString = (string)RouteData.Values["page"] ?? Request.QueryString["page"];
            return pageString != null && int.TryParse(pageString, out page) ? page : 1;
        }

        protected IEnumerable<Product> GetProducts() {
            return repository.Products
                .OrderBy(product => product.ProductID)
                .Skip((CurrentPage-1) * PageSize)
                .Take(PageSize);
        }

    }
}