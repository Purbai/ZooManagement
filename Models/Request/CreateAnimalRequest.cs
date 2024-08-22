using System.ComponentModel.DataAnnotations;
using ZooManagement.Models.Database;

namespace ZooManagement.Models.Request
{
    public class CreateAnimalRequest
    {
        [Required]
        public string Name { get; set; }
        public int AnimalTypeId { get; set; }
        public string Sex { get; set; }
        public string BirthDate { get; set; }
        public string AcquiredDate { get; set; }
        
    }
}