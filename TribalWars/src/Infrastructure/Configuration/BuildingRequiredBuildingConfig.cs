using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    class BuildingRequiredBuildingConfig : IEntityTypeConfiguration<BuildingRequiredBuilding>
    {
        public void Configure(EntityTypeBuilder<BuildingRequiredBuilding> builder)
        {
            builder.HasKey(buildingRequiredBuilding => buildingRequiredBuilding.Id);

            builder.HasOne<Building>(buildingRequiredBuilding => buildingRequiredBuilding.Building)
                .WithMany(building => building.BuildingRequiredBuildings)
                .HasForeignKey(buildingRequiredBuilding => buildingRequiredBuilding.BuildingId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<RequiredBuilding>(buildingRequiredBuilding => buildingRequiredBuilding.RequiredBuilding)
                .WithMany(requiredBuildings => requiredBuildings.Buildings)
                .HasForeignKey(buildingRequiredBuilding => buildingRequiredBuilding.RequiredBuildingId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
