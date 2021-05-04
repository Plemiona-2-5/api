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
            builder.HasKey(i => i.Id);

            builder.HasOne<Player>(p => p.Player)
                .WithOne(x => x.Village)
                .HasForeignKey<Village>(v => v.PlayerId);
        }
    }
}
