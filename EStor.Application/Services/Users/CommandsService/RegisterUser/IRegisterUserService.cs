using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EStor.CommonUtility.DTO;

namespace EStor.Application.Services.Users.CommandsService.RegisterUser
{
    public interface IRegisterUserService
    {
        ServiceResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request);
    }
}
