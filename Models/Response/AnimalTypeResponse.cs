
using ZooManagement.Models.Database;

namespace ZooManagement.Models.Response
{
    public class AnimalTypeResponse
    {
        private readonly AnimalType _animalType;

        public AnimalTypeResponse(AnimalType animalType)
        {
            _animalType = animalType;
        }

        public int Id => _animalType.Id;
        public string Species => _animalType.Species;
        public string Classification => _animalType.Classification;
        public int Quantity => _animalType.Quantity;

    }

}