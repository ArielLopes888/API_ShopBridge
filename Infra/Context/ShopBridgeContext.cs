using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
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
            => optionsBuilder.UseSqlServer();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.ApplyConfiguration(new UserMap());
        }

    }
}
