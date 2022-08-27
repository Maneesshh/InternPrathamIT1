using InternApp.Models;
using Microsoft.EntityFrameworkCore;

namespace InternApp.Data
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options)
        {

        }
        public DbSet<Address> Addresses { get; set; }

    }
}
