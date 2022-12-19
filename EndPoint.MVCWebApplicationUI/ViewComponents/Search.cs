using EStor.Application.Services.Common.QueriesService.GetCategoryForSearch;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.MVCWebApplicationUI.ViewComponents
{
    public class Search : ViewComponent
    {
        private readonly IGetCategoryForSearchService _getCategoryForSearch;
        public Search(IGetCategoryForSearchService getCategoryForSearch)
        {
            _getCategoryForSearch = getCategoryForSearch;
        }

        public IViewComponentResult Invoke()
        {
            return View(viewName: "Search", model: _getCategoryForSearch.Execute().Data);
        }
    }
}
