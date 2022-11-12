using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace SeleniumTest
{
    internal class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            try
            {
                Console.Write("test case started ");
                IWebDriver driver = new ChromeDriver("C:\\Ve\\chrome"); ;
                driver.Navigate().GoToUrl("https://www.google.com/");
                Thread.Sleep(2000);

                IWebElement inputField = driver.FindElement(By.Name("q"));
                inputField.SendKeys("Hello World");
                Thread.Sleep(2000);

                IWebElement searchButton = driver.FindElement(By.Name("btnK"));
                searchButton.Click();
                Thread.Sleep(3000);

                var webElement = driver.FindElement(By.CssSelector(".LC20lb.MBeuO.DKV0Md"));
                log.Info(webElement.Text);
                /*for (int i = 0; i < webElements.Count; i++)
                    Console.WriteLine(webElements[i].Text);*/


                driver.Close();
                log.Info("test case ended ");

            }
            catch(Exception e)
            {
                log.Error("Driver couldn't be run " + e.Message);
            }


        }
    }
}
