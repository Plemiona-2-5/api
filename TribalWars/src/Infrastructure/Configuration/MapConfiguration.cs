using ApplicationCore.Entities;
using ApplicationCore.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class MapConfiguration : IEntityTypeConfiguration<Map>
    {
        public void Configure(EntityTypeBuilder<Map> builder)
        {
            builder
                .HasKey(map => map.Id);

            builder
                .Property(map => map.SideSize)
                .HasDefaultValue(DefaultMapSettings.DefaultSideSize);
            
            builder
                .Property(map => map.Capacity)
                .HasDefaultValue(DefaultMapSettings.DefaultCapacity);
        }
    }
}