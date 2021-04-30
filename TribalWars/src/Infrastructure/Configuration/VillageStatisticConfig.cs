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
    public class VillageStatisticConfig : IEntityTypeConfiguration<VillageStatistic>
    {
        public void Configure(EntityTypeBuilder<VillageStatistic> builder)
        {
            builder.HasKey(i => i.Id);

            builder.HasOne<Village>(v => v.Village)
                .WithOne(x => x.VillageStatistic)
                .HasForeignKey<VillageStatistic>(v => v.VillageId);
        }
    }
}
