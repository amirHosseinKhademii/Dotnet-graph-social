using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using hot_demo.interfaces;
using Microsoft.IdentityModel.Tokens;

namespace hot_demo.utils;

public class JwtAuthentication : IJwtAuthentication
{
    private readonly string _key;

    public JwtAuthentication(string key)
    {
        _key = key;
    }

    public string Authenticate(string email)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.ASCII.GetBytes(_key);
        var tokenDesc = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, email)
                }
            ),
            Expires = DateTime.UtcNow.AddHours(3600),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature
            )
        };
        var token = tokenHandler.CreateToken((tokenDesc));
        return tokenHandler.WriteToken(token);
    }
}