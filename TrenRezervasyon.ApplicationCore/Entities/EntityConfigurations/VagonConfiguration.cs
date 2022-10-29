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
    internal class VagonConfiguration : IEntityTypeConfiguration<Vagon>
    {
        public void Configure(EntityTypeBuilder<Vagon> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Ad).IsRequired();
            builder.Property(x => x.Kapasite).IsRequired();
            builder.Property(x => x.DoluKoltukAdet).IsRequired();
            builder.HasOne(x => x.Tren).WithMany(x => x.Vagonlar).HasForeignKey(x => x.TrenId);
        }
    }
}
