using ZooManagement.Models.Database;
using ZooManagement.Models.Request;

namespace ZooManagement.Repositories
{
    public interface IAnimalsRepo
    {
        Animal GetById(int id);
        Animal Create(CreateAnimalRequest animal);
        IEnumerable<Animal> Search(AnimalSearchRequest search);
        int Count(AnimalSearchRequest search);
    }

    public class AnimalsRepo : IAnimalsRepo
    {
        private readonly ZooManagementDbContext _context;

        public AnimalsRepo(ZooManagementDbContext context)
        {
            _context = context;
        }

        public Animal GetById(int id)
        {
            return _context.Animals.Single(animal => animal.Id == id);
        }

        public IEnumerable<Animal> Search(AnimalSearchRequest search)
        {
            return _context.Animals
                .Where(p => search.AnimalTypeId == null || p.AnimalTypeId == search.AnimalTypeId)
                .Skip((search.Page - 1) * search.PageSize)
                .Take(search.PageSize);
        }

        public int Count(AnimalSearchRequest search)
        {
            return _context.Animals
                .Count(p => search.AnimalTypeId == null || p.AnimalTypeId == search.AnimalTypeId);
        }


        public Animal Create(CreateAnimalRequest animal)
        {
            var insertResult = _context.Animals.Add(new Animal
            {
                Name = animal.Name,
                AnimalTypeId = animal.AnimalTypeId,
                Sex = animal.Sex,
                BirthDate = DateOnly.Parse(animal.BirthDate),
                AcquiredDate = DateOnly.Parse(animal.AcquiredDate),
            });

            _context.SaveChanges();
            return insertResult.Entity;
        }
    }
}