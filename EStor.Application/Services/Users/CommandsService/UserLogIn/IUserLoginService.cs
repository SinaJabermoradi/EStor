using EStor.CommonUtility.DTO;

namespace EStor.Application.Services.Users.CommandsService.UserLogIn;

public interface IUserLoginService
{
    ServiceResultDto<ResultUserLoginDto> Execute(string email
                                , string password);
}