using EStor.CommonUtility.DTO;

namespace EStor.Application.Services.Common.QueriesService.GetCategoryForSearch;

public interface IGetCategoryForSearchService
{
    ServiceResultDto<List<CategoryForSearchDto>> Execute();
}