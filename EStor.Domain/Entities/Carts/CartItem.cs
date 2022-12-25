using EStor.Domain.Entities.Commons;
using EStor.Domain.Entities.Products;

namespace EStor.Domain.Entities.Carts;

public class CartItem : BaseEntity
{
    public long Count { get; set; }
    public decimal Price { get; set; }



    #region رابطه ی یک به چند داره با محصولات

    public virtual  Product Product { get; set; }
    public long ProductId { get; set; }

    #endregion
}