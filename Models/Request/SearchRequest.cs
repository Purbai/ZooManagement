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
        public string? AcquiredDate {get;set;}
        public string? Name {get;set;}
        public int? Age {get;set;}
        public string? Classification { get; set; }
        public override string Filters => AnimalTypeId == null ? "" : $"&animaltypeid={AnimalTypeId}";
    }

    public class EnclosureSearchRequest : SearchRequest
    {
        public int? EnclosureId { get; set; }
        public string? EnclosureName { get; set; }
    }
}