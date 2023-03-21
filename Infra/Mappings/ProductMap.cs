using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("Name")
                .HasColumnType("VARCHAR(80)");

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(180)
                .HasColumnName("description")
                .HasColumnType("VARCHAR(180)");

            builder.Property(x => x.Price)
                .IsRequired()
                .HasMaxLength(18)
                .HasColumnName("price")
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.ImageUrl)
               .IsRequired()
               .HasMaxLength(180)
               .HasColumnName("imageUrl")
               .HasColumnType("VARCHAR(180)");

            builder.Property(x => x.Category)
               .IsRequired()
               .HasMaxLength(180)
               .HasColumnName("category")
               .HasColumnType("VARCHAR(180)");
        }
    }
}
