using Microsoft.EntityFrameworkCore;

public class LibraryDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Patron> Patrons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Configure the connection string for your database
        //string connectionString = "Server=your-server-address;Database=your-database-name;User Id=your-username;Password=your-password;";

        optionsBuilder.UseSqlServer("Server=localhost;Database=LibraryDb;Trusted_Connection=True;User Id=root;Password=root;");
    }
}
