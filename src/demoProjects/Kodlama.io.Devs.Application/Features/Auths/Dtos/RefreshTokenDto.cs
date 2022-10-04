using Core.Security.Entities;
using Core.Security.JWT;

namespace Kodlama.Io.Devs.Application.Features.Auths.Dtos;

public class RefreshTokenDto
{
    public AccessToken AccessToken { get; set; }

    public RefreshToken RefreshToken { get; set; }
}