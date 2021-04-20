using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumAutomation.BaseClass
{
    public class BaseTest
    {
        public IWebDriver driver;


        [SetUp]
        public void Open()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://demoqa.com/";
        }

        [TearDown]
        public void Close()
        {
            driver.Quit();
        }
    }
}
