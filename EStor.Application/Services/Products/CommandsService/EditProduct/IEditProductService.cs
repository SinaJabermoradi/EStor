using System.Security.AccessControl;
using EStor.CommonUtility.DTO;

namespace EStor.Application.Services.Products.CommandsService.EditProduct;

public interface IEditProductService
{
    ServiceResultDto Execute(RequestProductForEditDto request);
}