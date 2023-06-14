using Exercise7.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exercise7.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Project");

            builder.HasKey(e => e.ID);

            builder.HasOne(e => e.ProjectStatus)
                .WithMany(e => e.Projects)
                .HasForeignKey(e => e.ProjectStatusID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new List<Project>
            {
                new Project
                {
                    ID = 1,
                    Deadline = DateTime.Parse("2023-05-28"),
                    Name = "Project 1",
                    ProjectStatusID = 2
                },
                new Project
                {
                    ID = 2,
                    Deadline = DateTime.Parse("2023-05-31"),
                    Name = "Project 2", 
                    ProjectStatusID = 1
                },
                new Project
                {
                    ID = 3,
                    Deadline = DateTime.Parse("2023-06-01"),
                    Name = "Project 3",
                    ProjectStatusID = 1
                }
            });
        }
    }
}
