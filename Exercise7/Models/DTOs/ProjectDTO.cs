namespace Exercise7.Models.DTOs;

public class ProjectDTO
{
    public int ID { get; set; }
    public string Name { get; set; } = null!;
    public DateTime Deadline { get; set; }
    public string ProjectStatus { get; set; } = null!;
}