using Microsoft.EntityFrameworkCore;

namespace Rinha.Api;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Pessoa> Pessoas {get; set;}
}
