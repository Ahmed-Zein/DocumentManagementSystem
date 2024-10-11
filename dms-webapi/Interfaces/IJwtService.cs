using dms_webapi.Entities;

namespace dms_webapi.Services;

public interface IJwtService
{
    public string GenerateToken(User user);
    public bool ValidateToken(string token);
}