using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace DAL;

public class AuthOptions
{
    public const string ISSUER = "financetrack_service";
    public const string AUDIENCE = "financetrack_client";
    const string KEY = "fekm@#E%$egrg345re34#$%#%^rgergrtg";
    public const int LIFETIME = 15; // minutes
    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
    }
}