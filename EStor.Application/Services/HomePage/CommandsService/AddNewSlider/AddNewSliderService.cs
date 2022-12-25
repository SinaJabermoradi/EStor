using EStor.Application.Interfaces.Contexts;
using EStor.CommonUtility.DTO;
using EStor.Domain.Entities.HomePage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace EStor.Application.Services.HomePage.CommandsService.AddNewSlider;

public class AddNewSliderService : IAddNewSliderService
{
    private readonly IDataBaseContext _context;
    private readonly IHostingEnvironment _environment;

    public AddNewSliderService(IDataBaseContext context
        , IHostingEnvironment environment)
    {
        _context = context;
        _environment = environment;
    }

    public ServiceResultDto Execute(IFormFile image
        , string sliderName
        , string link)
    {
        try
        {
            var upLoadedResult = UploadFile(image, sliderName);

            var slider = new Slider
            {
                Link = link,
                ImageSrc = upLoadedResult?.FileNameAddress,
            };
            _context.Slider.Add(slider);
            _context.SaveChanges();

            return new ServiceResultDto
            {
                IsSuccess = true,
                Message = "اسلایدر با موفقیت ساخته شد"
            };
        }

        catch (Exception e)
        {
            return new ServiceResultDto
            {
                IsSuccess = false,
                Message = "اسلایدر با موفقیت ساخته نشد" + "\n\n" + e.Message
            };
        }
    }

    private UploadDto? UploadFile(IFormFile file
        , string sliderName)
    {
        if (file != null)
        {
            string folder = $@"images\HomePage\Sliders\{sliderName}\";
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