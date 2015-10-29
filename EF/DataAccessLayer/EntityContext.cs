using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EF.Models;
using System.Data.Entity;

namespace EF.DataAccessLayer {
    public class EntityContext : DbContext {
        public DbSet<Employee> Employees { get; set; }
    }
}