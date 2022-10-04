using Core.Security.Entities;
using Core.Security.Hashing;
using Kodlama.Io.Devs.Application.Features.Auths.Dtos;
using Kodlama.Io.Devs.Application.Features.Auths.Rules;
using Kodlama.Io.Devs.Application.Services.AuthService;
using Kodlama.Io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.Io.Devs.Application.Features.Auths.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterDto>
{
    private readonly AuthBusinessRules _authBusinessRules;
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;

    public RegisterCommandHandler(AuthBusinessRules authBusinessRules, IUserRepository userRepository, IAuthService authService)
    {
        _authBusinessRules = authBusinessRules;
        _userRepository = userRepository;
        _authService = authService;
    }

    public async Task<RegisterDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        await _authBusinessRules.EmailCanNotBeDuplicatedWhenRegistered(request.UserForRegisterDto.Email);

        HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out var passwordHash, out var passwordSalt);

        var newUser = new User
        {
            Email = request.UserForRegisterDto.Email,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            FirstName = request.UserForRegisterDto.FirstName,
            LastName = request.UserForRegisterDto.LastName,
            Status = true,
        };

        var user = await _userRepository.AddAsync(newUser);

        var accessToken = await _authService.CreateAccessToken(user);

        var refreshToken = await _authService.CreateRefreshToken(user, request.IpAddress);

        var addedRefreshToken = await _authService.AddRefreshToken(refreshToken);

        return new RegisterDto
        {
            AccessToken = accessToken,
            RefreshToken = addedRefreshToken,
        };
    }
}