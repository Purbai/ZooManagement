using System.ComponentModel.DataAnnotations;

namespace ZooManagement.Models.Database
{
    public class AnimalType
    {
        [Key]
        public int Id { get; set; }
        public string Species { get; set; }
        public string Classification { get; set; }
        public int Quantity { get; set; }

    }
}