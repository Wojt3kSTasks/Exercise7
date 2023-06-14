namespace Exercise7.Models
{
    public class ProjectStatus
    {
        public int ID { get; set; }
        public string Name { get; set; } = null!;
        public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}
