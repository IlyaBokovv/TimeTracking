using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracking.Data.Models;

namespace TimeTracking.Data.Configuration
{
    public class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.Property(u => u.Id)
            .HasColumnName("ReportId");

            builder.HasKey(u => u.Id);

            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.WorkedHours).IsRequired();
            builder.Property(x => x.Date).IsRequired();

            builder.HasData(
                new Report
                {
                    Id = new Guid("db0abfe7-bf93-41fa-a537-396e76faaced"),
                    Date = DateOnly.FromDateTime(new DateTime(2023, 9, 15)),
                    Description = "Regular job",
                    WorkedHours = 8,
                    UserId = new Guid("da9d87e1-f84a-484a-997d-bea07b6fa9ea")
                },
                new Report
                {
                    Id = new Guid("33502293-c17a-4ef8-ac61-75c62ecde637"),
                    Date = DateOnly.FromDateTime(new DateTime(2023, 9, 15)),
                    Description = "Extra hours",
                    WorkedHours = 3,
                    UserId = new Guid("da9d87e1-f84a-484a-997d-bea07b6fa9ea")
                },
                new Report
                {
                    Id = new Guid("b541ca9d-7257-47be-b812-5bbdbb588216"),
                    Date = DateOnly.FromDateTime(new DateTime(2023, 9, 15)),
                    Description = "Regular job",
                    WorkedHours = 8,
                    UserId = new Guid("20da4841-4a17-42e6-bd69-6a7025160082")
                }
                );
        }
    }
}
