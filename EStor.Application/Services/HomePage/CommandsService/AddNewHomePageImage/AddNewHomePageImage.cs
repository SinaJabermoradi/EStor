using EStor.Application.Interfaces.Contexts;
using EStor.CommonUtility.DTO;
using EStor.Domain.Entities.HomePage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace EStor.Application.Services.HomePage.CommandsService.AddNewHomePageImage;

public class AddNewHomePageImage : IAddNewHomePageImage
{
    private readonly IDataBaseContext _context;
    private readonly IHostingEnvironment _environment;

    public AddNewHomePageImage(IDataBaseContext context, IHostingEnvironment environment)
    {
        _context = context;
        _environment = environment;
    }


    public ServiceResultDto Execute(RequestAddHomePageImagesDto request)
    {
        try
        {
            var upLoadResult = UploadFile(request.File,request.ImageName);

            _context.HomePageImages.Add(new HomePageImage
            {
                Link = request.Link,
                ImageSrc = upLoadResult.FileNameAddress,
                ImageLocation = request.ImageLocation,
            });
            _context.SaveChanges();

            return new ServiceResultDto
            {
                IsSuccess = true,
                Message = "تصویر با موفقیت به صفحه اصلی اضافه شد",
            };
        }
        catch (Exception e)
        {
            return new ServiceResultDto
            {
                IsSuccess = false,
                Message = "تصویر  به صفحه اصلی اضافه نشد" + e.Message,
            };
        }
    }

    private UploadDto? UploadFile(IFormFile file
        , string imageName)
    {
        if (file != null)
        {
            string folder = $@"images\HomePage\Images\{imageName}\";
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

}