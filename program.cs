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
        options.AddArgument("--disable-gpu");
        options.AddArgument("--ignore-certificate-errors");
        options.AddArgument("--ignore-ssl-errors");
        var driver = new ChromeDriver();


        driver.Navigate().GoToUrl("https://login.yahoo.com");

        var username = driver.FindElement(By.Name("username"));
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

        var table = driver.FindElement(By.CssSelector("#main > section > section._64nqq > div.gIc8M > table"));
        foreach (var row in table.FindElements(By.TagName("tr")))
        {
                foreach (var cell in row.FindElements(By.TagName("td")))
                {
                Console.WriteLine(cell.Text);
                }

        }
    }
}