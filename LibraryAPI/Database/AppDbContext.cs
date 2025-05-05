using Microsoft.EntityFrameworkCore;
using LibraryExercise.Models;

#pragma warning disable CS1591
public class AppDbContext: DbContext{

    private readonly IConfiguration configuration;
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Loan> Loans { get; set; }

    public AppDbContext(IConfiguration configuration){
        this.configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultDocker"));
    }

}
#pragma warning restore CS1591