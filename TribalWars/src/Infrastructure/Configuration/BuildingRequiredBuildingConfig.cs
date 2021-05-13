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
                .HasForeignKey(buildingRequiredBuilding => buildingRequiredBuilding.BuildingId);

            builder.HasOne<RequiredBuilding>(buildingRequiredBuilding => buildingRequiredBuilding.RequiredBuilding)
                .WithMany(requiredBuildings => requiredBuildings.Buildings)
                .HasForeignKey(buildingRequiredBuilding => buildingRequiredBuilding.RequiredBuildingId);

            builder.HasOne(rbr => rbr.RequiredBuilding)
                    .WithMany(rb => rb.Buildings)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(rbr => rbr.Building)
                    .WithMany(rb => rb.BuildingRequiredBuildings)
                    .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
