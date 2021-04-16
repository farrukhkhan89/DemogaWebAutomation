using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomation.PageObjects.Demoga
{
    public class FormsPage
    {
        const string practiceFormsUrl = "https://demoqa.com/automation-practice-form/";
        IWebDriver driver;
        public FormsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.CssSelector, Using = "yt-formatted-string#text.style-scope.ytd-channel-name")]
        public IWebElement ChannelName { get; set; }
        public string GetChannelName()
        {
            return ChannelName.Text;
        }

        public PracticeForms ClickToToPracticeForms()
        {
            this.driver.Navigate().GoToUrl(practiceFormsUrl);
            return new PracticeForms(driver);
        }
    }
}
