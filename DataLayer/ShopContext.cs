using DataLayer.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class ShopContext: DbContext
    {
        public DbSet<Brend> Brends { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<OrderShop> orderShops { get; set; }
        public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }

    }
    /// <summary>
    /// For Migrations
    /// </summary>
    public class ShopContextFactory : IDesignTimeDbContextFactory<ShopContext>
    {
        public ShopContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ShopContext>();
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ShopDb;Trusted_Connection=True;", b => b.MigrationsAssembly("DataLayer")) ;

            return new ShopContext(optionsBuilder.Options);
        }
    }
}
