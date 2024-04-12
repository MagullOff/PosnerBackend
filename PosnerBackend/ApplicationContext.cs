using Microsoft.EntityFrameworkCore;

namespace PosnerBackend;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
    public DbSet<GameResultEntity> GameResults { get; set; }
}

public class GameResultEntity
{
    public Guid Id { get; set; }
    public int ClueInformationLevel { get; set; }
    public double AverageSpeed { get; set; }
    public string AttemptsJson { get; set; }
}