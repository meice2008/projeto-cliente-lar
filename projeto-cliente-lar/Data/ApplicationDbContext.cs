using Microsoft.EntityFrameworkCore;
using projeto_cliente_lar.Entities;

namespace projeto_cliente_lar.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; } = null!;
        public DbSet<Telefone> Telefones { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.ToTable("Pessoas");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).ValueGeneratedOnAdd();
                entity.HasIndex(p => p.Cpf).IsUnique();
                entity.Property(p => p.Cpf).HasMaxLength(20);
                entity.Property(p => p.Nome).HasMaxLength(200);
                entity.Property(p => p.Ativo).HasDefaultValue(true);
            });

            modelBuilder.Entity<Telefone>(entity =>
            {
                entity.ToTable("Telefones");
                entity.HasKey(t => t.Numero);
                entity.Property(t => t.Numero).IsRequired();
                entity.Property(t => t.Tipo).IsRequired();

                // Relação opcional por padrão, mas adicionamos constraint para garantir
                // que quando Tipo == Celular então PessoaCpf NÃO seja nulo
                entity.HasOne(t => t.Pessoa)
                      .WithMany(p => p.Telefones!)
                      .HasPrincipalKey(p => p.Cpf)
                      .OnDelete(DeleteBehavior.Cascade);

            });
        }
    }
}
