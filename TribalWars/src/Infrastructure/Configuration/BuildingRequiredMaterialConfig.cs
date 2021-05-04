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
            builder.HasKey(buildingRequiredMaterial => buildingRequiredMaterial.Id);

            builder.HasOne<Building>(buildingRequiredMaterial => buildingRequiredMaterial.Building)
                .WithMany(building => building.BuildingRequiredMaterials)
                .HasForeignKey(buildingRequiredMaterial => buildingRequiredMaterial.BuildingId);

            builder.HasOne<Material>(buildingRequiredMaterial => buildingRequiredMaterial.Material)
               .WithMany(material => material.BuildingRequiredMaterials)
               .HasForeignKey(buildingRequiredMaterial => buildingRequiredMaterial.MaterialId);
        }
    }
}
