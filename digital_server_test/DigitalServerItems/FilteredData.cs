namespace DigitalServerItems
{
    public class FilteredData
    {
        public string? NameLike { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public ProductType? ProductType { get; set; }
        public int[]? Cities { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
