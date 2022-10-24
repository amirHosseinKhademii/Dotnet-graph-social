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

    public string Authenticate(string id, string email)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new Claim[]
        {
            new Claim(ClaimTypes.Sid, id),
            new Claim(ClaimTypes.Name, email),
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDesc = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(3600),
            SigningCredentials = credentials
        };
        var token = tokenHandler.CreateToken((tokenDesc));
        return tokenHandler.WriteToken(token);
    }
}