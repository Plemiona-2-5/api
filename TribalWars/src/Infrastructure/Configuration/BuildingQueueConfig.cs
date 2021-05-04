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
                .HasKey(buildingQueue => buildingQueue.Id);

            builder
                .HasOne<Building>(buildingQueue => buildingQueue.Building)
                .WithMany(building => building.BuildingQueues)
                .HasForeignKey(buildingQueue => buildingQueue.BuildingId);

            builder
               .HasOne<Village>(buildingQueue => buildingQueue.Village)
               .WithMany(village => village.BuildingQueues)
               .HasForeignKey(buildingQueue => buildingQueue.VillageId);
        }
    }
}
