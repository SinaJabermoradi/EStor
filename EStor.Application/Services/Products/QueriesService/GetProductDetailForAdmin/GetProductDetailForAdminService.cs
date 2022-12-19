using EStor.Application.Interfaces.Contexts;
using EStor.CommonUtility.DTO;
using EStor.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace EStor.Application.Services.Products.QueriesService.GetProductDetailForAdmin;

public class GetProductDetailForAdminService : IGetProductDetailForAdminService
{
    private readonly IDataBaseContext _context;
    public GetProductDetailForAdminService(IDataBaseContext context)
    {
        _context = context;
    }

    private string GetCategory(Category category)
    {
        string result = (category.ParentCategory != null) ? $"{category.ParentCategory.Name}" : "";
        return result += " - " + category.Name;
    }

    public ServiceResultDto<ProductDetailForAdminDto> Execute(long productId)
    {
        var isHaveProduct = _context.Products.Find(productId);
        if (isHaveProduct == null)
            return new ServiceResultDto<ProductDetailForAdminDto>
            {
                IsSuccess = false,
                Message = "محصول مورد نظر یافت نشد !!",
                Data = null
            };

        var product = _context.Products
            .Include(product => product.Category)
            .ThenInclude(product => product.ParentCategory)
            .Include(product => product.ProductFeatures)
            .Include(product => product.ProductImage)
            .Where(product => product.Id == productId)
            .FirstOrDefault();

        return new ServiceResultDto<ProductDetailForAdminDto>
        {
            Data = new ProductDetailForAdminDto
            {
                Id = product.Id,
                CategoryId = product.Category.Id,
                Name = product.Name,
                CategoryName = GetCategory(product.Category),
                Brand = product.Brand,
                Description = product.Description,
                Price = product.Price,
                CountOfProductInInventory = product.CountOfProductInInventory,
                IsThisProductBeDisplayedOnTheSite = product.IsThisProductBeDisplayedOnTheSite,
                Featuers = product.ProductFeatures.ToList().Select(product => new ProductDetailFeatureDto
                {
                    Id = product.Id,
                    FeatureName = product.FeaturesName,
                    FeatureValue = product.FeaturesValue
                }).ToList(),
                Images = product.ProductImage.ToList().Select(product => new ProductDetailImageDto
                {
                    Id = product.Id,
                    ImageSrc = product.ImageSrc
                }).ToList(),
            },
            IsSuccess = true,
            Message = ""
        };
    }
}