using System.Data.Entity;

namespace LuggaGo.DataLayer.Models
{
    public class LuggagoDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
    }
}