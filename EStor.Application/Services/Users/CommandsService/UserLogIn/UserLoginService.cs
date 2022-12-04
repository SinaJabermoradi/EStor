using EStor.Application.Interfaces.Contexts;
using EStor.CommonUtility;
using EStor.CommonUtility.DTO;
using Microsoft.EntityFrameworkCore;

namespace EStor.Application.Services.Users.CommandsService.UserLogIn;

public class UserLoginService : IUserLoginService
{
    private readonly IDataBaseContext _context;

    public UserLoginService(IDataBaseContext context)
    {
        _context = context;
    }

    public ServiceResultDto<ResultUserLoginDto> Execute(string email
                                        , string password)
    {
        string roles = "";

        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            return new ServiceResultDto<ResultUserLoginDto>
            {
                IsSuccess = false,
                Message = " ایمیل و رمز عبور را وارد نمایید",
                Data = new ResultUserLoginDto
                {

                }
            };

        var user = _context.Users.Include(User=>User.UsersRoles)
            .ThenInclude(User=>User.Role)
            .Where(User=>User.Email.Equals(email)  
                         && User.IsActive== true)
            .FirstOrDefault();

        if (user == null)
            return new ServiceResultDto<ResultUserLoginDto>
            {
                IsSuccess = false,
                Message = "کاربری با این ایمیل در سایت کالا مارکت ثبت نام نکرده است",
                Data = new ResultUserLoginDto
                {

                }
            };

        var passwordHasher = new PasswordHasher();
        bool resultVerifyPasswordHashing = passwordHasher.VerifyPassword(user.Password,password);
        if (resultVerifyPasswordHashing == false)
            return new ServiceResultDto<ResultUserLoginDto>
            {
                IsSuccess = false,
                Message = "رمز وارد شده اشتباه است !!",
                Data =
                {

                }
            };

        foreach (var usersRoles in user.UsersRoles)
            roles += $"{usersRoles.Role.Name}";

        return new ServiceResultDto<ResultUserLoginDto>
        {
            IsSuccess = true,
            Message = "ورود به کالا مارکت با موفقیت انجام شد",
            Data = new ResultUserLoginDto
            {
                UserId = user.Id,
                Roles = roles,
                Name = user.FullName
            }
        };

    }
}