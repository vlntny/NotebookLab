using ContactListLab.Model;
using Microsoft.EntityFrameworkCore;

namespace ContactListLab.AppContext;

public class MyContext: DbContext
{
    public DbSet<ContactDto> Contacts { get; set; }
    
    public MyContext(DbContextOptions<MyContext> options):base(options)
    {
        Database.EnsureCreated();
    }

    public MyContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=MyDatabase.db");
}