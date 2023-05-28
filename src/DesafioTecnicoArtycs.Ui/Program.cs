using System;
using System.Reflection;
using DesafioTecnicoArtycs.Application;
using DesafioTecnicoArtycs.Domain;
using DesafioTecnicoArtycs.Domain.Entities;
using DesafioTecnicoArtycs.Domain.Interfaces.Repositories;
using DesafioTecnicoArtycs.Domain.Interfaces.Services;
using DesafioTecnicoArtycs.Infra;
using DesafioTecnicoArtycs.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

// See https://aka.ms/new-console-template for more information




IHost host = Host.CreateDefaultBuilder(args)
.ConfigureAppConfiguration((config) =>
{
    config.AddJsonFile("appsettings.json");
    config.AddEnvironmentVariables();
    config.Build();
})
.ConfigureServices((context, services) =>
{

    //string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "sqliteSample.db");

    //var embeddedResourceDb = Assembly.GetExecutingAssembly().GetManifestResourceNames().First(s => s.Contains("DesafioTecnicoArtycsDB.db"));
    //var embeddedResourceDbStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(embeddedResourceDb);

    //// Load tiles data from bundle to phone cache on first launch
    //var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "DesafioTecnicoArtycsDB.db");

    var cns = "Data Source=.\\DesafioTecnicoArtycsDB.db";//context.Configuration.GetConnectionString("DesafioTecnicoArtycsConnection");
    services
    .AddDbContext<DataContext>(options => options.UseSqlite(cns)
    .EnableDetailedErrors(true))
    //.AddHostedService<DiBerieBotMain>();
    ;

    services.AddTransient<IRepository<Curso>, CursoRepository>();
    services.AddTransient<ICursoService, CursoService>();


})
.Build();

var cursoService = host.Services.GetService<ICursoService>();
cursoService.BuscarDadosAlura("RPA");
