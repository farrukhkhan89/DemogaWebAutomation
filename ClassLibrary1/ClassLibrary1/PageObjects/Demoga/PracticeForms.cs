using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomation.PageObjects.Demoga
{
    public class  PracticeForms
    {
        IWebDriver driver;
        public PracticeForms(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.CssSelector, Using = "yt-formatted-string#text.style-scope.ytd-channel-name")]
        public IWebElement ChannelName { get; set; }

        [FindsBy(How = How.Id, Using = "firstName")]
        public IWebElement FirstName { get; set; }

        [FindsBy(How = How.Id, Using = "lastName")]
        public IWebElement LastName { get; set; }

        [FindsBy(How = How.Id, Using = "gender-radio-1")]
        public IWebElement GenderMale { get; set; }

        [FindsBy(How = How.Id, Using = "submit")]
        public IWebElement SubmitButton { get; set; }

        [FindsBy(How = How.Id, Using = "userNumber")]
        public IWebElement MobileNumber { get; set; }

        [FindsBy(How = How.Id, Using = "example-modal-sizes-title-lg")]
        public IWebElement SuccessfullSubmissionMessage { get; set; }

        [FindsBy(How = How.Name, Using = "gender")]
        public IWebElement Gender { get; set; }


        public string GetSuccessMessage()
        {
            return SuccessfullSubmissionMessage.Text;
        }

        public void FillFormOnlyRequiredAndSubmit()
        {
            //FirstName.FindElement(By.Id("firstName"));
            FirstName.SendKeys("Farrukh");

            //LastName.FindElement(By.Id("firstName"));
            LastName.SendKeys("Khan");

            //IWebElement singleRadioButton = driver.FindElement(By.Id("gender-radio-1"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].checked = true;", GenderMale);

            MobileNumber.SendKeys("3132417761");
            //IWebElement submitBtn = driver.FindElement(By.Id("submit"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", SubmitButton);


            string str = SuccessfullSubmissionMessage.Text;

        }

        public void ValidateAndSubmitEmptyForm()
        {

            //FirstName.FindElement(By.Id("firstName"));
            //FirstName.SendKeys("Farrukh");

            //LastName.FindElement(By.Id("firstName"));
            //LastName.SendKeys("Khan");

            //IWebElement singleRadioButton = driver.FindElement(By.Id("gender-radio-1"));
            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].checked = true;", GenderMale);

            //MobileNumber.SendKeys("3132417761");
            //IWebElement submitBtn = driver.FindElement(By.Id("submit"));
            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", SubmitButton);

            //IWebElement gender =
            //       driver.FindElement(By.Name("gender"));
            ////string str = SuccessfullSubmissionMessage.Text;

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", SubmitButton);
        }
    }
}
