using EStor.CommonUtility.DTO;

namespace EStor.Application.Services.Products.QueriesService.GetAllCategories;

public interface IGetAllCategoriesService
{
    ServiceResultDto<List<ResultGetAllCategoriesServiceDto>> Execute();
}