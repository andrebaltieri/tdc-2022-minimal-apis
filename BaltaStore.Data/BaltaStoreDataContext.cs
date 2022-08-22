using BaltaStore.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BaltaStore.Data;

public class BaltaStoreDataContext : DbContext
{
    public BaltaStoreDataContext(DbContextOptions<BaltaStoreDataContext> options) : base(options)
    {
    }

    public DbSet<Student> Students { get; set; } = null!;
}