using EStor.CommonUtility.DTO;

namespace EStor.Application.Services.Products.QueriesService.GetProductForSite;

public interface IGetProductForSite
{
    ServiceResultDto<ResultProductForSiteDto> Execute(string searchKey, int pageNumber, long? categoryId);
}