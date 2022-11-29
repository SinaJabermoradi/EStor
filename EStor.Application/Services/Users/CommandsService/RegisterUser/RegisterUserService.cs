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
        try
        {
            if (string.IsNullOrWhiteSpace(request.FullName))
                return new ServiceResultDto<ResultRegisterUserDto>
                {
                    IsSuccess = false,
                    Message = "لطفا نام و نام خانوادگی کاربر را وارد نمایید",
                    Data = new ResultRegisterUserDto
                    {
                        UserId = 0
                    }
                };

            if (string.IsNullOrWhiteSpace(request.Email))
                return new ServiceResultDto<ResultRegisterUserDto>
                {
                    IsSuccess = false,
                    Message = "لطفا پست الکترونیک کاربر را وارد کنید",
                    Data = new ResultRegisterUserDto
                    {
                        UserId = 0
                    }
                };

            if (string.IsNullOrWhiteSpace(request.Password))
                return new ServiceResultDto<ResultRegisterUserDto>
                {
                    IsSuccess = false,
                    Message = "لطفا رمز عبور را وارد کنید",
                    Data = new ResultRegisterUserDto
                    {
                        UserId = 0
                    }
                };

            if (string.IsNullOrWhiteSpace(request.RePassword))
                return new ServiceResultDto<ResultRegisterUserDto>
                {
                    IsSuccess = false,
                    Message = "لطفا تکرار رمز عبور را وارد کنید",
                    Data = new ResultRegisterUserDto
                    {
                        UserId = 0
                    }
                };

            if (request.Password != request.Password)
                return new ServiceResultDto<ResultRegisterUserDto>
                {
                    IsSuccess = false,
                    Message = "رمز عبور و تکرار آن برابر نیست",
                    Data = new ResultRegisterUserDto
                    {
                        UserId = 0
                    }
                };

            User user = new User
            {
                FullName = request.FullName,
                Email = request.Email,
            };

            foreach (var role in request.Roles)
            {
                var roles = _context.Roles.Find(role.Id);
                _userInRoles.Add(new UserInRole
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
                Data = new ResultRegisterUserDto
                {
                    UserId = user.Id
                }
            };
        }
        catch (Exception)
        {
            return new ServiceResultDto<ResultRegisterUserDto>
            {
                IsSuccess = false,
                Message = "ثبت نام کاربر انجام نشد !! ",
                Data =
                {
                    UserId = 0
                }
            };
        }
    }

    #endregion


    #endregion

}