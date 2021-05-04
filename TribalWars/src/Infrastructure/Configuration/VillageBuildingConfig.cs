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
            builder.HasKey(i => i.Id);

            builder.HasOne<Village>(v => v.Village)
                .WithMany(x => x.VillageBuildings)
                .HasForeignKey(v => v.VillageId);

            builder.HasOne<Building>(b => b.Building)
                .WithMany(x => x.VillageBuildings)
                .HasForeignKey(b => b.BuildingId);
        }
    }
}
