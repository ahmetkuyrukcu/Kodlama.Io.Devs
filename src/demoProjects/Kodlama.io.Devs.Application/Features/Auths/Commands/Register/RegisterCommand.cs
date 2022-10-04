using Core.Security.Dtos;
using Kodlama.Io.Devs.Application.Features.Auths.Dtos;
using MediatR;

namespace Kodlama.Io.Devs.Application.Features.Auths.Commands.Register;

public class RegisterCommand : IRequest<RegisterDto>
{
    public UserForRegisterDto UserForRegisterDto { get; set; }

    public string IpAddress { get; set; }
}