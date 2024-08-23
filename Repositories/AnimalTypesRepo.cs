using ZooManagement.Models.Database;
using ZooManagement.Models.Request;

namespace ZooManagement.Repositories
{
    public interface IAnimalTypesRepo
    {
        List<AnimalType> GetAllAnimalTypes();
        AnimalType GetById(int id);
        AnimalType Create(CreateAnimalTypeRequest animalType);

        
    }

    public class AnimalTypesRepo : IAnimalTypesRepo
    {
        private readonly ZooManagementDbContext _context;

        public AnimalTypesRepo(ZooManagementDbContext context)
        {
            _context = context;
        }


        public List<AnimalType> GetAllAnimalTypes(){
            return _context.AnimalTypes.ToList();
        }
        public AnimalType GetById(int id){
            return _context.AnimalTypes.Single(animalType => animalType.Id == id);
        }
        
        public AnimalType Create(CreateAnimalTypeRequest animalType)
        {
            var insertResult = _context.AnimalTypes.Add(new AnimalType 
            {
                Species = animalType.Species,
                Classification = animalType.Classification,
                Quantity = animalType.Quantity,
            });
            _context.SaveChanges();
            return insertResult.Entity;
        }
    }
}