namespace Exercise7.Models
{
    public class Project
    {
        public int ID { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Deadline { get; set; }
        public int ProjectStatusID { get; set; }
        public virtual ProjectStatus ProjectStatus { get; set; } = null!;
        public virtual ICollection<ProjectTeam> ProjectTeams { get; set; } = new List<ProjectTeam>();
    }
}
