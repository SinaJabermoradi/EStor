using EStor.Application.Interfaces.Contexts;
using EStor.CommonUtility.DTO;

namespace EStor.Application.Services.Users.CommandsService.UserStatusChange;

public class UserStatusChangeService : IUserStatusChangeService
{
    private readonly IDataBaseContext _context;

    public UserStatusChangeService(IDataBaseContext context)
    {
        _context = context;
    }

    public ServiceResultDto Execute(long userId)
    {
        var user = _context.Users.Find(userId);
        if (user == null)
        {
            return new ServiceResultDto
            {
                IsSuccess = false,
                Message = "کاربر یافت نشد"
            };
        }

        user.IsActive = !user.IsActive;
        _context.SaveChanges();

        string userState = ( user.IsActive == true ) ? "فعال" : "غیر فعال";
        return new ServiceResultDto
        {
            IsSuccess = true,
            Message = $"کاربر با موفقیت {userState} شد !"
        };
    }
}