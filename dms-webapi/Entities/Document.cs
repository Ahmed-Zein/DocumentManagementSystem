using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace dms_webapi.Entities;

public class Document
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required] public string FileName { get; set; }
    [Required] public string MimeType { get; set; }
    [Required] public DateTime DateCreated { get; set; } = DateTime.Now;

    public Directory? Directory { get; set; }
    [Required] public int DirectoryId { get; set; }
}