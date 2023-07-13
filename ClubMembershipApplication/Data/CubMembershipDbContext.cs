using ClubMembershipApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ClubMembershipApplication.Data;

public class CubMembershipDbContext: DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={AppDomain.CurrentDomain.BaseDirectory}ClubMemberShipDb.db");
        base.OnConfiguring(optionsBuilder);
    }
    
    public DbSet<User> Users { get; set; }
}