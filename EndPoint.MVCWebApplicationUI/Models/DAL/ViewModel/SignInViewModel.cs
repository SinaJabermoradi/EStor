namespace EndPoint.MVCWebApplicationUI.Models.DAL.ViewModel
{
    public class SignInViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string url { get; set; } = "/Home/Index";
    }
}
