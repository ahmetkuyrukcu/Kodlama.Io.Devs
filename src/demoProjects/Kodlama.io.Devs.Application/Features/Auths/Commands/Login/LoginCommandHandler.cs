using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Hashing;
using Kodlama.Io.Devs.Application.Features.Auths.Dtos;
using Kodlama.Io.Devs.Application.Services.AuthService;
using Kodlama.Io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.Io.Devs.Application.Features.Auths.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;

    public LoginCommandHandler(IUserRepository userRepository, IAuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }

    public async Task<LoginDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAsync(x => x.Email == request.UserForLoginDto.Email && x.Status, cancellationToken);

        if (user == null)
        {
            throw new BusinessException("Email not found!");
        }

        HashingHelper.CreatePasswordHash(request.UserForLoginDto.Password, out var passwordHash, out var passwordSalt);

        if (user.PasswordHash.SequenceEqual(passwordHash) || user.PasswordSalt.SequenceEqual(passwordSalt))
        {
            throw new BusinessException("Password wrong!");
        }

        var accessToken = await _authService.CreateAccessToken(user);

        var refreshToken = await _authService.CreateRefreshToken(user, request.IpAddress);

        var addedRefreshToken = await _authService.AddRefreshToken(refreshToken);

        return new LoginDto
        {
            AccessToken = accessToken,
            RefreshToken = addedRefreshToken,
        };
    }
}