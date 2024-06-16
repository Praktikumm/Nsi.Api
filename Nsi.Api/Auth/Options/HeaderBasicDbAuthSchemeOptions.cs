using Microsoft.AspNetCore.Authentication;

namespace Nsi.Api.Auth.Options;

public class HeaderBasicDbAuthSchemeOptions : AuthenticationSchemeOptions
{
    public string Username { get; set; } = "X-Nsi-Username";
    public string Password { get; set; } = "X-Nsi-Password";
}