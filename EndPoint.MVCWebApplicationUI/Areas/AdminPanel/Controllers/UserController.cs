using EStor.Application.Services.Users.QueriesService.GetUsers;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.MVCWebApplicationUI.Areas.AdminPanel.Controllers
{
    [Controller]
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

        [Area("AdminPanel")]
        public IActionResult Index(string searchKey, int page = 1)
        {
            return View(_usersService.Execute(new GetUserRequestDto
            {
                Page = page,
                SearchKey = searchKey
            }));
        }

        #endregion

        #endregion

    }
}
