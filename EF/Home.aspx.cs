using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EF.DataAccessLayer;
using EF.Models;

namespace EF {
    public partial class Home : System.Web.UI.Page {
        private Repository repository = new Repository { };
        protected void Page_Load(object sender, EventArgs e) {

        }
        protected IEnumerable<Employee> GetEmployees() {
            return repository.Employees;
        }
    }
}