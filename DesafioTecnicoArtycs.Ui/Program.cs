using System;
using DesafioTecnicoArtycs.Domain;
using DesafioTecnicoArtycs.Ui.Util;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


//var builder = new ConfigurationBuilder()
//       .SetBasePath(Directory.GetCurrentDirectory())
//       .AddJsonFile($"appsettings.json");
//var configuration = builder.Build();



IWebDriver driver = new ChromeDriver(@"D:\\Selenium\\chromedriver");
driver.Navigate().GoToUrl("https://www.alura.com.br/");


var porId = driver.FindElement(By.XPath("//*[@id=\"header-barraBusca-form-campoBusca\"]"));

porId.SendKeys("RPA");

driver.FindElement(By.XPath("/html/body/div[2]/div/header/div/nav/div[2]/div/form/button")).Click();



var listaBuscas = driver.FindElements(By.ClassName("busca-resultado-container"));
var counter = 1;

foreach (var item in listaBuscas)
{

    try
    {

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
        else {
            curso.Professor = "Sem Professor definido.";
        }


        Console.WriteLine(curso.ToString());

        driver.Navigate().Back();

    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        driver.Navigate().Back();
        counter--;
    }
}



//driver.Navigate().Back();
//driver.Navigate().Forward();
//driver.Navigate().Refresh();
