using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStor.Application.Services.Users.QueriesService.GetUsers
{
    public interface IGetUsersService
    {
        public List<UsersDto> Execute(GetUserRequestDto requestDto);
    }
}
