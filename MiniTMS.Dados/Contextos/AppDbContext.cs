using Microsoft.EntityFrameworkCore;
using MiniTMS.Dominio.Cliente;
using MiniTMS.Dominio.Destinatario;
using MiniTMS.Dominio.Endereco;
using MiniTMS.Dominio.Funcionario;
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
        public DbSet<Statuses> Status { get; set; }
        public DbSet<Funcionarios> Funcionarios { get; set; }
        public DbSet<Motoristas> Motoristas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Funcionarios>().UseTptMappingStrategy();
            modelBuilder.Entity<Pedidos>()
                        .HasOne(p => p.Destinatario)
                        .WithMany(d => d.Pedidos)
                        .HasForeignKey(p => p.DestinatariosId)
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Pedidos>()
                        .HasOne(p => p.Cliente)
                        .WithMany(c => c.Pedidos)
                        .HasForeignKey(p => p.ClientesId)
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Pedidos>()
                        .HasOne(p => p.Motoristas)
                        .WithMany(m => m.Pedidos)
                        .HasForeignKey(p => p.MotoristasId)
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Pedidos>()
                        .HasOne(p => p.Status)
                        .WithMany(s => s.Pedidos)
                        .HasForeignKey(p => p.StatusId)
                        .OnDelete(DeleteBehavior.NoAction);

        }

        public async Task Commit()
        {
            await SaveChangesAsync();
        }
    }
}
