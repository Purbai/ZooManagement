using ZooManagement.Models.Database;

namespace ZooManagement.Data
{
    public static class SampleEnclosures
    {
        public const int NumberOfEnclosures = 5;

        private static readonly IList<IList<string>> Data = new List<IList<string>>
        {
            new List<string> { "1","Lion's Enclosure" ,"10"},
            new List<string> { "2","Aviary","50" },
            new List<string> { "3","Reptile House","40" },
            new List<string> { "4","Giraffe Enclosure","6" },
            new List<string> { "5","Hippo Enclosure","10" },
        };

        public static IEnumerable<Enclosure> GetEnclosures()
        {
            return Enumerable.Range(0, NumberOfEnclosures).Select(CreateEnclosures);
        }

        private static Enclosure CreateEnclosures(int index)
        {

            return new Enclosure
            {
                EnclosureId = int.Parse(Data[index][0]),
                EnclosureName = Data[index][1],
                MaxNumberOfAnimals = int.Parse(Data[index][2])
            };
        }
    }
}
