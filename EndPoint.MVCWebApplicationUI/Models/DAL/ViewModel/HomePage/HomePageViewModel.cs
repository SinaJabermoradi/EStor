using EStor.Application.Services.Common.QueriesService.GetHomePageImages;
using EStor.Application.Services.Common.QueriesService.GetSlider;

namespace EndPoint.MVCWebApplicationUI.Models.DAL.ViewModel.HomePage
{
    public class HomePageViewModel
    {
        public List<GetSliderDto> Sliders { get; set; }
        public List<HomePageImagesDto> Images { get; set; }
    }
}
