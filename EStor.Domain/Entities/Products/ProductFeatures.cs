using EStor.Domain.Entities.Commons;

namespace EStor.Domain.Entities.Products;

public class ProductFeatures : BaseEntity  // ویژگی های محصولات
{
    public string FeaturesName { get; set; }  // نام ویژگی
    public string FeaturesValue { get; set; }  // مقدار ویژگی   




    #region Product رابطه ی یک به چند با 
    // رابطه ی یک به چند داریم با محصول . یعنی هر ویژگی برای یک محصول خاص هست

    public virtual Product Product { get; set; }
    public long ProductId { get; set; }

    #endregion
}