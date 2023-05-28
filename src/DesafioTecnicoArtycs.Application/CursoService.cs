using DesafioTecnicoArtycs.Domain.Entities;
using DesafioTecnicoArtycs.Domain;
using DesafioTecnicoArtycs.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using DesafioTecnicoArtycs.Domain.Util;
using DesafioTecnicoArtycs.Domain.Interfaces.Repositories;
using DesafioTecnicoArtycs.Infra.Migrations;
using Microsoft.Extensions.Options;
using OpenQA.Selenium.Interactions;

namespace DesafioTecnicoArtycs.Application
{
    public class CursoService : ICursoService
    {
        private readonly IRepository<Curso> _cursoRepository;

        private readonly ILogger<CursoService> _logger;

        private readonly Settings _settings;

        public CursoService(ILogger<CursoService> logger, Settings settings, IRepository<Curso> cursoRepository)
        {
            _cursoRepository = cursoRepository;
            _logger = logger;
            _settings = settings;
        }

        public async Task<Curso> Adicionar(Curso curso)
        {
            EventId eventId = new EventId();

            _logger.LogInformation(eventId, $"Adiciondo um curso", curso);
            try
            {
                return await _cursoRepository.Add(curso);
            }
            catch (Exception ex)
            {
                _logger.LogError(eventId, ex, $"ao adicionar um curso", curso);
                throw;
            }
        }

        public async Task<Curso> Atualizar(Curso curso)
        {
            EventId eventId = new EventId();

            _logger.LogInformation(eventId, $"atualizando um curso", curso);
            try
            {
                return await _cursoRepository.Update(curso);
            }
            catch (Exception ex)
            {
                _logger.LogError(eventId, ex, $"Erro ao atualizar um curso", curso);
                throw;
            }
         
        }


        public async Task<IList<Curso>> listaCursos()
        {
            EventId eventId = new EventId();

            _logger.LogInformation(eventId, $"listando todos os cursos");
            try
            {
                return await _cursoRepository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(eventId, ex, $"Erro ao listar todos os cursos");
                throw;
            }
         
        }



        public async Task BuscarDadosAlura(string busca)
        {

            EventId eventId = new EventId();

            _logger.LogInformation(eventId, $"Buscando dados na lista");

            ChromeOptions chromeOptions = new ChromeOptions();

            chromeOptions.AcceptInsecureCertificates = true;



            IWebDriver driver = new ChromeDriver(_settings.CaminhoWebDriverChrome, chromeOptions);

            AbrirPortal(driver, busca);

            var listaBuscas = driver.FindElements(By.ClassName("busca-resultado-container"));
            var counter = 1;

            foreach (var item in listaBuscas)
            {
                var curso = new DadosCurso();
                try
                {
                    var itemBuscado = driver.FindElement(By.XPath($"/html/body/div[2]/div[2]/section/ul/li[{counter}]/a/div/h4")).Text;

                    driver.FindElement(By.XPath($"//*[@id=\"busca-resultados\"]/ul/li[{counter}]/a")).Click();
                    counter++;


                    if (ValidarElementos.IsElementPresent(driver, By.ClassName("curso-banner-course-title")) != "")
                    {
                        curso.Titulo = ValidarElementos.IsElementPresent(driver, By.ClassName("curso-banner-course-title"));
                    }
                    if (ValidarElementos.IsElementPresent(driver, By.ClassName("formacao-headline-titulo")) != "")
                    {
                        curso.Titulo = ValidarElementos.IsElementPresent(driver, By.ClassName("formacao-headline-titulo"));
                    }
                    if (ValidarElementos.IsElementPresent(driver, By.ClassName("courseInfo-card-wrapper-infos")) != "")
                    {
                        curso.CargaHoraria = ValidarElementos.IsElementPresent(driver, By.ClassName("courseInfo-card-wrapper-infos"));
                    }
                    if (ValidarElementos.IsElementPresent(driver, By.ClassName("formacao__info-destaque")) != "")
                    {
                        curso.CargaHoraria = ValidarElementos.IsElementPresent(driver, By.ClassName("formacao__info-destaque"));
                    }

                    if (ValidarElementos.IsElementPresent(driver, By.ClassName("course-list")) != "")
                    {
                        curso.Descricao = ValidarElementos.IsElementPresent(driver, By.ClassName("course-list"));
                    }
                    if (ValidarElementos.IsElementPresent(driver, By.ClassName("formacao-descricao-texto")) != "")
                    {
                        curso.Descricao = ValidarElementos.IsElementPresent(driver, By.ClassName("formacao-descricao-texto"));
                    }

                    if (ValidarElementos.IsElementPresent(driver, By.ClassName("instructor-title--name")) != "")
                    {
                        curso.Professor = driver.FindElement(By.ClassName("instructor-title--name")).Text;
                    }
                    else
                    {
                        curso.Professor = "Sem Professor definido.";
                    }



                    if (curso.Titulo != null && curso.Titulo != "")
                    {
                        await Adicionar(new Curso()
                        {
                            CargaHoraria = curso.CargaHoraria,
                            Descricao = curso.Descricao,
                            Professor = curso.Professor,
                            Titulo = curso.Titulo
                        });
                        _logger.LogInformation(eventId, $"Adicionou Curso: {curso}");
                    }
                    else
                    {
                        _logger.LogWarning(eventId, $"Não foi encontrado informações da: {itemBuscado} no {counter}º item");
                    }


                    //Logger.INFO(curso.ToString());

                    driver.Navigate().Back();
                    Thread.Sleep(2000);

                }
                catch (Exception ex)
                {
                    _logger.LogWarning(eventId, ex
                        , @"Ocorreu um erro ao buscar os dados do site na busca {counter}º ", curso);
                    if (ex.Message.IndexOf("busca-resultados") > 0)
                    {
                        AbrirPortal(driver, busca);
                    }
                    driver.Navigate().Back();
                    if (counter > 0)
                        counter--;
                }
            }

            driver.Quit();

        }

        private static void AbrirPortal(IWebDriver driver, string busca)
        {       

            driver.Navigate().GoToUrl("https://www.alura.com.br/");
            Thread.Sleep(1000);

            var porId = driver.FindElement(By.XPath("//*[@id=\"header-barraBusca-form-campoBusca\"]"));

            porId.SendKeys(busca);

            driver.FindElement(By.XPath("/html/body/div[2]/div/header/div/nav/div[2]/div/form/button")).Click();
            Thread.Sleep(1000);
            Logger.INFO($"Buscando o {busca}");
        }
    }
}