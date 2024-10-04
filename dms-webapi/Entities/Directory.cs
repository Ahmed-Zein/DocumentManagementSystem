using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dms_webapi.Entities;

public class Directory
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Required] public DateTime CreatedAt { get; set; }

    [Required] public string DirectoryName { get; set; }
    [Required] public bool PublicDirectory { get; set; }
    [Required] public User User { get; set; }
    public ICollection<Document> Documents { get; set; } = new List<Document>();
}