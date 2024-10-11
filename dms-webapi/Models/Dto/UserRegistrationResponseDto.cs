using System.ComponentModel.DataAnnotations;
using dms_webapi.Entities;

namespace dms_webapi.Models;

public class UserRegistrationResponseDto
{
    [Required] public string Id { get; set; }
    [Required] public Role Role { get; set; }
    [Required] public string FirstName { get; set; }
    [Required] public string LastName { get; set; }
    [Required] public string WorkspaceName { get; set; }
    [Required, EmailAddress] public string Email { get; set; }
}