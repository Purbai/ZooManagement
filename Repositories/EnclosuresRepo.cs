using ZooManagement.Models.Database;
using ZooManagement.Models.Request;

namespace ZooManagement.Repositories
{
    public interface IEnclosuresRepo
    {
        Enclosure GetById(int id);
        Enclosure Create(CreateEnclosureRequest enclosureRequest);
        IEnumerable<Enclosure> Search(EnclosureSearchRequest search);
        int Count(EnclosureSearchRequest search);
    }

    public class EnclosuresRepo : IEnclosuresRepo
    {
        private readonly ZooManagementDbContext _context;

        public EnclosuresRepo(ZooManagementDbContext context)
        {
            _context = context;
        }

        public int Count(EnclosureSearchRequest search)
        {
            throw new NotImplementedException();
        }

        public Enclosure Create(CreateEnclosureRequest enclosureRequest)
        {
            throw new NotImplementedException();
        }

        public Enclosure GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Enclosure> Search(EnclosureSearchRequest search)
        {
            throw new NotImplementedException();
        }
    }
}