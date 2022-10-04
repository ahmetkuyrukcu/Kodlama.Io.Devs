using Core.Security.Dtos;
using Core.Security.Entities;
using Kodlama.Io.Devs.Application.Features.Auths.Commands.Login;
using Kodlama.Io.Devs.Application.Features.Auths.Commands.Register;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.Io.Devs.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : BaseController
{
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
    {
        var registerCommand = new RegisterCommand
        {
            UserForRegisterDto = userForRegisterDto,
            IpAddress = GetIpAddress(),
        };

        var result = await Mediator.Send(registerCommand);
        SetRefreshTokenToCookie(result.RefreshToken);

        return Created(new Uri("about:blank"), result.AccessToken);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
    {
        var loginCommand = new LoginCommand
        {
            UserForLoginDto = userForLoginDto,
            IpAddress = GetIpAddress(),
        };

        var result = await Mediator.Send(loginCommand);
        SetRefreshTokenToCookie(result.RefreshToken);

        return Ok(result.AccessToken);
    }

    private void SetRefreshTokenToCookie(RefreshToken refreshToken)
    {
        var cookieOptions = new CookieOptions { HttpOnly = true, Expires = DateTime.Now.AddDays(7) };

        Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
    }
}