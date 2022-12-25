using EStor.Application.Interfaces.Contexts;
using EStor.CommonUtility.DTO;
using Microsoft.EntityFrameworkCore;

namespace EStor.Application.Services.Common.QueriesService.GetSlider;

public class GetSliderService : IGetSliderService
{
    private readonly IDataBaseContext _context;
    public GetSliderService(IDataBaseContext context)
    {
        _context = context;
    }

    public ServiceResultDto<List<GetSliderDto>> Execute()
    {
        var sliders = _context.Slider
            .OrderByDescending(slider => slider.Id)
            .ToList()
            .Select(slider => new GetSliderDto
            {
                Link = slider.Link,
                ImageSrc = slider.ImageSrc
            }).ToList();

        return new ServiceResultDto<List<GetSliderDto>>
        {
            IsSuccess = true,
            Message = "",
            Data = sliders
        };
    }
}