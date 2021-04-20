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
        [FindsBy(How = How.XPath, Using = "//div[@class='element-list collapse show']//*[name()='svg'][@stroke = 'currentColor']")]
        public IWebElement PracticeButton { get; set; }
        
        public PracticeForms ClickToToPracticeForms()
        {
            PracticeButton.Click();
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            return new PracticeForms(driver);
        }
    }
}
