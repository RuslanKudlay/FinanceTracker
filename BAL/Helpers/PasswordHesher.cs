using System.Security.Cryptography;
using System.Text;

namespace BAL.Helpers;

public static class PasswordHesher
{
    public static string GetHash(string password)
    {
        var bytes = new UTF8Encoding().GetBytes(password);
        byte[] hashBytes;
        using (var algorithm = new SHA512Managed())
        {
            hashBytes = algorithm.ComputeHash(bytes);
        }

        return Convert.ToBase64String(hashBytes);
    }
}