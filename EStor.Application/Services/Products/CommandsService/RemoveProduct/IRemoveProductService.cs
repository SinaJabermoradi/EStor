using EStor.CommonUtility.DTO;
using EStor.Domain.Entities.Products;

namespace EStor.Application.Services.Products.CommandsService.RemoveProduct;

public interface IRemoveProductService
{
    public ServiceResultDto Execute(long productId);
}