using EStor.Application.Interfaces.Contexts;
using EStor.CommonUtility;

namespace EStor.Application.Services.Users.QueriesService.GetUsers;

public class GetUsersService : IGetUsersService
{
    private  readonly  IDataBaseContext _context;

    public GetUsersService(IDataBaseContext context)
    {
        _context = context;
    }

    public List<UsersDto> Execute(GetUserRequestDto requestDto)
    {
        int rowsCount = 0;
        var users = _context.Users.AsQueryable();

        if (!string.IsNullOrWhiteSpace(requestDto.SearchKey))
        {
            users = users.Where(user =>
                user.FullName.Contains(requestDto.SearchKey) &&
                user.Email.Contains(requestDto.SearchKey));
        }

        return users.ToPaged(requestDto.Page, 20, out rowsCount)
            .Select(user => new UsersDto
            {
                FullName = user.FullName,
                Email =  user.Email,
                Id = user.Id
            }).ToList();
    }
}