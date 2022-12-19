using EStor.Application.Services.Common.QueriesService.GetMenuItem;
using Microsoft.AspNetCore.Mvc;


namespace EndPoint.MVCWebApplicationUI.ViewComponents
{
    public class GetMenu : ViewComponent
    {
        private readonly IGetMenuItemService _menuItemService;
        public GetMenu(IGetMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }


        public IViewComponentResult Invoke()
        {
            return View(viewName: "GetMenu", model: _menuItemService.Execute().Data);
        }
    }
}


