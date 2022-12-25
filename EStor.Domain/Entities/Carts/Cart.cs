using EStor.Domain.Entities.Commons;
using EStor.Domain.Entities.Users;

namespace EStor.Domain.Entities.Carts;

public class Cart : BaseEntity
{
    public Guid BrowserId { get; set; }  // آی دی این سبد خرید در مرورگر کاربر ذخیره می شود به کمک کوکی


    #region رابطه ی یک به چند با کاربر

    public virtual  User  User{ get; set; }
    public long? UserId { get; set; }  // این نال پذیر است تا اگر کاربری لاگین نکرده بود و سبد رو پر کرد این به ارور نخوره
    
    #endregion
}