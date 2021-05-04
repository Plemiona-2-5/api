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
    class AttackReportConfig : IEntityTypeConfiguration<AttackReport>
    {
        public void Configure(EntityTypeBuilder<AttackReport> builder)
        {
            builder.HasKey(attackReport => attackReport.Id);

            builder.HasOne<Attack>(attackReport => attackReport.Attack)
                .WithOne(attack => attack.AttackReport)
                .HasForeignKey<AttackReport>(attackReport => attackReport.AttackId);
        }

    }
}
