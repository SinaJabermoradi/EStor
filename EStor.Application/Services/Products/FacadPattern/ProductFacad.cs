using EStor.Application.Interfaces.Contexts;
using EStor.Application.Services.Products.CommandsService.AddNewCategory;
using EStor.Application.Services.Products.CommandsService.AddNewProduct;
using EStor.Application.Services.Products.CommandsService.RemoveProduct;
using EStor.Application.Services.Products.QueriesService.GetAllCategories;
using EStor.Application.Services.Products.QueriesService.GetCategories;
using EStor.Application.Services.Products.QueriesService.GetProductForAdmin;
using Microsoft.AspNetCore.Hosting;

namespace EStor.Application.Services.Products.FacadPattern;

public class ProductFacad : IProductFacad
{
    // چون سرویس ما قطعا قراره با دیتابیس سروکار داشته باشه ، پس نیازه که از  کانتکس که واسط هست بین ِسرویس مون و دیتابیس استفاده کنیم.
    private readonly IDataBaseContext _context;
    private readonly IHostingEnvironment _environment;


    public ProductFacad(IDataBaseContext context
                , IHostingEnvironment environment) 
    {
        _context = context;
        _environment = environment;
    }


    private AddNewCategoryService _addNewCategory;
    public AddNewCategoryService AddNewCategoryService
    {
        get
        {
            return _addNewCategory = _addNewCategory ?? new AddNewCategoryService(_context);
        }
    }


    private IGetCategoriesService _getCategories;
    public IGetCategoriesService GetCategoriesService
    {
        get
        {
            return _getCategories = _getCategories ?? new GetCategoriesService(_context);
        }
    }


    private AddNewProductService _addNewProduct;
    public AddNewProductService AddNewProductService {
        get
        {
            return _addNewProduct = _addNewProduct ?? new AddNewProductService(_context,_environment);
        }
    }


    private IGetAllCategoriesService _getAllCategories;
    public IGetAllCategoriesService GetAllCategoriesService {
        get
        {
            return _getAllCategories = _getAllCategories ?? new GetAllCategoriesService(_context);
        }
    }



    private IGetProductForAdminService _getProductForAdmin;
    public IGetProductForAdminService GetProductForAdminService
    {
        get
        {
            return _getProductForAdmin = _getProductForAdmin ?? new GetProductForAdminService(_context);
        }
    }



    private IRemoveProductService _removeProduct;
    public IRemoveProductService RemoveProductService
    {
        get
        {
            return _removeProduct = _removeProduct ?? new RemoveProductService(_context);
        }
    }
}