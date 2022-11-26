using Microsoft.AspNetCore.Mvc;

namespace EndPoint.MVCWebApplicationUI.Areas.AdminPanel.Controllers
{
    [Controller]
    public class UserController : Controller
    {
        [Area("AdminPanel")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
