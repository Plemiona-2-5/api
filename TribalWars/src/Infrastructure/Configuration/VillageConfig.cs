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
    class VillageConfig : IEntityTypeConfiguration<Village>
    {
        public void Configure(EntityTypeBuilder<Village> builder)
        {
            builder.HasKey(village => village.Id);

            builder.HasOne<Player>(village => village.Player)
                .WithOne(player => player.Village)
                .HasForeignKey<Village>(village => village.PlayerId);
        }
    }
}
