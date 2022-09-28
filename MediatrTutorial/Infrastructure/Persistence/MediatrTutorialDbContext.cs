namespace MediatrTutorial.Infrastructure.Persistence;

public class MediatrTutorialDbContext : DbContext
{
    public MediatrTutorialDbContext(DbContextOptions<MediatrTutorialDbContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
}