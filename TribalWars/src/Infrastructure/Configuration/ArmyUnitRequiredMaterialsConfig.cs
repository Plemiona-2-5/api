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
    public class ArmyUnitRequiredMaterialsConfig : IEntityTypeConfiguration<ArmyUnitRequiredMaterial>
    {
        public void Configure(EntityTypeBuilder<ArmyUnitRequiredMaterial> builder)
        {
            builder.HasKey(i => i.Id);

            builder.HasOne<ArmyUnitType>(a => a.ArmyUnitType)
                .WithMany(x => x.ArmyUnitRequiredMaterials)
                .HasForeignKey(x => x.ArmyUnitTypeId);

            builder.HasOne<Material>(m => m.Material)
                .WithMany(m => m.ArmyUnitRequiredMaterials)
                .HasForeignKey(x => x.MaterialId);
        }
    }
}
