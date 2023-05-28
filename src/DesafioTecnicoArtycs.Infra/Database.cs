using DesafioTecnicoArtycs.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioTecnicoArtycs.Infra.Repository.Base;
using DesafioTecnicoArtycs.Domain.Entities;
using DesafioTecnicoArtycs.Domain.Interfaces.Services;
using DesafioTecnicoArtycs.Infra.Repository;

namespace DesafioTecnicoArtycs.Infra
{
    public static class Database
    {
        public static void RegisterDatabase(this IServiceCollection services, string connectionString)
        {
            //var settings = new DatabaseSettings { ConnectionString = connectionString };
            //services.AddSingleton(settings);
            services.AddTransient<IRepository<Curso>, CursoRepository>();            
        

        }
    }
}
