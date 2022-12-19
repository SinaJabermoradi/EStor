using EStor.Application.Services.Products.FacadPattern;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.MVCWebApplicationUI.Controllers
{
    [Controller]
    public class ProductsController : Controller
    {
        private readonly IProductFacad _productFacad;
        public ProductsController(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }


        [HttpGet]
        public IActionResult Index(string searchKey
                        , long? categoryId
                        , int page)
        {
            return View(_productFacad.GetProductForSite.Execute(searchKey,page , categoryId).Data);
        }


        [HttpGet]
        public IActionResult Detail([FromQuery]long productId)
        {
            return View(_productFacad.GetProductDetailForSite.Execute(productId).Data);
        }

    }
}
