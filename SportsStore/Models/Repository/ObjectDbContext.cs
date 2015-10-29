using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SportsStore.Models.Repository {
    public class ObjectDbContext : DbContext {
        public DbSet<Product> Products { get; set; }
    }
}