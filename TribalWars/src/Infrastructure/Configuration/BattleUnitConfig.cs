using ApplicationCore.Entities;
using ApplicationCore.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class BattleUnitConfig : IEntityTypeConfiguration<BattleUnit>
    {
        public void Configure(EntityTypeBuilder<BattleUnit> builder)
        {
            builder
                .HasKey(i => i.Id);

            builder
                .HasOne<Attack>(a => a.Attack)
                .WithMany(x => x.BattleUnits)
                .HasForeignKey(a => a.AttackId);

            builder
               .HasOne<ArmyUnitType>(a => a.ArmyUnitType)
               .WithMany(x => x.BattleUnits)
               .HasForeignKey(a => a.ArmyUnitTypeId);

            builder
                .Property(x => x.Side)
                .HasConversion
                    (v => v.ToString(),
                    v => (BattleSide)Enum.Parse(typeof(BattleSide), v));

        }
    }
}
