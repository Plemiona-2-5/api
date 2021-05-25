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
    public class TribeConfig : IEntityTypeConfiguration<Tribe>
    {
        public void Configure(EntityTypeBuilder<Tribe> builder)
        {
            builder.HasKey(tribe => tribe.Id);

            builder.HasMany(tribe => tribe.TribePlayers)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
