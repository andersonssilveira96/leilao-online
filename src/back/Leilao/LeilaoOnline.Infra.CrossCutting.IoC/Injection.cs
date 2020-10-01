using LeilaoOnline.Application.Services;
using LeilaoOnline.Application.Interfaces;
using LeilaoOnline.Domain.Interfaces.Repository;
using LeilaoOnline.Domain.Interfaces.Services;
using LeilaoOnline.Domain.Services;
using LeilaoOnline.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using LeilaoOnline.Infra.Data.Interfaces;
using LeilaoOnline.Infra.Data.UoW;

namespace LeilaoOnline.Infra.CrossCutting.IoC
{
    public class Injection
    {
        public static void Inject(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();     

            services.AddScoped<ILeilaoAppService, LeilaoAppService>();
            services.AddScoped<ILeilaoService, LeilaoService>();
            services.AddScoped<ILeilaoRepository, LeilaoRepository>();        
        }
    }
}
