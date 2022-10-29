using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrenRezervasyon.ApplicationCore.Entities.Concrete;

namespace TrenRezervasyon.ApplicationCore.Entities.EntityConfigurations
{
    internal class TrenConfiguration : IEntityTypeConfiguration<Tren>
    {
        public void Configure(EntityTypeBuilder<Tren> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Ad).IsRequired();
            builder.HasMany(x => x.Vagonlar).WithOne(x => x.Tren).HasForeignKey(x => x.TrenId);
        }
    }
}
