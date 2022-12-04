namespace EStor.Application.Services.Users.CommandsService.UserLogIn;

public class ResultUserLoginDto
{
    public long UserId { get; set; }
    public string Roles { get; set; }
    public string Name { get; set; }
}