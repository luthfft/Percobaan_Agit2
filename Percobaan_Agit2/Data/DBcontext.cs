using Microsoft.EntityFrameworkCore;
using Percobaan_Agit2.Models;

namespace Percobaan_Agit2.Data
{
    public class DBcontext : DbContext
    {
        public DBcontext(DbContextOptions<DBcontext> options)
            : base(options)
        {
        }

        public DbSet<Salesorder> ItemGroupRevenue { get; set; }
        public DbSet<Salesorder> CountryRevenue { get; set; }
    }
}
