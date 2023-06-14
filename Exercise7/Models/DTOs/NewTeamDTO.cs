using System.ComponentModel.DataAnnotations;

namespace Exercise7.Models.DTOs;

public class NewTeamDTO
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;
    public IEnumerable<NewDeveloperDTO> Developers { get; set; } = null!;
}