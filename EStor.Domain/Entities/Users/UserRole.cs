using EStor.Domain.Entities.Commons;

namespace EStor.Domain.Entities.Users;

/*
/// از اونجایی که کلاس های (( یوزر رول )) و (( یوزر )) با هم رابطه ی چند به چند دارن ، برای مدیریت این رابطه چند به چند ، از این کلاس واسط استفاده می کنیم
/// برای این کار کافیه ===> کلید های هر دو کلاس را در این کلاس میانی قرار دهیم
/// سپس هر دو کلاس یک رابطه ی یک به چند با این کلاس میانی برقرار کنن
*/
public class UserRole : BaseEntity
{
    #region User کلید کلاس 

    public virtual User User { get; set; }
    public long UserId { get; set; }

    #endregion

    #region Role  کلید کلاس

    public virtual Role Role { get; set; }
    public long UserRoleId { get; set; }

    #endregion
}