namespace EStor.Domain.Entities.Users;

public class UserRole
{
    public long Id { get; set; }

    public Roles Role { get; set; }

    /// <summary>
    /// برای ایجاد رابطه ی چند به چند از این پراپرتی و کلاس (( یوزر این رول )) استفاده کردیم
    /// </summary>
    public ICollection<UserInRole> UserInRoles { get; set; }

}