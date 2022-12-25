using EStor.Domain.Entities.HomePage;

namespace EStor.Application.Services.Common.QueriesService.GetHomePageImages;

public class HomePageImagesDto
{
    public long Id { get; set; }
    public string ImageSrc { get; set; }
    public string Link { get; set; }
    public ImageLocation ImageLocation { get; set; }
}