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
                .HasKey(battleUnit => battleUnit.Id);

            builder
                .HasOne<Attack>(battleUnit => battleUnit.Attack)
                .WithMany(attack => attack.BattleUnits)
                .HasForeignKey(battleUnit => battleUnit.AttackId);

            builder
               .HasOne<ArmyUnitType>(battleUnit => battleUnit.ArmyUnitType)
               .WithMany(armyUnitType => armyUnitType.BattleUnits)
               .HasForeignKey(battleUnit => battleUnit.ArmyUnitTypeId);

            builder
                .Property(battleUnit => battleUnit.Side)
                .HasConversion
                    (battleSide => battleSide.ToString(),
                    battleSide => (BattleSide)Enum.Parse(typeof(BattleSide), battleSide));
        }
    }
}
