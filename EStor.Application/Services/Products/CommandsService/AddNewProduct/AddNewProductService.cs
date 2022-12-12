using EStor.Application.Interfaces.Contexts;
using EStor.CommonUtility.DTO;
using EStor.Domain.Entities.Products;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace EStor.Application.Services.Products.CommandsService.AddNewProduct;

public class AddNewProductService : IAddNewProductService
{
    private readonly IDataBaseContext _context;
    private readonly IHostingEnvironment _environment;

    public AddNewProductService(IDataBaseContext context
        , IHostingEnvironment environment)
    {
        _context = context;
        _environment = environment;
    }

    private UploadDto? UploadFile(IFormFile file
        , string productImagesFolderName)
    {
        if (file != null)
        {
            string folder = $@"images\{productImagesFolderName}\";
            var upLoadsRootFolder = Path.Combine(_environment.WebRootPath, folder);
            if (!Directory.Exists(upLoadsRootFolder))
                Directory.CreateDirectory(upLoadsRootFolder);

            if (file == null || file.Length == 0)
                return new UploadDto
                {
                    IsHaveStatus = false,
                    FileNameAddress = ""
                };

            var fileName = DateTime.Now.Ticks.ToString() + file.FileName;
            var filePath = Path.Combine(upLoadsRootFolder, fileName);
            using (var fileStream = new FileStream(filePath,FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return new UploadDto
            {
                IsHaveStatus = true,
                FileNameAddress = folder + fileName
            };
        }
        return null;
    }


    public ServiceResultDto Execute(RequestAddNewProductDto request)
    {
        try
        {

            if (string.IsNullOrWhiteSpace(request.Name))
                return new ServiceResultDto
                {
                    IsSuccess = false,
                    Message = "لطفا نام محصول را وارد کنید"
                };

            if (string.IsNullOrWhiteSpace(request.Brand))
                return new ServiceResultDto
                {
                    IsSuccess = false,
                    Message = "لطفا نام برند محصول را وارد کنید"
                };

            Category? category = _context.Categories.Find(request.CategoryId);

            var product = new Product
            {
                Name = request.Name,
                Brand = request.Brand,
                Description = request.Description,
                Price = request.Price,
                CountOfProductInInventory = request.CountOfProductInInventory,
                IsThisProductBeDisplayedOnTheSite = request.IsThisProductBeDisplayedOnTheSite,
                Category = category
            };
            _context.Products.Add(product);

            List<ProductImage> productImages = new List<ProductImage>();
            foreach (var productImagesFormFile in request.Image)
            {
                var upLoadedResult = UploadFile(productImagesFormFile,request.Brand + request.Name);
                productImages.Add(new ProductImage
                {
                    ImageSrc = upLoadedResult?.FileNameAddress,
                    Product = product,
                });
            }
            _context.ProductImages.AddRange(productImages);

            List<ProductFeatures> productFeatures = new List<ProductFeatures>();
            foreach (var ProductFeature in request.Features)
            {
                productFeatures.Add(new ProductFeatures
                {
                    FeaturesName = ProductFeature.FeaturesName,
                    FeaturesValue = ProductFeature.FeaturesValue,
                    Product = product
                });
            }
            _context.ProductFeatures.AddRange(productFeatures);

            _context.SaveChanges();
            return new ServiceResultDto
            {
                IsSuccess = true,
                Message = "محصول با موفقیت به محصولات کالا مارکت اضافه شد"
            };
        }
        catch (Exception)
        {
            return new ServiceResultDto
            {
                IsSuccess = false,
                Message = "محصول با موفقیت به محصولات کالا مارکت اضافه نشد"
            };
        }
    }
}