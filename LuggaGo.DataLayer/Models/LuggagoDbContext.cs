using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LuggaGo.Models
{
    public class LuggagoDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
    }
}