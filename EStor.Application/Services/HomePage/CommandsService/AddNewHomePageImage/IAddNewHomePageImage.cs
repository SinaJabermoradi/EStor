using EStor.CommonUtility.DTO;

namespace EStor.Application.Services.HomePage.CommandsService.AddNewHomePageImage;

public interface IAddNewHomePageImage
{
    ServiceResultDto Execute(RequestAddHomePageImagesDto request);
}