using EStor.Application.Interfaces.Contexts;
using EStor.CommonUtility.DTO;
using Microsoft.EntityFrameworkCore;

namespace EStor.Application.Services.Users.CommandsService.EditUser;

public class EditUserService : IEditUserService
{
    private readonly IDataBaseContext _context;

    public EditUserService(IDataBaseContext context)
    {
        _context = context;
    }

    public ServiceResultDto Execute(RequestEditUserDto request)
    {
        try
        {
            var user = _context.Users.Find(request.UserId);

            if (user == null)
                return new ServiceResultDto
                {
                    IsSuccess = false,
                    Message = "کاربر در دیتابیس یافت نشد"
                };

            if (string.IsNullOrWhiteSpace(request.FullName))
                return new ServiceResultDto
                {
                    IsSuccess = false,
                    Message = "لطفا نام و نام خانوادگی کاربر را وارد نمایید",
                };

            if (string.IsNullOrWhiteSpace(request.Email))
                return new ServiceResultDto
                {
                    IsSuccess = false,
                    Message = "لطفا پست الکترونیک کاربر را وارد کنید",
                };

            if (string.IsNullOrWhiteSpace(request.Password))
                return new ServiceResultDto
                {
                    IsSuccess = false,
                    Message = "لطفا رمز عبور را وارد کنید",
                };

            if (string.IsNullOrWhiteSpace(request.RePassword))
                return new ServiceResultDto
                {
                    IsSuccess = false,
                    Message = "لطفا تکرار رمز عبور را وارد کنید",
                };

            if (request.Password != request.RePassword)
                return new ServiceResultDto
                {
                    IsSuccess = false,
                    Message = "رمز عبور و تکرار آن برابر نیست",
                };

            user.FullName = request.FullName;
            user.Email = request.Email;
            user.Password = request.Password;

            _context.SaveChanges();

            return new ServiceResultDto
            {
                IsSuccess = true,
                Message = "ویرایش کاربر انجام شد"
            };
        }
        catch (Exception)
        {
            return new ServiceResultDto
            {
                IsSuccess = false,
                Message = "ویرایش کاربر انجام نشد"
            };
        }
    }
}