using dms_webapi.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Directory = dms_webapi.Entities.Directory;

namespace dms_webapi.Data;

public class DocumentDbContext : IdentityDbContext<User>
{
    public DocumentDbContext(DbContextOptions<DocumentDbContext> options) : base(options)
    {
    }

    // public DbSet<User> Users { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<Directory> Directories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var hasher = new PasswordHasher<User>();

        // Enforce unique Email in User
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        // Seed data with correct syntax
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = "1",
                FirstName = "Admin",
                LastName = "User",
                Email = "admin@dms.com",
                PasswordHash = hasher.HashPassword(null, "admin123"), // Use proper hashing here
                WorkspaceName = "AdminSpace",
                Role = Role.Admin
            },
            new User
            {
                Id = "2",
                FirstName = "Grey",
                LastName = "Beast",
                Email = "greybeast@dms.com",
                PasswordHash = hasher.HashPassword(null, "grey123"), // Use proper hashing here
                WorkspaceName = "GreyWorkspace",
                Role = Role.Admin
            }
        );
    }
}