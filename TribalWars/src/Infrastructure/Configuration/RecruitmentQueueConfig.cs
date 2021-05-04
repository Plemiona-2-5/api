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
            builder.HasKey(recruitmentQueue => recruitmentQueue.Id);

            builder.HasOne<Village>(recruitmentQueue => recruitmentQueue.Village)
                .WithMany(village => village.RecruitmentQueues)
                .HasForeignKey(recruitmentQueue => recruitmentQueue.VillageId);

            builder.HasOne<ArmyUnitType>(recruitmentQueue => recruitmentQueue.ArmyUnitType)
               .WithMany(armyUnitType => armyUnitType.RecruitmentQueues)
               .HasForeignKey(recruitmentQueue => recruitmentQueue.ArmyUnitTypeId);
        }
    }
}
