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
    class BuildingRequiredBuildingConfig : IEntityTypeConfiguration<BuildingRequiredBuilding>
    {
        public void Configure(EntityTypeBuilder<BuildingRequiredBuilding> builder)
        {
            builder.HasKey(buildingRequiredBuilding => buildingRequiredBuilding.Id);

            builder.HasOne<Building>(buildingRequiredBuilding => buildingRequiredBuilding.Building)
                .WithMany(building => building.BuildingRequiredBuildings)
                .HasForeignKey(buildingRequiredBuilding => buildingRequiredBuilding.BuildingId);
        }
    }
}
