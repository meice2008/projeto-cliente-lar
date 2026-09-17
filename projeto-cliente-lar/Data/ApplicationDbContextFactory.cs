using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace projeto_cliente_lar.Data
{
    // Usado pelo EF Core tools em design-time (migrations)
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            // string de conexão padrão para desenvolvimento / Docker
            var connectionString = "Host=localhost;Port=5432;Database=projeto_cliente;Username=postgres;Password=postgres";
            builder.UseNpgsql(connectionString);
            return new ApplicationDbContext(builder.Options);
        }
    }
}
