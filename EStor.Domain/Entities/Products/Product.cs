using EStor.Domain.Entities.Commons;

namespace EStor.Domain.Entities.Products;

public class Product : BaseEntity  // محصول
{
    public string Name { get; set; } // نام محصول
    public string Brand { get; set; } // برند محصول
    public string Description { get; set; } // توضیحات محصول
    public decimal Price { get; set; } // قیمت محصول 
    public long CountOfProductInInventory { get; set; } // تعداد موجودی محصول در انبار
    public bool IsThisProductBeDisplayedOnTheSite { get; set; } // این محصول در سایت نمایش داده بشود یا خیر



    #region Category رابطه ی یک به چند با دسته بندی محصولات یا
    // چندین محصول ، برای یک دسته بندی یا کتگوری خاص است

    public virtual Category Category { get; set; }
    public long CategoryId { get; set; }

    #endregion

    #region ProductImage رابطه ی یک به چند با  
    
    // چون هر محصول می تواند دارای چند عکس باشد ، یک رابطه ی یک به چند می نویسیم
    public virtual List<ProductImage> ProductImage { get; set; }

    #endregion

    #region ProductFeatures رابطه ی یک به چند با
    // رابطه ی یک به چند داریم با ویژگی ها. یعنی هر محصول دارای یک یا چند ویژگی هست

    public virtual ICollection<ProductFeatures> ProductFeatures { get; set; }

    #endregion
}