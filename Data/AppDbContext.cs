using Microsoft.EntityFrameworkCore;
using PC3_Progra1.Models;

namespace PC3_Progra1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Feedback> Feedbacks { get; set; }
    }
}
