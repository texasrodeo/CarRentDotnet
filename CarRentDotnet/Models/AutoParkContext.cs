using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CarRentDotnet.Models
{
    public class AutoParkContext: DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Contract> Contracts { get; set; }
       // public DbSet<Contract> Requests { get; set; }
    }
}