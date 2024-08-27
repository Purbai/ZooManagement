using System.ComponentModel.DataAnnotations;

namespace ZooManagement.Models.Request;

public class CreateEnclosureRequest
{
    [Required]
    public string EnclosureName { get; set; } = string.Empty;
    [Required]
    public int MaxNumberOfAnimals { get; set; }
}