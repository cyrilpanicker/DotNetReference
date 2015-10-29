using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EF.Models;

namespace EF.DataAccessLayer {
    public class Repository {
        private EntityContext entityContext = new EntityContext { };
        public IEnumerable<Employee> Employees {
            get {
                return entityContext.Employees;
            }
        }
    }
}