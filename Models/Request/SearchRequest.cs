namespace ZooManagement.Models.Request
{
    public class SearchRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public virtual string Filters => "";
    }
    

    public class AnimalSearchRequest : SearchRequest
    {
        public int? AnimalTypeId { get; set; }
        public override string Filters => AnimalTypeId == null ? "" : $"&animaltypeid={AnimalTypeId}";
    }
}