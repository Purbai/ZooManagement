using System.ComponentModel.DataAnnotations;

namespace ZooManagement.Models.Request
{
    public class CreateAnimalTypeRequest
    {
        [Required]
        public string Species { get; set; }
        
        [Required]
        public string Classification { get; set; }
        
        [Required]
        public int Quantity { get; set; }
    }
}
