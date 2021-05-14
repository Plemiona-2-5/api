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
    class RequiredBuildingConfig : IEntityTypeConfiguration<RequiredBuilding>
    {
        public void Configure(EntityTypeBuilder<RequiredBuilding> builder)
        {
            builder.HasKey(rb => rb.Id);

            builder.HasMany(rb => rb.Buildings)
                .WithOne(brb => brb.RequiredBuilding)
                .HasForeignKey(brb => brb.RequiredBuildingId);

            builder.HasOne<Building>(rb => rb.ReqBuilding)
                .WithOne(brb => brb.RequiredBuilding)
                .HasForeignKey<RequiredBuilding>(brb => brb.ReqBuildingId);
        }
    }
}
