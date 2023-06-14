using System.ComponentModel.DataAnnotations;

namespace Exercise7.Models.DTOs;

public class NewDeveloperDTO
{
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } = null!;
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; } = null!;
}