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
            builder.HasKey(villageMaterial => villageMaterial.Id);

            builder.HasOne<Material>(villageMaterial => villageMaterial.Material)
                .WithMany(material => material.VillageMaterials)
                .HasForeignKey(villageMaterial => villageMaterial.MaterialId);

            builder.HasOne<Village>(villageMaterial => villageMaterial.Village)
                .WithMany(vilage => vilage.VillageMaterials)
                .HasForeignKey(villageMaterial => villageMaterial.VillageId);
        }
    }
}
