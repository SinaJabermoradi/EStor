using EStor.CommonUtility.DTO;

namespace EStor.Application.Services.Common.QueriesService.GetSlider;

public interface IGetSliderService
{
    ServiceResultDto<List<GetSliderDto>> Execute();
}