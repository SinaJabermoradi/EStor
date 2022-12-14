using EStor.CommonUtility.DTO;

namespace EStor.Application.Services.Products.QueriesService.GetProductForSite;

public interface IGetProductForSite
{
    ServiceResultDto<ResultProductForSiteDto> Execute(Ordering orderParameter
        , string searchKey
        , int pageNumber
        , int pageSize
        , long? categoryId);
}