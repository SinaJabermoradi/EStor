using EStor.Application.Interfaces.Contexts;
using EStor.CommonUtility.DTO;
using EStor.Domain.Entities.Products;

namespace EStor.Application.Services.Products.CommandsService.AddNewCategory;

public class AddNewCategoryService : IAddNewCategoryService
{
    // دیتابیس کانتکس ، واسطی هست بین یک سرویس ِخاص از نرم افزار ما با بانک اطلاعاتی . 
    // یعنی یک یا چند تا از جداول ِبانک اطلاعاتی ما رو وصل می کنه به یک سرویس ِخاص

    private readonly IDataBaseContext _context;

    public AddNewCategoryService(IDataBaseContext context)
    {
        _context = context;
    }

    public ServiceResultDto Execute(long? parentCategoryId, string categoryName)
    {
        // Validation ===> اعتبار سنجی می کنیم

        if (string.IsNullOrWhiteSpace(categoryName))
            return new ServiceResultDto
            {
                IsSuccess = false,
                Message = "لطفا نام دسته بندی را وارد نمایید"
            };

        Category category = new Category
        {
            Name = categoryName,
            ParentCategory = GetParentCategory(parentCategoryId)
        };
        _context.Categories.Add(category);
        _context.SaveChanges();
        return new ServiceResultDto
        {
            IsSuccess = true,
            Message = "دسته بندی با موفقیت اضافه شد"
        };
    }

    private Category GetParentCategory(long? parentCategoryId)
    {
        return _context.Categories.Find(parentCategoryId);
    }
}