using EStor.CommonUtility.DTO;

namespace EStor.Application.Services.Products.QueriesService.GetProductDetailForSite;

public interface IGetProductDetailForSiteService
{
    ServiceResultDto<ProductDetailForSiteDto> Execute(long productId);
}