using EStor.Application.Interfaces.Contexts;
using EStor.CommonUtility.DTO;

namespace EStor.Application.Services.Common.QueriesService.GetHomePageImages;

public class GetHomePageImages : IGetHomePageImages
{
    private readonly IDataBaseContext _context;
    public GetHomePageImages(IDataBaseContext context)
    {
        _context = context;
    }

    public ServiceResultDto<List<HomePageImagesDto>> Execute()
    {
        var image = _context.HomePageImages
            .OrderByDescending(images => images.Id)
            .Select(images => new HomePageImagesDto
            {
                Id = images.Id,
                Link = images.Link,
                ImageLocation = images.ImageLocation,
                ImageSrc = images.ImageSrc
            }).ToList();

        return new ServiceResultDto<List<HomePageImagesDto>>
        {
            IsSuccess = true,
            Data = image,
        };
    }
}