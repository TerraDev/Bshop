using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpyWire.Model;
using System;

namespace SpyWire.Infrastructure
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<SpyWareItem> SpyWareItems { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
