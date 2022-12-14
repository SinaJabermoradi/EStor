using EStor.CommonUtility.DTO;

namespace EStor.Application.Services.Products.QueriesService.GetProductDetailForAdmin;

public interface IGetProductDetailForAdminService
{
    ServiceResultDto<ProductDetailForAdminDto> Execute(long productId);
}