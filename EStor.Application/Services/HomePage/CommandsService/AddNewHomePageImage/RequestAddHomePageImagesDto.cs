using EStor.Domain.Entities.HomePage;
using Microsoft.AspNetCore.Http;

namespace EStor.Application.Services.HomePage.CommandsService.AddNewHomePageImage;

public class RequestAddHomePageImagesDto
{
    public string ImageName { get; set; }
    public IFormFile File { get; set; }
    public string Link { get; set; }
    public ImageLocation ImageLocation { get; set; }
}