using EStor.Application.Interfaces.Contexts;
using EStor.CommonUtility.DTO;
using Microsoft.EntityFrameworkCore;

namespace EStor.Application.Services.Common.QueriesService.GetMenuItem;

public class GetMenuItemService : IGetMenuItemService
{
    private readonly IDataBaseContext _context;
    public GetMenuItemService(IDataBaseContext context)
    {
        _context = context;
    }


    public ServiceResultDto<List<MenuItemDto>> Execute()
    {
        var category = _context.Categories
            .Include(cat => cat.SubCategories)
            .Where(p => p.ParentCategoryId == null)
            .ToList()
            .Select(cat => new MenuItemDto
            {
                Name = cat.Name,
                CategoryId = cat.Id,
                InnerMenu = cat.SubCategories.ToList().Select(child => new MenuItemDto
                {
                    Name = child.Name,
                    CategoryId = child.Id,
                }).ToList(),
            }).ToList();

        return new ServiceResultDto<List<MenuItemDto>>
        {
            Data = category,
            IsSuccess = true
        };
    }
}