using System.Globalization;
using System.Security.Cryptography;

namespace Core.Security.EmailAuthenticator;

public class EmailAuthenticatorHelper : IEmailAuthenticatorHelper
{
    public Task<string> CreateEmailActivationKey()
    {
        return Task.FromResult(Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)));
    }

    public Task<string> CreateEmailActivationCode()
    {
        return Task.FromResult(RandomNumberGenerator.GetInt32(Convert.ToInt32(Math.Pow(10, 6), CultureInfo.InvariantCulture)).ToString(CultureInfo.InvariantCulture).PadLeft(6, '0'));
    }
}