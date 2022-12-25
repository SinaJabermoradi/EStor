using System.Security.Claims;
using System.Text.RegularExpressions;
using EndPoint.MVCWebApplicationUI.Models.DAL.ViewModel.Authentication;
using EStor.Application.Services.Users.CommandsService.RegisterUser;
using EStor.Application.Services.Users.CommandsService.UserLogIn;
using EStor.CommonUtility.DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.MVCWebApplicationUI.Controllers
{
    [Controller]
    public class AuthenticationController : Controller
    {
        private readonly IRegisterUserService _registerUserService;
        private readonly IUserLoginService _userLoginService;

        public AuthenticationController(IRegisterUserService registerUserService
                                    , IUserLoginService userLoginService)
        {
            _registerUserService = registerUserService;
            _userLoginService = userLoginService;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(SignUpViewModel request)
        {
            if (string.IsNullOrWhiteSpace(request.FullName))
                return Json(new ServiceResultDto
                {
                    IsSuccess = false,
                    Message = "لطفا نام کاربری خودتون رو وارد کنید"
                });

            if (string.IsNullOrWhiteSpace(request.Email))
                return Json(new ServiceResultDto
                {
                    IsSuccess = false,
                    Message = "لطفا ایمیل خودتون رو وارد کنید"
                });

            if (string.IsNullOrWhiteSpace(request.Password))
                return Json(new ServiceResultDto
                {
                    IsSuccess = false,
                    Message = "لطفا رمز عبور خودتون رو وارد کنید"
                });

            if (string.IsNullOrWhiteSpace(request.RePassword))
                return Json(new ServiceResultDto
                {
                    IsSuccess = false,
                    Message = "لطفا تکرار رمز عبور خودتون رو وارد کنید"
                });

            if (request.Password != request.RePassword)
                return Json(new ServiceResultDto
                {
                    IsSuccess = false,
                    Message = "رمز عبور با تکرار آن برابر نیست"
                });

            if (request.Password.Length < 8)
                return Json(new ServiceResultDto
                {
                    IsSuccess = false, 
                    Message = "رمز عبور باید حداقل 8 کاراکتر باشد"
                });

            if (User.Identity.IsAuthenticated == true)
                return Json(new ServiceResultDto 
                    { 
                        IsSuccess = false, 
                        Message = "شما به حساب کاربری خود وارد شده اید! و در حال حاضر نمیتوانید ثبت نام مجدد نمایید  \n برای ثبت نام ابتدا از حساب کاربری خود خارج شوید سپس مجدد اقدام کنید"
                    });

            string emailRegex = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[A-Z0-9.-]+\.[A-Z]{2,}$";
            var match = Regex.Match(request.Email, emailRegex, RegexOptions.IgnoreCase);
            if (!match.Success)
                return Json(new ServiceResultDto
                {
                    IsSuccess = true,
                    Message = "ایمیل خود را به درستی وارد نمایید"
                });

            var signUpResult = _registerUserService.Execute(new RequestRegisterUserDto
            {
                Email = request.Email,
                FullName = request.FullName,
                Password = request.Password,
                RePassword = request.RePassword,
                Roles = new List<RolesInRegisterUserDto>
                {
                     new RolesInRegisterUserDto { Id = 3 }, // چون کسی که داره از این طریق ( یعنی بدونه پنل ِادمین ) ثبت نام میکنه ، قطعا فقط مشتری یا کاستومر هست ===> به همین خاطر آی دی رو برابر 3 گذاشتم. اگر قراره نقش دیگه ای داشته باشه فقط از طریق پنل ادمین و توسط ادیمن باید ثبت نام بشه و ادمین اونجا بهش یک نقش یا رول دیگه بده
                }
            });

            if (signUpResult.IsSuccess == true)
            {
                var claims = new List<Claim>
                     {
                            new Claim(ClaimTypes.NameIdentifier,signUpResult.Data.UserId.ToString()),
                            new Claim(ClaimTypes.Email, request.Email),
                            new Claim(ClaimTypes.Name, request.FullName),
                            new Claim(ClaimTypes.Role, EStor.CommonUtility.Roles.Roles.Customer),
                     };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true
                };
                HttpContext.SignInAsync(principal, properties);
            }
            return Json(signUpResult);
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(SignInViewModel request)
        {
            var signUpResult = _userLoginService.Execute(request.Email, request.Password);
            if (signUpResult.IsSuccess== true)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,signUpResult.Data.UserId.ToString()),
                    new Claim(ClaimTypes.Email, request.Email),
                    new Claim(ClaimTypes.Name, signUpResult.Data.Name),
                    new Claim(ClaimTypes.Role, signUpResult.Data.Roles ),
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.Now.AddDays(5),
                };
                HttpContext.SignInAsync(principal, properties);

            }
            return Json(signUpResult);
        }


        [HttpGet]
        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Home");
        }

    }
}
