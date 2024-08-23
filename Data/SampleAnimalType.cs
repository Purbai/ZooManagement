using ZooManagement.Models.Database;

namespace ZooManagement.Data
{
    public static class SampleAnimalType
    {
        public const int NumberOfAnimalType = 6;

        private static readonly IList<IList<string>> Data = new List<IList<string>>
        {
            new List<string> { "1","Lion" ,"Mammal","10"},
            new List<string> { "2","Tigers","Mammal","15" },
            new List<string> { "3","Swallows","Birds","25" },
            new List<string> { "4","Parrot","Birds","50" },
            new List<string> { "5","Cod","Fish","100" },
            new List<string> { "6","Snake","reptile","33" }
        };

        public static IEnumerable<AnimalType> GetAnimalTypes()
        {
            return Enumerable.Range(0, NumberOfAnimalType).Select(CreateRandomAnimalType);
        }

        private static AnimalType CreateRandomAnimalType(int index)
        {

            return new AnimalType
            {
                Id = int.Parse(Data[index][0]),
                Species = Data[index][1],
                Classification = Data[index][2],
                Quantity = int.Parse(Data[index][3])
            };
        }
    }
}
