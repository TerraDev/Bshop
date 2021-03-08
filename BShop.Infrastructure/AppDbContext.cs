using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BShop.Model;
using System;

namespace BShop.Infrastructure
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<BShopItem> SpyWareItems { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
