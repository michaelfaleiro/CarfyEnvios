namespace CarfyEnvios.Communication.Response;

public class PagedResponse<TData>
{
    public int CurrentPage { get; set; } 
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
    public int PageSize { get; set; } = Configuration.DefaultPageSize;
    public int TotalCount { get; set; }
    public IList<TData> Data { get; set; } = default!;
}