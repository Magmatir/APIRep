using Microsoft.EntityFrameworkCore;
using netnetnet.models;
using System.Configuration;

namespace netnetnet
{
    public class MainDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public MainDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=192.168.0.222;User=root;Password=is410601;Database=gorno23"); 
        }

        
    }
}
