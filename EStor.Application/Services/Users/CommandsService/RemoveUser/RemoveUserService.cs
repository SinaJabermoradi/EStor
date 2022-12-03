using EStor.Application.Interfaces.Contexts;
using EStor.CommonUtility.DTO;

namespace EStor.Application.Services.Users.CommandsService.RemoveUser;

public class RemoveUserService : IRemoveUserService
{
    private readonly IDataBaseContext _context;

    public RemoveUserService(IDataBaseContext context)
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
        user.RemoveRecordTime = DateTime.Now;
        user.IsRemoved = true;
        _context.SaveChanges();
        return new ServiceResultDto
        {
            IsSuccess = true,
            Message = "کاربر با موفقیت حذف شد"
        };
    }
}