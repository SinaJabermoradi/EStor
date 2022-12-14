using EStor.Application.Services.Products.FacadPattern;
using EStor.Application.Services.Products.QueriesService.GetProductForSite;
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
        public IActionResult Index(Ordering ordering
                        , string searchKey
                        , long? categoryId
                        , int page = 1
                        , int pageSize = 20)
        {
            return View(_productFacad.GetProductForSite.Execute(ordering, searchKey, page, pageSize, categoryId).Data);
        }


        [HttpGet]
        public IActionResult Detail([FromQuery]long productId)
        {
            return View(_productFacad.GetProductDetailForSite.Execute(productId).Data);
        }

    }
}
