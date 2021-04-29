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
            builder.HasKey(i => i.Id);

            builder.HasOne<Attack>(a => a.Attack)
                .WithOne(x => x.AttackReport)
                .HasForeignKey<AttackReport>(a => a.AttackId);

        }

    }
}
