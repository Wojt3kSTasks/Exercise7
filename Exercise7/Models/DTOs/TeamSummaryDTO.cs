namespace Exercise7.Models.DTOs;

public class TeamSummaryDTO
{
    public int ID { get; set; }
    public string Name { get; set; } = null!;
    public int DevelopersCount { get; set; }
    public IEnumerable<ProjectDTO> Projects { get; set; } = null!;
}