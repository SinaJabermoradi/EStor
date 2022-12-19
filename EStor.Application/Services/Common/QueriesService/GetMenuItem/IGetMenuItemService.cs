using EStor.CommonUtility.DTO;

namespace EStor.Application.Services.Common.QueriesService.GetMenuItem;

public interface IGetMenuItemService
{
    ServiceResultDto<List<MenuItemDto>> Execute();
}