using EStor.Application.Services.Common.QueriesService.GetMenuItem;

namespace EStor.Application.Services.Products.FacadPattern;

public interface ICommonServicesFacad
{
    /// <summary>
    /// لیست هدر ها یا نویگیشن رو به ما میده
    /// </summary>
    public IGetMenuItemService GetMenuItemService { get; }
}