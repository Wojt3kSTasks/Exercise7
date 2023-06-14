using Exercise7.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exercise7.Configurations
{
    public class ProjectTeamConfiguration : IEntityTypeConfiguration<ProjectTeam>
    {
        public void Configure(EntityTypeBuilder<ProjectTeam> builder)
        {
            builder.ToTable("Project_Team");

            builder.HasKey(e => new { IdPrescription = e.ProjectID, IdMedicament = e.TeamID });

            builder.HasOne(e => e.Team)
                .WithMany(e => e.ProjectTeams)
                .HasForeignKey(e => e.TeamID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Project)
                .WithMany(e => e.ProjectTeams)
                .HasForeignKey(e => e.ProjectID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new List<ProjectTeam>
            {
                new ProjectTeam
                {
                    ProjectID = 1,
                    TeamID = 1
                },
                new ProjectTeam
                {
                    ProjectID = 1,
                    TeamID = 3
                },
                new ProjectTeam
                {
                    ProjectID = 2,
                    TeamID = 2
                },
                new ProjectTeam
                {
                    ProjectID = 2,
                    TeamID = 1
                }
            });
        }
    }
}
