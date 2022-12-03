namespace EStor.Application.Services.Users.QueriesService.GetUsers;

public class UsersDto
{
    public long Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public bool IsActive { get; set; }
    public string Password { get; set; }
    public string RePassword { get; set; }
}