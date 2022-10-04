using Core.Security.Entities;
using Core.Security.JWT;
using Kodlama.Io.Devs.Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.Io.Devs.Application.Services.AuthService;

public class AuthManager : IAuthService
{
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly ITokenHelper _tokenHelper;
    private readonly IRefreshTokenRepository _refreshTokenRepository;

    public AuthManager(IUserOperationClaimRepository userOperationClaimRepository, ITokenHelper tokenHelper, IRefreshTokenRepository refreshTokenRepository)
    {
        _userOperationClaimRepository = userOperationClaimRepository;
        _tokenHelper = tokenHelper;
        _refreshTokenRepository = refreshTokenRepository;
    }

    public async Task<AccessToken> CreateAccessToken(User user)
    {
        var userOperationClaims = await _userOperationClaimRepository.GetListAsync(x => x.UserId == user.Id, include: x => x.Include(y => y.OperationClaim));

        var operationClaims = userOperationClaims.Items.Select(x => new OperationClaim { Id = x.OperationClaim.Id, Name = x.OperationClaim.Name }).ToList();

        return _tokenHelper.CreateToken(user, operationClaims);
    }

    public async Task<RefreshToken> CreateRefreshToken(User user, string ipAddress)
    {
        return await Task.FromResult(_tokenHelper.CreateRefreshToken(user, ipAddress));
    }

    public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
    {
        return await _refreshTokenRepository.AddAsync(refreshToken);
    }
}