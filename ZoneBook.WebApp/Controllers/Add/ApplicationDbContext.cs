using Microsoft.EntityFrameworkCore;
using ZoneBook.WebApp.Models;

namespace ZoneBook.WebApp.Controllers.Add
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
    }
}
