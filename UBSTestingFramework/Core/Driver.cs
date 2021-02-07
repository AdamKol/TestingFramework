using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;

namespace UBSTestingFramework.Core
{
    public class Driver
    {
        public IWebDriver Instance { get; private set; }

        public Driver()
        {
            Instance = Create();
        }

        private IWebDriver Create()
        {
            string chromeDriverDirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Core");

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            options.AddArgument("disable-extensions");
            options.AddArgument("disable-infobars");

            ChromeDriver driver = new ChromeDriver(chromeDriverDirectory, options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            return driver;
        }
    }
}