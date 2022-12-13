using EStor.Application.Services.Products.CommandsService.AddNewCategory;
using EStor.Application.Services.Products.CommandsService.AddNewProduct;
using EStor.Application.Services.Products.QueriesService.GetAllCategories;
using EStor.Application.Services.Products.QueriesService.GetCategories;
using EStor.Application.Services.Products.QueriesService.GetProductForAdmin;

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

}