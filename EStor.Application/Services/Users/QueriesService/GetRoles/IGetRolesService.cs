using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EStor.CommonUtility.DTO;

namespace EStor.Application.Services.Users.QueriesService.GetRoles
{
    public interface IGetRolesService
    {
        ServiceResultDto<List<RolesDto>> Execute();
    }
}
