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
            builder.HasKey(i => i.Id);

            builder.HasOne<Village>(v => v.Village)
                .WithMany(x => x.AttackVillages)
                .HasForeignKey(v => v.VillageId);

            builder.HasOne<Attack>(a => a.Attack)
                .WithMany(x => x.AttackVillages)
                .HasForeignKey(a => a.AttackId);

            builder
                .Property(x => x.BattleSide)
                .HasConversion
                    (v => v.ToString(),
                    v => (BattleSide)Enum.Parse(typeof(BattleSide), v));
        }
    }
}
