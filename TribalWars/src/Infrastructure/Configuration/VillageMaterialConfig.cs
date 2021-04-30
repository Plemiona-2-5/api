using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    class VillageMaterialConfig : IEntityTypeConfiguration<VillageMaterial>
    {
        public void Configure(EntityTypeBuilder<VillageMaterial> builder)
        {
            builder.HasKey(i => i.Id);

            builder.HasOne<Material>(m => m.Material)
                .WithMany(x => x.VillageMaterials)
                .HasForeignKey(m => m.MaterialId);

            builder.HasOne<Village>(v => v.Village)
                .WithMany(x => x.VillageMaterials)
                .HasForeignKey(v => v.VillageId);

        }
    }
}
