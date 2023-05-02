using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Kisiler> Kisiler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyProject;Integrated Security=True;");
        }
    }
}
