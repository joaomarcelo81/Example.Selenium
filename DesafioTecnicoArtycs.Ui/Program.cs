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
cursoService.BuscarDadosAlura();

//var cursoService = host.Services.GetService<ICursoService>();


//IWebDriver driver = new ChromeDriver(@"D:\\Selenium\\chromedriver");
//driver.Navigate().GoToUrl("https://www.alura.com.br/");
//Thread.Sleep(1000);

//var porId = driver.FindElement(By.XPath("//*[@id=\"header-barraBusca-form-campoBusca\"]"));

//porId.SendKeys("RPA");

//driver.FindElement(By.XPath("/html/body/div[2]/div/header/div/nav/div[2]/div/form/button")).Click();
//Thread.Sleep(1000);
//Logger.INFO("Buscando o RPA");

//var listaBuscas = driver.FindElements(By.ClassName("busca-resultado-container"));
//var counter = 1;

//foreach (var item in listaBuscas)
//{
//    Logger.INFO("Buscando dados na lista");



//    try
//    {
//       // Logger.DEBUG(item?.Text);
//        var curso = new DadosCurso();

//        //"//*[@id=\"busca-resultados\"]/ul/li[2]/a"
//        driver.FindElement(By.XPath($"//*[@id=\"busca-resultados\"]/ul/li[{counter}]/a")).Click();
//        counter++;

//        if (ValidarElementos.IsElementPresent(driver, By.ClassName("curso-banner-course-title")) != "")
//        {
//            curso.Titulo = ValidarElementos.IsElementPresent(driver, By.ClassName("curso-banner-course-title"));
//        }
//        if (ValidarElementos.IsElementPresent(driver, By.ClassName("formacao-headline-titulo")) != "")
//        {
//            curso.Titulo = ValidarElementos.IsElementPresent(driver, By.ClassName("formacao-headline-titulo"));
//        }
//        if (ValidarElementos.IsElementPresent(driver, By.ClassName("courseInfo-card-wrapper-infos")) != "")
//        {
//            curso.CargaHoraria = ValidarElementos.IsElementPresent(driver, By.ClassName("courseInfo-card-wrapper-infos"));
//        }
//        if (ValidarElementos.IsElementPresent(driver, By.ClassName("formacao__info-destaque")) != "")
//        {
//            curso.CargaHoraria = ValidarElementos.IsElementPresent(driver, By.ClassName("formacao__info-destaque"));
//        }

//        if (ValidarElementos.IsElementPresent(driver, By.ClassName("course-list")) != "")
//        {
//            curso.Descricao = ValidarElementos.IsElementPresent(driver, By.ClassName("course-list"));
//        }
//        if (ValidarElementos.IsElementPresent(driver, By.ClassName("formacao-descricao-texto")) != "")
//        {
//            curso.Descricao = ValidarElementos.IsElementPresent(driver, By.ClassName("formacao-descricao-texto"));
//        }

//        if (ValidarElementos.IsElementPresent(driver, By.ClassName("instructor-title--name")) != "")
//        {
//            curso.Professor = driver.FindElement(By.ClassName("instructor-title--name")).Text;
//        }
//        else {
//            curso.Professor = "Sem Professor definido.";
//        }

//        //await myClass.Adicionar(new Curso()
//        //{
//        //    Id = 1,
//        //    DataCadastro = DateTime.Now,
//        //    CargaHoraria= "8h",
//        //    Descricao = "",
//        //    Professor = "",
//        //    Titulo = "teste"
//        //});

//        if (curso.Titulo != null && curso.Titulo != "")
//        {
//            await cursoService.Adicionar(new Curso()
//            {
//                DataCadastro = DateTime.Now,
//                CargaHoraria = curso.CargaHoraria,
//                Descricao = curso.Descricao,
//                Professor = curso.Professor,
//                Titulo = curso.Titulo
//            });
//        }


//        Logger.INFO(curso.ToString());

//        driver.Navigate().Back();
//        Thread.Sleep(1000);

//    }
//    catch (Exception ex)
//    {
//        Logger.ERROR(ex.Message);
//        driver.Navigate().Back();
//        counter--;
//    }
//}



//driver.Navigate().Back();
//driver.Navigate().Forward();
//driver.Navigate().Refresh();
