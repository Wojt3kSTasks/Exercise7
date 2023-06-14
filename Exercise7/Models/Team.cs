namespace Exercise7.Models
{
    public class Team
    {
        public int ID { get; set; }
        public string Name { get; set; } = null!;
        public virtual ICollection<ProjectTeam> ProjectTeams { get; set; } = new List<ProjectTeam>();
        
        public virtual IEnumerable<Developer> Developers { get; set; } = new List<Developer>();
    }
}
