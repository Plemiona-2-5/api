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
    public class RecruitmentQueueConfig : IEntityTypeConfiguration<RecruitmentQueue>
    {
        public void Configure(EntityTypeBuilder<RecruitmentQueue> builder)
        {
            builder.HasKey(i => i.Id);

            builder.HasOne<Village>(v => v.Village)
                .WithMany(x => x.RecruitmentQueues)
                .HasForeignKey(v => v.VillageId);

            builder.HasOne<ArmyUnitType>(a => a.ArmyUnitType)
               .WithMany(x => x.RecruitmentQueues)
               .HasForeignKey(m => m.ArmyUnitTypeId);
        }
    }
}
