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
    public class VillageUnitConfig : IEntityTypeConfiguration<VillageUnit>
    {
        public void Configure(EntityTypeBuilder<VillageUnit> builder)
        {
            builder.HasKey(villageUnit => villageUnit.Id);

            builder.HasOne<Village>(villageUnit => villageUnit.Village)
                .WithMany(village => village.VillageUnits)
                .HasForeignKey(villageUnit => villageUnit.VillageId);

            builder.HasOne<ArmyUnitType>(villageUnit => villageUnit.ArmyUnitType)
                .WithMany(armyUnitType => armyUnitType.VillageUnits)
                .HasForeignKey(villageUnit => villageUnit.ArmyUnitTypeId);
        }
    }
}
