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
    class StolenMaterialConfig : IEntityTypeConfiguration<StolenMaterial>
    {
        public void Configure(EntityTypeBuilder<StolenMaterial> builder)
        {
            builder.HasKey(stolenMaterial => stolenMaterial.Id);

            builder.HasOne<Attack>(stolenMaterial => stolenMaterial.Attack)
                .WithMany(attack => attack.StolenMaterials)
                .HasForeignKey(stolenMaterial => stolenMaterial.AttackId);

            builder.HasOne<Material>(stolenMaterial => stolenMaterial.Material)
               .WithMany(material => material.StolenMaterials)
               .HasForeignKey(stolenMaterial => stolenMaterial.MaterialId);
        }
    }
}
