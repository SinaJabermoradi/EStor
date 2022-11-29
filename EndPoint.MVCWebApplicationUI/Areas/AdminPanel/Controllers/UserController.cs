using EStor.Application.Services.Users.CommandsService.RegisterUser;
using EStor.Application.Services.Users.QueriesService.GetRoles;
using EStor.Application.Services.Users.QueriesService.GetUsers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EndPoint.MVCWebApplicationUI.Areas.AdminPanel.Controllers
{
    [Controller]
    [Area("AdminPanel")]
    public class UserController : Controller
    {
        #region Filds

        private readonly IGetUsersService _usersService;
        private readonly IGetRolesService _rolesService;
        private readonly IRegisterUserService _registerUserService;

        #endregion


        #region Behavior

        #region Constructor

        public UserController(IGetUsersService usersService , 
                                              IGetRolesService rolesService,
                                              IRegisterUserService registerUserService)
        {
            _usersService = usersService;
            _rolesService = rolesService;
            _registerUserService = registerUserService;
        }

        #endregion

        #region ActionMethod

        [HttpGet]
        public IActionResult Index(string searchKey, 
                                                      int page = 1)
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
            ViewBag.Roles = new SelectList(_rolesService.Execute().Data,"Id","Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(string FullName ,
                                                        string Email , 
                                                        long RoleId , 
                                                        string Password , 
                                                        string RePassword)
        {
            var result = _registerUserService.Execute(new RequestRegisterUserDto
            {
                FullName = FullName,
                Email = Email ,
                Password = Password ,
                RePassword = RePassword ,
               Roles = new List<RolesInRegisterUserDto>
               {
                   new RolesInRegisterUserDto
                   {
                       Id = RoleId
                   }
               }
            });
            return Json(result);
        }


        #endregion

        #endregion

    }
}
