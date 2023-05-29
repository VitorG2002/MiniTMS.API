using Microsoft.EntityFrameworkCore;
using MiniTMS.Dominio.Clientes;
using MiniTMS.Dominio.Destinatarios;
using MiniTMS.Dominio.Endereco;
using MiniTMS.Dominio.Funcionarios;
using MiniTMS.Dominio.Pedido;
using MiniTMS.Dominio.Status;

namespace MiniTMS.Dados.Contextos
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<Enderecos> Enderecos { get; set; }
        public DbSet<Destinatarios> Destinatarios { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Funcionarios> Funcionarios { get; set; }
        public DbSet<Motoristas> Motoristas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Funcionarios>().UseTptMappingStrategy();
        }

        public async Task Commit()
        {
            await SaveChangesAsync();
        }
    }
}
