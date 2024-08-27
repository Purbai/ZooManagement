namespace ZooManagement.Models.Database;

public class Enclosure
{
    public int EnclosureId { get; set; }
    public string EnclosureName { get; set; } = string.Empty;
    public int MaxNumberOfAnimals { get; set; }
}