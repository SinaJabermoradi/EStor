using EStor.Application.Interfaces.Contexts;
using EStor.Application.Services.Products.CommandsService.AddNewProduct;
using EStor.CommonUtility.DTO;
using EStor.Domain.Entities.Products;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace EStor.Application.Services.Products.CommandsService.EditProduct;

public class EditProductService : IEditProductService
{
    private readonly IHostingEnvironment _environment;
    private readonly IDataBaseContext _context;
    public EditProductService(IDataBaseContext context
        , IHostingEnvironment environment)
    {
        _environment = environment;
        _context = context;
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
            using (var fileStream = new FileStream(filePath, FileMode.Create))
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



    public ServiceResultDto Execute(RequestProductForEditDto request)
    {
        try
        {
            var product = _context.Products.Find(request.Id);
            if (product == null)
                return new ServiceResultDto
                {
                    IsSuccess = false,
                    Message = ""
                };

            if (string.IsNullOrWhiteSpace(request.Name))
                return new ServiceResultDto
                {
                    IsSuccess = false,
                    Message = "لطفا نام ِمحصول را وارد نمایید",
                };


            if (string.IsNullOrWhiteSpace(request.Brand))
                return new ServiceResultDto
                {
                    IsSuccess = false,
                    Message = "لطفا نام برند ِمحصول را وارد نمایید",
                };

            // ویرایش محصول

            product.Name = request.Name;
            product.Brand = request.Brand;
            product.Description = request.Description;

            var category = _context.Categories.Find(request.CategoryId);
            product.CategoryId = request.CategoryId;

            product.Price = request.Price;
            product.IsThisProductBeDisplayedOnTheSite = request.IsThisProductBeDisplayedOnTheSite;
            product.CountOfProductInInventory = request.CountOfProductInInventory;

            _context.Products.Add(product);



            // ویرایش عکس های محصول

            List<ProductImage> images = new List<ProductImage>();
            foreach (var image in request.Images)
            {
                var upLoadNewImages = UploadFile(image , request.Brand + request.Name);
                images.Add(new ProductImage
                {
                    ImageSrc = upLoadNewImages?.FileNameAddress,
                    Product = product
                });
            }
            _context.ProductImages.AddRange(images);



            // ویرایش ویژگی های محصول 
            List<ProductFeatures> featuresList = new List<ProductFeatures>();
            foreach (var Feature in request.Features)
            {
                featuresList.Add(new ProductFeatures
                {
                    FeaturesName = Feature.FeaturesName,
                    FeaturesValue = Feature.FeaturesValue,
                    Product = product
                });
            }
            _context.SaveChanges();
            return new ServiceResultDto
            {
                IsSuccess = true,
                Message = "محصول با موفقیت ویرایش شد"
            };
        }
        catch (Exception)
        {
            return new ServiceResultDto
            {
                IsSuccess = false,
                Message = "محصول با موفقیت با موفقیت ویرایش نشد"
            };
        }
    }
}