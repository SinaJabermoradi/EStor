using System.Diagnostics.CodeAnalysis;

namespace EndPoint.MVCWebApplicationUI.Models.DAL.ViewModel
{
    public class SignUpViewModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
    }
}
