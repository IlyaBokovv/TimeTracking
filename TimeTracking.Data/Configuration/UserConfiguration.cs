using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TimeTracking.Data.Models;

namespace TimeTracking.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Id)
            .HasColumnName("UserId");

            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.Email).IsUnique();
                             
            builder.Property(u => u.FirstName).IsRequired();
            builder.Property(u => u.MiddleName).IsRequired();
            builder.Property(u => u.LastName).IsRequired();

            builder.HasData(
                new User
                {
                    Id = new Guid("20da4841-4a17-42e6-bd69-6a7025160082"),
                    Email = "testmail@mail.ru",
                    FirstName = "Elon",
                    MiddleName = "Viktorovich",
                    LastName = "Musk"
                },

                new User
                {
                    Id = new Guid("da9d87e1-f84a-484a-997d-bea07b6fa9ea"),
                    Email = "testmail@yandex.ru",
                    FirstName = "Vladimir",
                    MiddleName = "Ilyich",
                    LastName = "Lenin"
                }
                );

        }
    }
}
