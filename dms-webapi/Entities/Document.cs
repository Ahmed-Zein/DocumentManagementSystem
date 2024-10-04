using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace dms_webapi.Entities;

public class Document
{
    [Key] public int Id { get; set; }
    [Required] public string FileName { get; set; }
    [Required] public string MimeType { get; set; }
    [Required] public DateTime DateCreated { get; set; }
    public Directory Directory { get; set; }
}