using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using SportsStore.Models;
using SportsStore.Models.Repository;
using SportsStore.Pages;

namespace SportsStore.Controls {
    public partial class CategoryList : System.Web.UI.UserControl {

        protected string HomeLink {
            get {
                return RouteTable.Routes.GetVirtualPath(null, null).VirtualPath;
            }
        }
        protected IEnumerable<string> Categories {
            get {
                return new ProductRepository { }.Products
                    .Select(product => product.Category)
                    .Distinct()
                    .OrderBy(category => category);
            }
        }
        protected string CurrentCategory {
            get {
                return (string)Page.RouteData.Values["category"] ?? (string)Request.QueryString["category"];
            }
        }

        protected string GetCategoryLink(string category) {
            return RouteTable.Routes.GetVirtualPath(null, null, new RouteValueDictionary { { "page", 1 }, { "category", category } }).VirtualPath;
        }

        protected void Page_Load(object sender, EventArgs e) {

        }
    }
}