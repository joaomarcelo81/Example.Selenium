using DesafioTecnicoArtycs.Application;
using DesafioTecnicoArtycs.Domain.Entities;
using DesafioTecnicoArtycs.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioTecnicoArtycs.CrossCutting.IoC
{
    public static class IoCExtensions
    {
        public static IServiceCollection AddSharedServices(this IServiceCollection services)
        {
            //  services.RegisterAutoMapper();
            services.RegisterServices();

            return services;
        }


        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<ICursoService, CursoService>();
         

            return services;
        }

        //public static IServiceCollection RegisterAutoMapper(this IServiceCollection services)
        ////{
        ////    services.AddAutoMapper(typeof(CeATalkMapper));

        ////    return services;
        ////}

    }
}