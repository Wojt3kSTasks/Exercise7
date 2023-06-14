using Exercise7.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exercise7.Configurations
{
    public class ProjectStatusConfiguration : IEntityTypeConfiguration<ProjectStatus>
    {
        public void Configure(EntityTypeBuilder<ProjectStatus> builder)
        {
            builder.ToTable("Project_Status");

            builder.HasKey(e => e.ID);

            builder.Property(e => e.Name).HasMaxLength(50);

            builder.HasData(new List<ProjectStatus>
            {
                new ProjectStatus {
                    ID = 1,
                    Name = "Started",
                },
                new ProjectStatus {
                    ID = 2,
                    Name = "Finished",
                }
            });
        }
    }
}
