using Core.Security.Dtos;
using Kodlama.Io.Devs.Application.Features.Auths.Dtos;
using MediatR;

namespace Kodlama.Io.Devs.Application.Features.Auths.Commands.Login;

public class LoginCommand : IRequest<LoginDto>
{
    public UserForLoginDto UserForLoginDto { get; set; }

    public string IpAddress { get; set; }
}