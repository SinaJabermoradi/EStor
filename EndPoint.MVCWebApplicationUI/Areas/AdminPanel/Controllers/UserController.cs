using EStor.Application.Services.Users.QueriesService.GetUsers;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.MVCWebApplicationUI.Areas.AdminPanel.Controllers
{
    [Controller]
    [Area("AdminPanel")]
    public class UserController : Controller
    {
        #region Filds

        private readonly IGetUsersService _usersService;

        #endregion


        #region Behavior

        #region Constructor

        public UserController(IGetUsersService usersService)
        {
            _usersService = usersService;
        }

        #endregion

        #region ActionMethod

        [HttpGet]
        public IActionResult Index(string searchKey, int page = 1)
        {
            return View(_usersService.Execute(new GetUserRequestDto
            {
                Page = page,
                SearchKey = searchKey
            }));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        #endregion

        #endregion

    }
}
