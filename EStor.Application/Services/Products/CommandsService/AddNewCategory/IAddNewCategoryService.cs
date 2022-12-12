using EStor.CommonUtility.DTO;

namespace EStor.Application.Services.Products.CommandsService.AddNewCategory;

public interface IAddNewCategoryService
{
    ServiceResultDto Execute(long? parentCategoryId // اگر این پارامتر نال باشه ، یعنی خودش یک محصول اصلی هست . و زیر شاخه ی محصول دیگری نیست
                    , string categoryName);
}