using EStor.Application.Interfaces.Contexts;
using EStor.CommonUtility.DTO;

namespace EStor.Application.Services.Users.QueriesService.GetRoles;

public class GetRolesService : IGetRolesService
{
    private readonly IDataBaseContext _context;

    public GetRolesService(IDataBaseContext context)
    {
        _context = context;
    }

    public ServiceResultDto<List<RolesDto>> Execute()
    {
        var roles = _context.Roles.ToList().Select(role => new RolesDto
        {
            Id = role.Id,
            Name = role.Name,
        }).ToList();

        return new ServiceResultDto<List<RolesDto>>
        {
            IsSuccess = true,
            Message ="" ,
            Data = roles
        };
    }
}