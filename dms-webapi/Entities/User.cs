using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dms_webapi.Entities;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required] public string FirstName { get; set; }
    [Required] public string LastName { get; set; }

    [Required, EmailAddress] public string Email { get; set; }
    [Required] public string Password { get; set; }
    [Required] public Role Role { get; set; }
    [Required] public string WorkspaceName { get; set; }

    public ICollection<Directory> Directories { get; set; } = new List<Directory>();
}