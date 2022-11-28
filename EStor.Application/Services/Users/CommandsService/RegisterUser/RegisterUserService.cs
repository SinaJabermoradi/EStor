using EStor.Application.Interfaces.Contexts;
using EStor.CommonUtility.DTO;
using EStor.Domain.Entities.Users;

namespace EStor.Application.Services.Users.CommandsService.RegisterUser;

public class RegisterUserService : IRegisterUserService
{
    #region Attributes

    #region Filds

    private readonly IDataBaseContext _context;
    private List<UserInRole> _userInRoles;

    #endregion

    #endregion


    #region Behavior

    #region Constructor
        
    public RegisterUserService(IDataBaseContext context)
    {
        _context = context;
    }

    #endregion


    #region Methods

    public ServiceResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request)
    {
        User user = new User
        {
            FullName = request.FullName,
            Email = request.Email,
        };

        foreach (var role in request.Roles)
        {
            var roles = _context.Roles.Find(role.Id);
            _userInRoles.Add( new UserInRole
                {
                    User = user,
                    UserId = user.Id,
                    UserRole = roles,
                    UserRoleId = roles.Id
                });
        }

        user.UserInRoles = _userInRoles;

        _context.Users.Add(user);

        _context.SaveChanges();

        return new ServiceResultDto<ResultRegisterUserDto>
        {
            IsSuccess = true,
            Message = "ثبت نام کاربر با موفقیت انجام شد",
            OtherServiceResultData = new ResultRegisterUserDto
            {
                UserId = user.Id
            }
        };
    }

    #endregion


    #endregion

}