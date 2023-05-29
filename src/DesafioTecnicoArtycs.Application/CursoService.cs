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
using DesafioTecnicoArtycs.Domain.Dto.Request;
using DesafioTecnicoArtycs.Domain.Dto.Reponse;
using AutoMapper;

namespace DesafioTecnicoArtycs.Application
{
    public class CursoService : ICursoService
    {
        private readonly IRepository<Curso> _cursoRepository;

        private readonly ILogger<CursoService> _logger;

        private readonly Settings _settings;

        private readonly IMapper _mapper;

        public CursoService(IMapper mapper, ILogger<CursoService> logger, Settings settings, IRepository<Curso> cursoRepository)
        {
            _cursoRepository = cursoRepository;
            _logger = logger;
            _settings = settings;
            _mapper = mapper;
        }
        public async Task<int> Adicionar(CursoRequest cursoRequest)
        {
            _logger.LogInformation($"Adiciondo um curso", cursoRequest);
            try
            {
                var curso = _mapper.Map<Curso>(cursoRequest);
                curso = await _cursoRepository.Add(curso);
                return curso.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"ao adicionar um curso", cursoRequest);
                throw;
            }
        }

        public async Task<int> Atualizar(int id, CursoRequest cursoRequest)
        {

            _logger.LogInformation($"atualizando um curso", cursoRequest);
            try
            {
                var cursoNovo = _mapper.Map<Curso>(cursoRequest);
                cursoNovo.Id = id;
                var curso = await _cursoRepository.Update(cursoNovo);
                return id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao atualizar um curso", cursoRequest);
                throw;
            }
        }
        public async Task<CursoResponse> ObterCurso(int id)
        {
            _logger.LogInformation($"Buscar um curso pelo id");
            try
            {
                var curso = await _cursoRepository.Get(id);
                var cursoResponse = _mapper.Map<CursoResponse>(curso);
                return cursoResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao buscar o curso");
                throw;
            }
        }

        public async Task<int> RemoverCurso(int id)
        {
            _logger.LogInformation($"Remover um curso pelo id");
            try
            {
                var curso = await _cursoRepository.Delete(id);
                var cursoResponse = _mapper.Map<CursoResponse>(curso);
                return (cursoResponse != null) ? cursoResponse.Id : 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao remover o curso");
                throw;
            }
        }
        
        public async Task<IList<CursoResponse>> listaCursos()
        {    
            _logger.LogInformation($"listando todos os cursos");
            try
            {
                var lista = await _cursoRepository.GetAll();
                return lista.ConvertAll(c=> _mapper.Map<CursoResponse>(c));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao listar todos os cursos");
                throw;
            }         
        }
        public async Task BuscarDadosAlura(string busca)
        {         

            _logger.LogInformation($"Buscando dados na lista");

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
                        await Adicionar(new CursoRequest()
                        {
                            CargaHoraria = curso.CargaHoraria,
                            Descricao = curso.Descricao,
                            Professor = curso.Professor,
                            Titulo = curso.Titulo
                        });
                        _logger.LogInformation($"Adicionou Curso: {curso}");
                    }
                    else
                    {
                        _logger.LogWarning($"Não foi encontrado informações da: {itemBuscado} no {counter}º item");
                    }

                    driver.Navigate().Back();

                    Thread.Sleep(2000);
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex
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