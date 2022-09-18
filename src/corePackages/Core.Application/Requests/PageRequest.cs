namespace Core.Application.Requests;

public class PageRequest
{
    /// <summary>
    /// kaçıncı sayfa
    /// </summary>
    public int Page { get; set; }
    /// <summary>
    /// bir sayfada kaç data var
    /// </summary>
    public int PageSize { get; set; }
}