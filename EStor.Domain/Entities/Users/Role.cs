using EStor.Domain.Entities.Commons;

namespace EStor.Domain.Entities.Users;

public class Role : BaseEntity
{
    public string Name{ get; set; }
   /*
    /// برای ایجاد رابطه ی چند به چند از این پراپرتی و کلاس (( یوزر این رول )) استفاده کردیم
    */
    public ICollection<UserRole> UsersRoles { get; set; }
}