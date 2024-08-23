using ZooManagement.Models.Database;

namespace ZooManagement.Models.Response
{
    public class AnimalResponse
    {
        private readonly Animal _animal;

        public AnimalResponse(Animal animal)
        {
            _animal = animal;
        }

        public int Id => _animal.Id;
        public string Name => _animal.Name;
        public int AnimalTypeId => _animal.AnimalTypeId;
        public string Sex => _animal.Sex;
        public DateOnly BirthDate => _animal.BirthDate;
        public DateOnly AcquiredDate => _animal.AcquiredDate;
    }
}