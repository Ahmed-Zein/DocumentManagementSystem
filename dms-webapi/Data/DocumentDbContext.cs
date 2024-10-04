using dms_webapi.Entities;
using Microsoft.EntityFrameworkCore;
using Directory = dms_webapi.Entities.Directory;

namespace dms_webapi.Data;

public class DocumentDbContext : DbContext
{
    public DocumentDbContext(DbContextOptions<DocumentDbContext> options) : base(options)
    {
    }

    DbSet<Document> Documents { get; set; }
    DbSet<User> Users { get; set; }
    DbSet<Directory> Directories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
        modelBuilder.Entity<User>().HasData([
            new User()
            {
                Id = 1,
                FirstName = "Admin",
                LastName = "User",
                Email = "admin@dms.com",
                Password = "admin123",
                WorkspaceName = "AdminSpace",
                Role = Role.Admin
            },
            new User()
            {
                Id = 2,
                FirstName = "grey",
                LastName = "beast",
                Email = "greybeast@dms.com",
                Password = "grey123",
                WorkspaceName = "greyWorkspace",
                Role = Role.Admin
            },
        ]);
    }
}