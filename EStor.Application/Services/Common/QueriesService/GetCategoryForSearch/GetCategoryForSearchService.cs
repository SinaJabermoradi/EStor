using EStor.Application.Interfaces.Contexts;
using EStor.CommonUtility.DTO;

namespace EStor.Application.Services.Common.QueriesService.GetCategoryForSearch;

public class GetCategoryForSearchService:IGetCategoryForSearchService
{
    private readonly IDataBaseContext _context;
    public GetCategoryForSearchService(IDataBaseContext context)
    {
        _context = context;
    }


    public ServiceResultDto<List<CategoryForSearchDto>> Execute()
    {
        // به این می گن یک کویری تمیز که کاملا خودم نوشتم اش
        var AllCategory = _context.Categories
            .Where(category => category.ParentCategoryId == null)
            .AsQueryable();  // باعث میشه که کویری اجرا نشه و در حالت کویری بمونه تا زمانی که ما بهش بگیم . برای همین می تونیم محدودیت های بیشتری رو قبل از اجرا شدن، روی کویری مون اعمال کنیم و حسابی فیلتر کنیم و بعد اجرا کنیم تا کویری مریض پیش نیاد و سرعت کویری کند نشه و با سرعت اجرا بشه 

        return new ServiceResultDto<List<CategoryForSearchDto>>
        {
            IsSuccess = true,
            Message = "",
            Data = AllCategory.Select(category => new CategoryForSearchDto
            {
                CategoryId = category.Id,
                CategoryName = category.Name
            }).ToList(),
        };
    }
}