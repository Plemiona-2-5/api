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
    public class AttackConfig : IEntityTypeConfiguration<Attack>
    {
        public void Configure(EntityTypeBuilder<Attack> builder)
        {
            builder.HasKey(i => i.Id);

            builder.HasOne<Village>(v => v.DefenderVillage)
                .WithMany(x => x.Attacks)
                .HasForeignKey(x => x.DefenderVillageId);

            builder.HasOne<Village>(v => v.AttackerVillage)
                .WithMany(x => x.Attacks)
                .HasForeignKey(x => x.AttackerVillageId);
        }

    }
}