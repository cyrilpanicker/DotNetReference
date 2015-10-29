using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EFReference {
    public partial class Index : System.Web.UI.Page {
        private ObjectDbContext AppContext = new ObjectDbContext { };
        protected void Page_Load(object sender, EventArgs e) {

        }
        protected IEnumerable<Employee> GetEmployees() {
            return AppContext.Employees;
        }
    }
}