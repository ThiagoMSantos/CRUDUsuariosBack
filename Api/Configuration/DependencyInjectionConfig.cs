using Microsoft.Extensions.DependencyInjection;

using Business.Notificacoes;
using Business.Interfaces.Repositories.Commands;
using Business.Interfaces.Repositories.Queries;
using Business.Interfaces.Services;
using Business.Interfaces;
using Business.Services;
using Data.Context;
using Data.Repositories.Commands;
using Data.Repositories.Queries;

namespace Api.Configuration
{
    public class DependencyInjectionConfig
    {
        public static void ResolveDependencies(IServiceCollection services)
        {
            RegisterContext(services);
            RegisterRepository(services);
            RegisterNotificador(services);
            RegisterServices(services);
        }

        private static void RegisterContext(IServiceCollection services)
        {
            services.AddScoped<ConfitecContext>();
        }

        private static void RegisterRepository(IServiceCollection services)
        {
            services.AddScoped<IUsuarioCommandRepository, UsuarioCommandRepository>();
            services.AddScoped<IUsuarioQueryRepository, UsuarioQueryRepository>();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
        }


        private static void RegisterNotificador(IServiceCollection services)
        {
            services.AddScoped<INotificador, Notificador>();
        }


    }
}