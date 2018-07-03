using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

class Scraper
{
    static void Main(string[] args)
    {
        // Create a new instance of the Chrome driver.
            var options = new ChromeOptions();
            options.AddArguments("--disable-gpu");
            var driver = new ChromeDriver();
        
            driver.Navigate().GoToUrl("https://login.yahoo.com");

            var username =  driver.FindElement(By.Name("username"));
            username.SendKeys("seanscrap25");
            username.Submit();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(d => d.FindElement(By.Id("login-passwd")));

            var password = driver.FindElement(By.Id("login-passwd"));
            password.SendKeys("Potatosalad33");
            password.SendKeys(Keys.Enter);

            driver.Navigate().GoToUrl("https://finance.yahoo.com/portfolio/p_1/view/v1");

        wait.Until(d => d.FindElement(By.Id("__dialog")));
        var popup = driver.FindElement(By.XPath("//dialog[@id = '__dialog']/section/button"));
            popup.Click();

            var Stock1Price = driver.FindElement(By.XPath("//*[@id='main']/section/section[2]/div[2]/table/tbody/tr[1]/td[1]/span/a/title"));
            Console.WriteLine(Stock1Price);

        //List<IWebElement> elements = new List<IWebElement>();
        //elements = driver.FindElements(By.XPath("//tbody/tr")).ToList<IWebElement>();
    }
}