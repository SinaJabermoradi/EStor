using EStor.Domain.Entities.Commons;

namespace EStor.Domain.Entities.Products;

public class ProductImage : BaseEntity// تصویر محصولات
{
    public string ImageSrc { get; set; } // آدرس جایی که عکس محصولات در آنجاست



    #region Product رابطه ی یک به چند با

    public virtual Product Product { get; set; }
    public long ProductId { get; set; }

    #endregion

}