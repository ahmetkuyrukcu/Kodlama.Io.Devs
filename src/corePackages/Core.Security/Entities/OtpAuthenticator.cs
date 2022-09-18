using Core.Persistence.Repositories;

namespace Core.Security.Entities;

public class OtpAuthenticator : Entity
{
    public Guid UserId { get; set; }

    public IEnumerable<byte> SecretKey { get; set; }

    public bool IsVerified { get; set; }

    public virtual User User { get; set; }

    public OtpAuthenticator()
    {
    }

    public OtpAuthenticator(Guid id, Guid userId, IEnumerable<byte> secretKey, bool isVerified) : this()
    {
        Id = id;
        UserId = userId;
        SecretKey = secretKey;
        IsVerified = isVerified;
    }
}