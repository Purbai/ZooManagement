using System.ComponentModel.DataAnnotations;

namespace ZooManagement.Models.Request
{
    public class CreateAnimalRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int AnimalTypeId { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        public string BirthDate { get; set; }
        [Required]
        public string AcquiredDate { get; set; }
    }
}