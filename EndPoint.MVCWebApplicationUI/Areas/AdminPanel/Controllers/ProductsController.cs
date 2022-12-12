using System.Drawing.Design;
using EndPoint.MVCWebApplicationUI.Areas.AdminPanel.Models;
using EStor.Application.Services.Products.CommandsService.AddNewProduct;
using EStor.Application.Services.Products.FacadPattern;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EndPoint.MVCWebApplicationUI.Areas.AdminPanel.Controllers
{
    [Controller]
    [Area("AdminPanel")]
    public class ProductsController : Controller
    {
        private readonly IProductFacad _productFacad;

        public ProductsController(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult AddNewProduct()    
        {
            ViewBag.AllCategories = new SelectList(_productFacad.GetAllCategoriesService.Execute().Data, "CategoryId", "CategoryName");  // لیست تمامی دسته بندی محصولات موجود در سایت مون رو به کمک این کد به دست میاریم . در این لیست ، نام و آیدی اون دسته بندی ها رو داریم
            return View();
        }


        [HttpPost]
        public IActionResult AddNewProduct(AddNewProductViewModel request,
                                                        List<AddNewProduct_Features> features)
        {
            List<IFormFile> images = new List<IFormFile>();
            for (int i = 0; i < Request.Form.Files.Count; i++)
            {
                var file = Request.Form.Files[i];
                images.Add(file);
            }
            request.Image = images;
            request.Features = features;
            
            var Result = _productFacad.AddNewProductService.Execute(new RequestAddNewProductDto
            {
                Name = request.Name,
                Brand = request.Brand,
                Description = request.Description,
                Price = request.Price,
                IsThisProductBeDisplayedOnTheSite = request.IsThisProductBeDisplayedOnTheSite,
                CountOfProductInInventory = request.CountOfProductInInventory,
                CategoryId = request.CategoryId,
                Image = request.Image,
                Features = request.Features
            });
            return Json(Result);
        }
    }


}
