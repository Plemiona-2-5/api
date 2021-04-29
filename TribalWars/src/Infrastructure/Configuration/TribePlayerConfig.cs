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
    public class TribePlayerConfig : IEntityTypeConfiguration<TribePlayer>
    {
        public void Configure(EntityTypeBuilder<TribePlayer> builder)
        {
            builder.HasKey(i => i.Id);

            builder.HasOne<Player>(p => p.Player)
                .WithMany(x => x.TribePlayer)
                .HasForeignKey(p => p.PlayerId);

            builder.HasOne<Tribe>(p => p.Tribe)
                .WithOne(x => x.TribePlayers)
                .HasForeignKey<TribePlayer>(p => p.TribeId);

            builder
                .Property(x => x.TribeRole)
                .HasConversion
                    (v => v.ToString(),
                    v => (TribeRole)Enum.Parse(typeof(TribeRole), v));
        }
    }
}
