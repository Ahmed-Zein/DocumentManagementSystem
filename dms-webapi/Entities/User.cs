using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace dms_webapi.Entities;

public class User : IdentityUser
{
    [Required, MaxLength(255)] public string FirstName { get; set; } = string.Empty;
    [Required, MaxLength(255)] public string LastName { get; set; } = string.Empty;
    [Required] public override string Email { get; set; } = string.Empty;
    [Required] public Role Role { get; set; } = Role.DmsUser;
    [Required, MaxLength(255)] public string WorkspaceName { get; set; } = string.Empty;

    public ICollection<Directory> Directories { get; set; } = new List<Directory>();
}