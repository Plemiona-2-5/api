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
            builder.HasKey(armyUnitRequiredMaterial => armyUnitRequiredMaterial.Id);

            builder.HasOne<ArmyUnitType>(armyUnitRequiredMaterial => armyUnitRequiredMaterial.ArmyUnitType)
                .WithMany(armyUnitType => armyUnitType.ArmyUnitRequiredMaterials)
                .HasForeignKey(armyUnitRequiredMaterial => armyUnitRequiredMaterial.ArmyUnitTypeId);

            builder.HasOne<Material>(m => m.Material)
                .WithMany(au => au.ArmyUnitRequiredMaterials)
                .HasForeignKey(a => a.MaterialId);
        }
    }
}
