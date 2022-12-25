using EndPoint.MVCWebApplicationUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using EndPoint.MVCWebApplicationUI.Models.DAL.ViewModel.HomePage;
using EStor.Application.Services.Common.QueriesService.GetHomePageImages;
using EStor.Application.Services.Common.QueriesService.GetSlider;

namespace EndPoint.MVCWebApplicationUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGetSliderService _getSlider;
        private readonly IGetHomePageImages _getHomePageImages;

        public HomeController(ILogger<HomeController> logger
            , IGetSliderService getSlider
            , IGetHomePageImages getHomePageImages)
        {
            _logger = logger;
            _getSlider = getSlider;
            _getHomePageImages = getHomePageImages;
        }

        public IActionResult Index()
        {
            HomePageViewModel model = new HomePageViewModel
            {
                Sliders = _getSlider.Execute().Data,
                Images = _getHomePageImages.Execute().Data,
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}