using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UlsaPhrases.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
    public DbSet<UlsaPhrases.Models.Phrase> Phrase { get; set; } = default!;
    }
}
