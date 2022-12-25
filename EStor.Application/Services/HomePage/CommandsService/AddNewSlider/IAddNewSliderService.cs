using EStor.CommonUtility.DTO;
using Microsoft.AspNetCore.Http;

namespace EStor.Application.Services.HomePage.CommandsService.AddNewSlider;

public interface IAddNewSliderService
{
    ServiceResultDto Execute(IFormFile image, string sliderName, string link);
}