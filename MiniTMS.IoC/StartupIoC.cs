using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiniTMS.Dados.Contextos;
using MiniTMS.Dados.Repositorios;
using MiniTMS.Dominio._Base;
using MiniTMS.Dominio.Cliente;
using MiniTMS.Dominio.Destinatario;

namespace MiniTMS.IoC
{
    public class StartupIoC
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepositorio<>), typeof(RepositorioBase<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<IDestinatarioRepositorio, DestinatarioRepositorio>();
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration["ConnectionString"])
            .UseSnakeCaseNamingConvention());
            services.AddOptions();
        }
    }
}