using EStor.Application.Interfaces.Contexts;
using EStor.CommonUtility.DTO;
using Microsoft.EntityFrameworkCore;

namespace EStor.Application.Services.Products.QueriesService.GetCategories;

public class GetCategoriesService : IGetCategoriesService
{
    private readonly IDataBaseContext _context;

    public GetCategoriesService(IDataBaseContext context)
    {
        _context = context;
    }
    public ServiceResultDto<List<CategoriesDto>> Execute(long? parentCategoryId)
    {
        var categories = _context.Categories
            .Include(category => category.ParentCategory)
            .Include(category => category.SubCategories)
            .Where(category => category.ParentCategoryId == parentCategoryId)
            .ToList()
            .Select(category => new CategoriesDto
            {
                CategoryId = category.Id,
                CategoryName = category.Name,
                CategoryParent = category.ParentCategory != null ? new ParentCategoryDto
                {
                    ParentId = category.ParentCategory.Id,
                    ParentName = category.ParentCategory.Name
                } : null,
                CategoryHasChild = category.SubCategories.Count() > 0 ? true : false
            }).ToList();

        return new ServiceResultDto<List<CategoriesDto>>
        {
            IsSuccess = true,
            Message = "لیست باموفقیت برگشت داده شد",
            Data = categories
        };
    }
}