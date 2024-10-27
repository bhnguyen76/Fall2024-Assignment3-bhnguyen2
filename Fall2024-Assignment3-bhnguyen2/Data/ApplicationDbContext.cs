using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Fall2024_Assignment3_bhnguyen2.Models;

namespace Fall2024_Assignment3_bhnguyen2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Fall2024_Assignment3_bhnguyen2.Models.Actor> Actor { get; set; } = default!;
        public DbSet<Fall2024_Assignment3_bhnguyen2.Models.Movie> Movie { get; set; } = default!;
        public DbSet<Fall2024_Assignment3_bhnguyen2.Models.MovieActor> MovieActor { get; set; } = default!;
    }
}
