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
            builder.HasKey(i => i.Id);

            builder.HasOne<Attack>(a => a.Attack)
                .WithMany(x => x.StolenMaterials)
                .HasForeignKey(a => a.AttackId);

            builder.HasOne<Material>(m => m.Material)
               .WithMany(x => x.StolenMaterials)
               .HasForeignKey(m => m.MaterialId);
        }
    }
}
