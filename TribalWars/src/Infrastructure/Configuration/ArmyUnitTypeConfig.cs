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
    public class ArmyUnitTypeConfig : IEntityTypeConfiguration<ArmyUnitType>
    {
        public void Configure(EntityTypeBuilder<ArmyUnitType> builder)
        {
            builder.HasKey(i => i.Id);
            builder.HasOne<Building>(b => b.RequiredBuilding)
                .WithMany(x => x.ArmyUnitTypes)
                .HasForeignKey(x => x.RequiredBuildingId);
        }
    }
}
