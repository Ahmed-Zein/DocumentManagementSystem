using dms_webapi.Entities;
using dms_webapi.Models;

namespace dms_webapi.Services;

public interface IUserServices
{
    public Task<User?> RegisterUser(UserRegistrationRequestDto userModel);
    // TODO: add login.
    // public String Login(User user);
}