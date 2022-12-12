using EStor.Application.Interfaces.Contexts;
using EStor.CommonUtility.DTO;
using Microsoft.EntityFrameworkCore;

namespace EStor.Application.Services.Products.QueriesService.GetAllCategories;

public class GetAllCategoriesService : IGetAllCategoriesService
{
    private readonly IDataBaseContext _context;

    public GetAllCategoriesService(IDataBaseContext context)
    {
        _context = context;
    }


    public ServiceResultDto<List<ResultGetAllCategoriesServiceDto>> Execute()
    {
        var allCategories = _context.Categories.Include(category => category.ParentCategory)
            .ToList()
            .Where(category => category.ParentCategoryId != null)
            .Select(category => new ResultGetAllCategoriesServiceDto
            {
                CategoryId = category.Id,
                CategoryName = $"{category.ParentCategory.Name}  -  { category.Name }",
            })
            .ToList();

        return new ServiceResultDto<List<ResultGetAllCategoriesServiceDto>>
        {
            IsSuccess = true,
            Message = "",
            Data = allCategories
        };
    }
}