using EStor.CommonUtility.DTO;

namespace EStor.Application.Services.Products.QueriesService.GetCategories;

public interface IGetCategoriesService
{
    ServiceResultDto<List<CategoriesDto>> Execute(long? parentCategoryId);
}