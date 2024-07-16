using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucure.Data.Config
{
    public class ProductConfigration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(P => P.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Price).HasColumnType("decimal");
            builder.Property(P => P.PictureUrl).IsRequired();
            builder.HasOne(P => P.ProductBrand).WithMany().HasForeignKey(P => P.ProductBrandId);
            builder.HasOne(P => P.ProductType).WithMany().HasForeignKey(P => P.ProductTypeId);


        }
    }
}
