using dotnet_site.Database.Tables;
using Microsoft.EntityFrameworkCore;

namespace dotnet_site.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {

    }
    public DbSet<Lesson> Lessons {get; set;}
}