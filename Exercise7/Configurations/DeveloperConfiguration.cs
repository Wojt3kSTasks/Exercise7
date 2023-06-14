using Exercise7.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exercise7.Configurations
{
    public class DeveloperConfiguration : IEntityTypeConfiguration<Developer>
    {
        public void Configure(EntityTypeBuilder<Developer> builder)
        {
            builder.ToTable("Developer");

            builder.HasKey(e => e.ID);

            builder.Property(e => e.FirstName).HasMaxLength(50);
            builder.Property(e => e.LastName).HasMaxLength(50);

            builder.HasOne(e => e.Team)
                .WithMany(e => e.Developers)
                .HasForeignKey(e => e.TeamID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new List<Developer>
            {
                new Developer { 
                    ID = 1,
                    FirstName = "Jan",
                    LastName = "Piarski",
                    TeamID = 1
                },
                new Developer {
                    ID = 2,
                    FirstName = "Anna",
                    LastName = "Jenkinsowa",
                    TeamID = 1
                },
                new Developer {
                    ID = 3,
                    FirstName = "Piotr",
                    LastName = "Bambik",
                    TeamID = 1
                },
                new Developer {
                    ID = 4,
                    FirstName = "Magda",
                    LastName = "Logowaczenko",
                    TeamID = 2
                },
                new Developer {
                    ID = 5,
                    FirstName = "Robert",
                    LastName = "Bugowski",
                    TeamID = 2
                },
                new Developer {
                    ID = 6,
                    FirstName = "Katarzyna",
                    LastName = "Testonaprodna",
                    TeamID = 3
                }
            });
        }
    }
}
