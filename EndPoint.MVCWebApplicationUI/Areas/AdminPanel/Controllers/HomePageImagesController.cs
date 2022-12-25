using EndPoint.MVCWebApplicationUI.Areas.AdminPanel.Models;
using EStor.Application.Services.HomePage.CommandsService.AddNewHomePageImage;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.MVCWebApplicationUI.Areas.AdminPanel.Controllers
{
    [Controller]
    [Area("AdminPanel")]
    public class HomePageImagesController : Controller
    {
        private readonly IAddNewHomePageImage _addNewHomePageImage;
        public HomePageImagesController(IAddNewHomePageImage addNewHomePageImage)
        {
            _addNewHomePageImage = addNewHomePageImage;
        }

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
        public IActionResult Add(AddNewImageToHomePageViewModel request)
        {
            return Json(_addNewHomePageImage.Execute(new RequestAddHomePageImagesDto
            {
                File = request.ImageFile,
                Link = request.Link,
                ImageLocation = request.ImageLocation,
                ImageName = request.ImageName
            }));
        }

        //public IActionResult Delete()
        //{
        // TODO ===> ادمین بتواند یک تصویر را از صفحه اصلی حذف کند
        //}


        //public IActionResult Edit()
        //{
        // TODO ===> ادمین بتواند یک تصویر را در صفحه اصلی ویرایش کند
        //}


    }
}
