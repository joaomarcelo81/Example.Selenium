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

namespace DesafioTecnicoArtycs.Application
{
    public class CursoService : ICursoService
    {
        private readonly IRepository<Curso> _cursoRepository;

        public CursoService(IRepository<Curso> cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task<Curso> Adicionar(Curso curso)
        {
            return await _cursoRepository.Add(curso);
        }



        public async Task<IList<Curso>> listaCursos()
        {
            return await _cursoRepository.GetAll();
        }



        public async void BuscarDadosAlura()
        {
            IWebDriver driver = new ChromeDriver(@"D:\\Selenium\\chromedriver");
            driver.Navigate().GoToUrl("https://www.alura.com.br/");
            Thread.Sleep(1000);

            var porId = driver.FindElement(By.XPath("//*[@id=\"header-barraBusca-form-campoBusca\"]"));

            porId.SendKeys("RPA");

            driver.FindElement(By.XPath("/html/body/div[2]/div/header/div/nav/div[2]/div/form/button")).Click();
            Thread.Sleep(1000);
            Logger.INFO("Buscando o RPA");

            var listaBuscas = driver.FindElements(By.ClassName("busca-resultado-container"));
            var counter = 1;

            foreach (var item in listaBuscas)
            {
                Logger.INFO("Buscando dados na lista");



                try
                {
                    // Logger.DEBUG(item?.Text);
                    var curso = new DadosCurso();

                    //"//*[@id=\"busca-resultados\"]/ul/li[2]/a"
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

                    //await myClass.Adicionar(new Curso()
                    //{
                    //    Id = 1,
                    //    DataCadastro = DateTime.Now,
                    //    CargaHoraria= "8h",
                    //    Descricao = "",
                    //    Professor = "",
                    //    Titulo = "teste"
                    //});

                    if (curso.Titulo != null && curso.Titulo != "")
                    {
                        await Adicionar(new Curso()
                        {
                            DataCadastro = DateTime.Now,
                            CargaHoraria = curso.CargaHoraria,
                            Descricao = curso.Descricao,
                            Professor = curso.Professor,
                            Titulo = curso.Titulo
                        });
                    }


                    Logger.INFO(curso.ToString());

                    driver.Navigate().Back();
                    Thread.Sleep(1000);

                }
                catch (Exception ex)
                {
                    Logger.ERROR(ex.Message);
                    driver.Navigate().Back();
                    counter--;
                }
            }
        }

    }
}