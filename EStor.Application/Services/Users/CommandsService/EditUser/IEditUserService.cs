using EStor.CommonUtility.DTO;

namespace EStor.Application.Services.Users.CommandsService.EditUser;

public interface IEditUserService
{
    ServiceResultDto Execute(RequestEditUserDto request);
}