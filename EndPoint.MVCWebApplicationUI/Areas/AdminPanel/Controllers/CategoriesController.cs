using EStor.Application.Services.Products.FacadPattern;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.MVCWebApplicationUI.Areas.AdminPanel.Controllers
{
    [Controller]
    [Area("AdminPanel")]
    public class CategoriesController : Controller //  دسته بندی محصولات
    {
        private readonly IProductFacad _productFacad;

        public CategoriesController(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }

        [HttpGet]
        public IActionResult Index(long? parentId)
        {
            return View(_productFacad.GetCategoriesService.Execute(parentId).Data);
        }

        [HttpGet]
        public IActionResult AddNewCategory(long? parentId)
        {
            ViewBag.ParentId = parentId;
            return View();
        }

        [HttpPost]
        public IActionResult AddNewCategory(long? parentId
                        , string name)
        {
            var addNewCategoryResult = _productFacad.AddNewCategoryService.Execute(parentId, name);
            return Json(addNewCategoryResult);
        }
    }
}
