using EStor.CommonUtility.DTO;

namespace EStor.Application.Services.Common.QueriesService.GetHomePageImages;

public interface IGetHomePageImages
{
    ServiceResultDto<List<HomePageImagesDto>> Execute();
}