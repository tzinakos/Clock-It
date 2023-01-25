using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options) { }

    private DbSet<User> Users { get; set; }
    
    private DbSet<Project> Projects { get; set; }
    
    private DbSet<Settings> Settings { get; set; }
}