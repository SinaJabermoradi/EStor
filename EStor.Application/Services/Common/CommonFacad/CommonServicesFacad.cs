using EStor.Application.Interfaces.Contexts;
using EStor.Application.Services.Common.QueriesService.GetMenuItem;
using EStor.Application.Services.Products.FacadPattern;

namespace EStor.Application.Services.Common.CommonFacad;

public class CommonServicesFacad : ICommonServicesFacad
{
    private readonly IDataBaseContext _context;
    public CommonServicesFacad(IDataBaseContext context)
    {
        _context = context;
    }



    private IGetMenuItemService _getMenuItemService;
    public IGetMenuItemService GetMenuItemService
    {
        get
        {
            return _getMenuItemService = _getMenuItemService ?? new GetMenuItemService(_context);
        }
    }
}