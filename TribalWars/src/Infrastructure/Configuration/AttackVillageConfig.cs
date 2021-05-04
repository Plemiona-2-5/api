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
    public class AttackVillageConfig : IEntityTypeConfiguration<AttackVillage>
    {
        public void Configure(EntityTypeBuilder<AttackVillage> builder)
        {
            builder.HasKey(attackVillage => attackVillage.Id);

            builder.HasOne<Village>(attackVillage => attackVillage.Village)
                .WithMany(village => village.AttackVillages)
                .HasForeignKey(attackVillage => attackVillage.VillageId);

            builder.HasOne<Attack>(attackVillage => attackVillage.Attack)
                .WithMany(attack => attack.AttackVillages)
                .HasForeignKey(attackVillage => attackVillage.AttackId);

            builder
                .Property(attackVillage => attackVillage.BattleSide)
                .HasConversion
                    (battleSide => battleSide.ToString(),
                    battleSide => (BattleSide)Enum.Parse(typeof(BattleSide), battleSide));
        }
    }
}
