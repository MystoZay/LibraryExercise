using Microsoft.EntityFrameworkCore;
using LibraryExercise.Models;

#pragma warning disable CS1591
/// <summary>
/// Database context for the API.
/// </summary>
public class AppDbContext: DbContext{

    /// <summary>
    /// Configuration for the database context.
    /// </summary>
    private readonly IConfiguration configuration;

    /// <summary>
    /// Gets/sets the Authors table in the database.
    /// </summary>
    public DbSet<Author> Authors { get; set; }

    /// <summary>
    /// Gets/sets the Books table in the database.
    /// </summary>
    public DbSet<Book> Books { get; set; }

    /// <summary>
    /// Gets/sets the Loans table in the database.
    /// </summary>
    public DbSet<Loan> Loans { get; set; }

    /// <summary>
    /// Constructor for the AppDbContext.
    /// </summary>
    /// <param name="configuration">The configuration of the connection to the database.</param>
    public AppDbContext(IConfiguration configuration){
        this.configuration = configuration;
    }

    /// <summary>
    /// Configures the database context.
    /// </summary>
    /// <param name="optionsBuilder">The DbContextOptionsBuilder.</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultDocker"));
    }

}
#pragma warning restore CS1591