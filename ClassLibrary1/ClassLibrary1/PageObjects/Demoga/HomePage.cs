using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumAutomation.PageObjects.Demoga
{
    public class HomePage
    {
        IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public FormsPage NavigateToForms(string formsUrl)
        {
            this.driver.Navigate().GoToUrl(formsUrl);           
            return new FormsPage(driver);
        }
    }
}
