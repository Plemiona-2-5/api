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
            builder.HasKey(tribePlayer => tribePlayer.Id);

            builder.HasOne<Player>(tribePlayer => tribePlayer.Player)
                .WithMany(player => player.TribePlayer)
                .HasForeignKey(tribePlayer => tribePlayer.PlayerId);

            builder.HasOne<Tribe>(tribePlayer => tribePlayer.Tribe)
                .WithOne(tribe => tribe.TribePlayers)
                .HasForeignKey<TribePlayer>(tribePlayer => tribePlayer.TribeId);

            builder
                .Property(tribePlayer => tribePlayer.TribeRole)
                .HasConversion
                    (tribeRole => tribeRole.ToString(),
                    tribeRole => (TribeRole)Enum.Parse(typeof(TribeRole), tribeRole));
        }
    }
}
