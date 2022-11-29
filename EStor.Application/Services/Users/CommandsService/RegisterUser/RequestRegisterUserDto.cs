﻿namespace EStor.Application.Services.Users.CommandsService.RegisterUser;

public class RequestRegisterUserDto
{
    public string FullName { get; set; }

    public string Email { get; set; }

    public List<RolesInRegisterUserDto> Roles { get; set; }

    public string Password { get; set; }

    public string RePassword { get; set; }

}