using EStor.Application.Services.Products.CommandsService.AddNewCategory;
using EStor.Application.Services.Products.CommandsService.AddNewProduct;
using EStor.Application.Services.Products.CommandsService.EditProduct;
using EStor.Application.Services.Products.CommandsService.RemoveProduct;
using EStor.Application.Services.Products.QueriesService.GetAllCategories;
using EStor.Application.Services.Products.QueriesService.GetCategories;
using EStor.Application.Services.Products.QueriesService.GetProductDetailForAdmin;
using EStor.Application.Services.Products.QueriesService.GetProductDetailForSite;
using EStor.Application.Services.Products.QueriesService.GetProductForAdmin;
using EStor.Application.Services.Products.QueriesService.GetProductForSite;

namespace EStor.Application.Services.Products.FacadPattern;

public interface IProductFacad
{
    public AddNewCategoryService AddNewCategoryService { get; }
    public IGetCategoriesService GetCategoriesService { get;}
    public AddNewProductService AddNewProductService { get; }
    public IGetAllCategoriesService GetAllCategoriesService { get; }
    /// <summary>
    /// دریافت لیست محصولات برای ادمین
    /// </summary>
    public IGetProductForAdminService GetProductForAdminService { get; }
    /// <summary>
    /// حذف یک محصول خاص از سایت توسط ادمین
    /// </summary>
    public IRemoveProductService RemoveProductService { get; }
    /// <summary>
    /// جزئیات محصول رو برای ادمین بر می گرداند
    /// </summary>
    public IGetProductDetailForAdminService GetProductDetailForAdminService { get; }
    /// <summary>
    /// ویرایش محصول توسط ادمین
    /// </summary>
    public IEditProductService EditProductService { get; }
    /// <summary>
    /// دریافت لیست محصولات برای کاربران سایت
    /// </summary>
    public IGetProductForSite GetProductForSite { get; }
    /// <summary>
    /// جزئیات محصول برای ادمین بر می گردونه
    /// </summary>
    public IGetProductDetailForSiteService GetProductDetailForSite { get; }
}