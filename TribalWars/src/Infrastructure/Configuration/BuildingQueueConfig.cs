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
    class BuildingQueueConfig : IEntityTypeConfiguration<BuildingQueue>
    {
        public void Configure(EntityTypeBuilder<BuildingQueue> builder)
        {
            builder
                .HasKey(i => i.Id);

            builder
                .HasOne<Building>(b => b.Building)
                .WithMany(x => x.BuildingQueues)
                .HasForeignKey(b => b.BuildingId);

            builder
               .HasOne<Village>(v => v.Village)
               .WithMany(x => x.BuildingQueues)
               .HasForeignKey(v => v.VillageId);
        }
    }
}
