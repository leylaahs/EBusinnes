using E_business.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_business.DAL
{
    public class AppDbContext:IdentityDbContext<Appuser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Appuser> Appusers{ get; set; }
    }
}
