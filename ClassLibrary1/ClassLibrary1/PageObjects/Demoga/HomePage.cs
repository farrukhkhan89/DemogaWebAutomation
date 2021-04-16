using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        [FindsBy(How = How.LinkText, Using = "TheTechie AutomationLabs")]
        public IWebElement ChannelNameLinkText { get; set; }

        const string formsUrl = "https://demoqa.com/forms/";

        //public ChannelPage NavigateToChannel()
        //{
        //    ChannelNameLinkText.Click();
        //    return new ChannelPage(driver);
        //}

        public FormsPage NavigateToForms()
        {
            this.driver.Navigate().GoToUrl(formsUrl);
            return new FormsPage(driver);
        }
    }
}
