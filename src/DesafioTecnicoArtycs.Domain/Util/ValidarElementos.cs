using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnicoArtycs.Domain.Util
{
    public static class ValidarElementos
    {
        public static string IsElementPresent(IWebDriver driver, By by)
        {
            try
            {
                driver.FindElement(by);
                return driver.FindElement(by).Text;
            }
            catch (NoSuchElementException)
            {
                return string.Empty;
            }
        }
    }
}
