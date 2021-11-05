using KikiShop.Domain.Merchants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KikiShop.Infrastructure.KikiShop.Database.Database.Configuration
{
 
    internal sealed class MerchantConfiguration : IEntityTypeConfiguration<Merchant>
    {
        public void Configure(EntityTypeBuilder<Merchant> builder)
        {
            builder.ToTable(nameof(Merchant), "dbo");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
            .HasConversion(
                v => v.Value,
                v => new MerchantId(v));

            builder.Property(c => c.Email)
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(c => c.Name)
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();
        }
    }

}
