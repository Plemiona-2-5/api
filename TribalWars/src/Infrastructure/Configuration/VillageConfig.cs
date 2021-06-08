using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    class VillageConfig : IEntityTypeConfiguration<Village>
    {
        public void Configure(EntityTypeBuilder<Village> builder)
        {
            builder
                .HasKey(village => village.Id);

            builder
                .HasOne(village => village.Player)
                .WithOne(player => player.Village)
                .HasForeignKey<Village>(village => village.PlayerId);

            builder
                .HasOne(village => village.Map)
                .WithMany(map => map.Villages)
                .HasForeignKey(village => village.MapId);
        }
    }
}