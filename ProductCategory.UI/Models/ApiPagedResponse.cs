namespace ProductCategory.UI.Models
{
    public class ApiPagedResponse<T>
    {
        public List<T> Data { get; set; } = new();
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
    }
    public class ApiResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
    }

}
