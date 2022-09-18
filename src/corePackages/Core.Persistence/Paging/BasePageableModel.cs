namespace Core.Persistence.Paging;

public class BasePageableModel
{
    /// <summary>
    /// kaçıncı sayfa
    /// </summary>
    public int Index { get; set; }
    /// <summary>
    /// 1 sayfada kaç tane data var
    /// </summary>
    public int Size { get; set; }
    /// <summary>
    /// toplam kaçç data var
    /// </summary>
    public int Count { get; set; }
    /// <summary>
    /// toplam kaç sayfa var
    /// </summary>
    public int Pages { get; set; }
    /// <summary>
    /// önceki sayfa var mı?
    /// </summary>
    public bool HasPrevious { get; set; }
    /// <summary>
    /// sonraki sayfa var mı?
    /// </summary>
    public bool HasNext { get; set; }
}