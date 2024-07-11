namespace NGPD.Manager.Entities.Pagination;

public class PagedResult<TEntity>
{
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public IList<TEntity> List { get; set; }
    public int PageCount { get; set; }

    public PagedResult()
    {
        this.List = new List<TEntity>();
    }

    public PagedResult(IList<TEntity> list, int quantity, int currentPage, int pageSize)
    {
        this.CurrentPage = currentPage;
        this.PageSize = pageSize;
        this.TotalCount = quantity;
        this.List = list;
    }
}