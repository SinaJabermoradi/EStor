namespace EStor.Application.Services.Users.CommandsService.EditUser;

public class RequestEditUserDto
{
    public long UserId { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string RePassword { get; set; }
}