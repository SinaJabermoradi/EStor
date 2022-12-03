using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EStor.CommonUtility.DTO;

namespace EStor.Application.Services.Users.CommandsService.UserStatusChange
{
    public interface IUserStatusChangeService
    {
        ServiceResultDto Execute(long userId);
    }
}
