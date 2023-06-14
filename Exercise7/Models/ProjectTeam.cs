namespace Exercise7.Models
{
    public class ProjectTeam
    {
        public int TeamID { get; set; }
        public int ProjectID { get; set; }
        public virtual Team Team { get; set; } = null!;
        public virtual Project Project { get; set; } = null!;
    }
}
