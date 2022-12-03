using EStor.Application.Services.Users.CommandsService.EditUser;
using EStor.Application.Services.Users.CommandsService.RegisterUser;
using EStor.Application.Services.Users.CommandsService.RemoveUser;
using EStor.Application.Services.Users.CommandsService.UserStatusChange;
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

        private readonly IGetUsersService _getUsersService;
        private readonly IGetRolesService _rolesService;
        private readonly IRegisterUserService _registerUserService;
        private readonly IRemoveUserService _removeUserService;
        private readonly IUserStatusChangeService _userStatusChangeService;
        private readonly IEditUserService _editUserService;

        #endregion


        #region Behavior

        #region Constructor

        public UserController(IGetUsersService getUsersService,
                        IGetRolesService rolesService,
                        IRegisterUserService registerUserService ,
                        IRemoveUserService removeUserService,
                        IUserStatusChangeService userStatusChangeService,
                        IEditUserService editUserService)
        {
            _getUsersService = getUsersService;
            _rolesService = rolesService;
            _registerUserService = registerUserService;
            _removeUserService = removeUserService;
            _userStatusChangeService = userStatusChangeService;
            _editUserService = editUserService;
        }

        #endregion

        #region ActionMethod

        [HttpGet]
        public IActionResult Index(string searchKey
                     ,int page = 1)
        {
            return View(_getUsersService.Execute(new GetUserRequestDto
            {
                Page = page,
                SearchKey = searchKey
            }));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_rolesService.Execute().Data, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(string FullName
                   , string Email
                   , long RoleId
                   , string Password
                   , string RePassword)
        {
            var result = _registerUserService.Execute(new RequestRegisterUserDto
            {
                FullName = FullName,
                Email = Email,
                Password = Password,
                RePassword = RePassword,
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


        [HttpPost]
        public IActionResult Delete(long UserId)
        {
            return Json(_removeUserService.Execute(UserId));
        }


        [HttpPost]
        public IActionResult UserStatusChange(long UserId)
        {
            return Json(_userStatusChangeService.Execute(UserId));
        }


        [HttpPost]
        public IActionResult Edit(long UserId 
                       , string FullName
                       , string Email
                       , string Password
                       , string RePassword)
        {
            return Json(_editUserService.Execute(new RequestEditUserDto
            {
                UserId = UserId,
                FullName = FullName,
                Email = Email,
                Password = Password,
                RePassword = RePassword
            }));

        }



        #endregion

        #endregion

    }
}
