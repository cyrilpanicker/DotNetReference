using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EFReference {
    public class ObjectDbContext :DbContext{
        public DbSet<Employee> Employees { get; set; }
    }
}