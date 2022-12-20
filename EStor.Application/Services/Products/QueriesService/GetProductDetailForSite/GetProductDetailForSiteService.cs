using EStor.Application.Interfaces.Contexts;
using EStor.CommonUtility.DTO;
using Microsoft.EntityFrameworkCore;

namespace EStor.Application.Services.Products.QueriesService.GetProductDetailForSite;

public class GetProductDetailForSiteService : IGetProductDetailForSiteService
{
    private readonly IDataBaseContext _context;
    public GetProductDetailForSiteService(IDataBaseContext context)
    {
        _context = context;
    }


    public ServiceResultDto<ProductDetailForSiteDto> Execute(long productId)
    {
        var product = _context.Products
            .Include(p => p.Category)
            .ThenInclude(p => p.ParentCategory)
            .Include(p => p.ProductFeatures)
            .Include(p => p.ProductImage)
            .Where(p => p.Id == productId)
            .FirstOrDefault();

        if (product == null)
            throw new Exception("محصول پیدا نشد .... ");

        product.ViewCount++;
        _context.SaveChanges();

        Random rnd = new Random();

        return new ServiceResultDto<ProductDetailForSiteDto>
        {
            Data = new ProductDetailForSiteDto
            {
                Star = rnd.Next(1,5),
                Id = product.Id,
                Titel = product.Name,
                Price = product.Price,
                Description = product.Description,
                Brand = product.Brand,
                CategoryName = $"{product.Category.ParentCategory.Name}  -  {product.Category.Name}",
                CategoryId = product.Category.Id,
                CountOfProductInInventory = product.CountOfProductInInventory,
                Images = product.ProductImage.Select(p => p.ImageSrc).ToList(),
                Featuers = product.ProductFeatures.Select(p => new ProductDetailFeatureForSiteDto
                {
                    FeatureName = p.FeaturesName,
                    FeatureValue = p.FeaturesValue
                }).ToList()
            },
            IsSuccess = true,
        };
    }
}