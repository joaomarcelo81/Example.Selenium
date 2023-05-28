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
            //services.AddTransient<IAssociadoService, AssociadoService>();
            //services.AddTransient<IAtendimentoService, AtendimentoService>();
            //services.AddTransient<IAuditoriaService, AuditoriaService>();
            //services.AddTransient<ICheckListService, CheckListService>();
            //services.AddTransient<IFilaEsperaAtendimentoService, FilaEsperaAtendimentoService>();
            //services.AddTransient<ILoggerService, LoggerService>();
            //services.AddTransient<IMensagemService, MensagemService>();
            //services.AddTransient<INotificacaoService, NotificacaoService>();
            //services.AddTransient<IParametroService, ParametroService>();
            //services.AddTransient<IProtocoloService, ProtocoloService>();
            //services.AddTransient<ISalesForceService, SalesForceService>();
            //services.AddTransient<IUsuarioService, UsuarioService>();
            //services.AddTransient<IWhatsappService, WhatsappService>();
            //services.AddTransient<IContatoService, ContatoService>();
            //services.AddHttpClient<AtendimentoService>();

            return services;
        }

        //public static IServiceCollection RegisterAutoMapper(this IServiceCollection services)
        ////{
        ////    services.AddAutoMapper(typeof(CeATalkMapper));

        ////    return services;
        ////}

        //public static IApplicationBuilder UseDiExtension(this IApplicationBuilder app)
        //{


        //    return app;
        //}
    }
}