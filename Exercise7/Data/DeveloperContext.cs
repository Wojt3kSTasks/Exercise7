using Exercise7.Configurations;
using Exercise7.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercise7.Data
{
    public class DeveloperContext : DbContext
    {
        public DbSet<Developer> Developers { get; set; }
        public DbSet<ProjectStatus> ProjectStatuses { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTeam> ProjectTeams { get; set; }

        public DeveloperContext(DbContextOptions options) : base(options)
        {
        }

        protected DeveloperContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DeveloperConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectStatusConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectTeamConfiguration());
        }
    }
}
