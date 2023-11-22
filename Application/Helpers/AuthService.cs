using System.Text;
using Application.Settings;
using Microsoft.IdentityModel.Tokens;

namespace Application.Helpers;

public class AuthService
{
    private const string key = "storemeinanotherplace";
    private const string issuer = "ancientRome";
    private const string audience = "cloudcom";
    private const int lifeTime = 1;

    public static JwtSettings Settings =>
        new JwtSettings
        {
            Issuer = issuer,
            Audience = audience,
            Lifetime = lifeTime
        };


    public static SymmetricSecurityKey GetSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
    }

}