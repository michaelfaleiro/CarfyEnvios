namespace CarfyEnvios.Core.Models;
public class PagedResult<TData>
{
    public int TotalCount { get; set; }
    public IList<TData> Data { get; set; } = [];
}
