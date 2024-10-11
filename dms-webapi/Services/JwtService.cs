using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using dms_webapi.Entities;
using Microsoft.IdentityModel.Tokens;

namespace dms_webapi.Services;

public class JwtService : IJwtService
{
    private readonly string _jwtSecret;

    public JwtService(IConfiguration configuration)
    {
        _jwtSecret = configuration.GetSection("JwtConfig:Secret").Value ??
                     throw new ArgumentNullException(nameof(configuration) + ":JwtSecret:Secret");
    }

    public string GenerateToken(User user)
    {
        var key = Encoding.ASCII.GetBytes(_jwtSecret);
        var jwtTokenHandler = new JwtSecurityTokenHandler();
        var jwtDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(
            [
                new Claim(JwtRegisteredClaimNames.NameId, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, value: user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),
            ]),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var securityToken = jwtTokenHandler.CreateToken(jwtDescriptor);

        return jwtTokenHandler.WriteToken(securityToken);
    }

    public bool ValidateToken(string token)
    {
        throw new NotImplementedException();
    }
}