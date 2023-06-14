using Exercise7.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exercise7.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable("Team");

            builder.HasKey(e => e.ID);

            builder.Property(e => e.Name).HasMaxLength(50);

            builder.HasData(new List<Team>
            {
                new Team
                {
                    ID = 1,
                    Name = "Team 1"
                },
                new Team
                {
                    ID = 2,
                    Name = "Team 2"
                },
                new Team
                {
                    ID = 3,
                    Name = "Team 3"
                }
            });
        }
    }
}
