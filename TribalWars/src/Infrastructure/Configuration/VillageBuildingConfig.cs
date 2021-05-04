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
    public class VillageBuildingConfig : IEntityTypeConfiguration<VillageBuilding>
    {
        public void Configure(EntityTypeBuilder<VillageBuilding> builder)
        {
            builder.HasKey(villageBuilding => villageBuilding.Id);

            builder.HasOne<Village>(villageBuilding => villageBuilding.Village)
                .WithMany(village => village.VillageBuildings)
                .HasForeignKey(villageBuilding => villageBuilding.VillageId);

            builder.HasOne<Building>(villageBuilding => villageBuilding.Building)
                .WithMany(building => building.VillageBuildings)
                .HasForeignKey(villageBuilding => villageBuilding.BuildingId);
        }
    }
}
