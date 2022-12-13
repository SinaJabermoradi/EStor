using EStor.CommonUtility.DTO;

namespace EStor.Application.Services.Products.QueriesService.GetProductForAdmin;

public interface IGetProductForAdminService
{
    public ServiceResultDto<GetProductForAdminDto> Execute(int pageNumber
        , int countOfProductOnThePage);
}