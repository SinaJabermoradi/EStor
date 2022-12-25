using EStor.Application.Services.HomePage.CommandsService.AddNewSlider;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.MVCWebApplicationUI.Areas.AdminPanel.Controllers
{
    [Controller]
    [Area("AdminPanel")]
    public class SlidersController : Controller
    {
        private readonly IAddNewSliderService _addNewSlider;
        public SlidersController(IAddNewSliderService addNewSlider)
        {
            _addNewSlider = addNewSlider;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Add(List<IFormFile> image
            , string link 
            , string sliderName)
        {
            var file = Request.Form.Files[0];
            return Json(_addNewSlider.Execute(file, sliderName, link));
        }


        //public IActionResult Delete()
        //{
        // TODO ===> ادمین بتواند یک اسلایدر را از صفحه اصلی حذف کند
        //}


        //public IActionResult Edit()
        //{
        // TODO ===> ادمین بتواند یک اسلایدر را در صفحه اصلی ویرایش کند
        //}

    }
}
