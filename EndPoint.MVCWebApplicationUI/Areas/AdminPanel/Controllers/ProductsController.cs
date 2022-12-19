using System.Drawing.Design;
using EndPoint.MVCWebApplicationUI.Areas.AdminPanel.Models;
using EStor.Application.Services.Products.CommandsService.AddNewProduct;
using EStor.Application.Services.Products.CommandsService.EditProduct;
using EStor.Application.Services.Products.FacadPattern;
using EStor.Domain.Entities.Products;
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

        public IActionResult Index(int pageNumber = 1
        , int countOfProductOnThePage = 20)
        {
            return View(_productFacad.GetProductForAdminService.Execute(pageNumber,countOfProductOnThePage).Data);
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



        [HttpPost]
        public IActionResult Delete(long productId)
         {
            return Json(_productFacad.RemoveProductService.Execute(productId));
        }


        [HttpGet]
        public IActionResult Detail([FromQuery]long productId)
        {
            return View(_productFacad.GetProductDetailForAdminService.Execute(productId).Data);
        }


        [HttpGet]
        public IActionResult Edit([FromQuery]long productId)
        {
            ViewBag.AllCategories = new SelectList(_productFacad.GetAllCategoriesService.Execute().Data, "CategoryId", "CategoryName");
            return View(_productFacad.GetProductDetailForAdminService.Execute(productId).Data);
        }



        [HttpPost]
        public IActionResult Edit(EditProductViewModel request
                , List<AddNewProduct_Features> features)
        {
            List<IFormFile> images = new List<IFormFile>();
            for (int i = 0; i < Request.Form.Files.Count; i++)
            {
                var file = Request.Form.Files[i];
                images.Add(file);
            }
            request.Images = images;
            request.Features = features;

            return Json(_productFacad.EditProductService.Execute(new RequestProductForEditDto
            {
                Id = request.Id,
                Name = request.Name,
                CategoryId = request.CategoryId,
                Brand = request.Brand,
                Description = request.Description,
                Price = request.Price,
                IsThisProductBeDisplayedOnTheSite = request.IsThisProductBeDisplayedOnTheSite,
                CountOfProductInInventory = request.CountOfProductInInventory,
                Features = request.Features,
                Images = request.Images
            }));
        }
    }
}
