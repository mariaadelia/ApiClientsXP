using Microsoft.EntityFrameworkCore;
using XPTesteTecnico.Entities;

namespace XPTesteTecnico.Infra
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
