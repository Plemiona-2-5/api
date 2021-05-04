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
    public class BuildingRequiredMaterialConfig : IEntityTypeConfiguration<BuildingRequiredMaterial>
    {
        public void Configure(EntityTypeBuilder<BuildingRequiredMaterial> builder)
        {
            builder.HasKey(i => i.Id);

            builder.HasOne<Building>(b => b.Building)
                .WithMany(x => x.BuildingRequiredMaterials)
                .HasForeignKey(b => b.BuildingId);

            builder.HasOne<Material>(m => m.Material)
               .WithMany(x => x.BuildingRequiredMaterials)
               .HasForeignKey(m => m.MaterialId);
        }
    }
}
