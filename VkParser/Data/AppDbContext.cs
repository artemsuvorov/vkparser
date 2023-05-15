using Microsoft.EntityFrameworkCore;
using VkParser.Models;

namespace VkParser.Data;

public class AppDbContext : DbContext
{
    public DbSet<PostInfo> PostInfos { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql();
    }
}
