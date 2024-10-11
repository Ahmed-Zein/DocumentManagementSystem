using System.ComponentModel.DataAnnotations;

namespace dms_webapi.Models;

public class UserRegistrationRequestDto
{
    [Required] public string FirstName { get; set; }
    
    [Required] public string LastName { get; set; }
    [Required, EmailAddress] public string Email { get; set; }
    [Required, MinLength(6)] public string Password { get; set; }
}