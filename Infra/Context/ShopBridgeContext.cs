using Domain.Entities;
using Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class ShopBridgeContext : DbContext
    {
        public ShopBridgeContext() 
        {}

        public ShopBridgeContext(DbContextOptions<ShopBridgeContext> options) : base(options) 
        {}

        public virtual DbSet<Products> Products { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductMap()); 
            //the ApplyConfiguration() method is used to apply the configuration of the ProductMap class which contains the mapping of the Product entity to the Products table.
        }

    }
}
