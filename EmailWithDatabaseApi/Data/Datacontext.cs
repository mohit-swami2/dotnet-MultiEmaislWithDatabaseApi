using EmailWithDatabaseApi.Model;
using Microsoft.EntityFrameworkCore;

namespace EmailWithDatabaseApi.Data
{
    public class Datacontext : DbContext
    {
        public Datacontext(DbContextOptions<Datacontext> options) : base(options) { }

        public DbSet<Emailbody> Emails { get; set; }
    }
}
