using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomation.PageObjects.Demoga
{
    public class PracticeForms
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

        [FindsBy(How = How.Id, Using = "gender-radio-2")]
        public IWebElement GenderFemale { get; set; }

        [FindsBy(How = How.Id, Using = "gender-radio-3")]
        public IWebElement GenderOther { get; set; }

        [FindsBy(How = How.Id, Using = "submit")]
        public IWebElement SubmitButton { get; set; }

        [FindsBy(How = How.Id, Using = "userNumber")]
        public IWebElement MobileNumber { get; set; }

        [FindsBy(How = How.Id, Using = "example-modal-sizes-title-lg")]
        public IWebElement SuccessfullSubmissionMessage { get; set; }

        [FindsBy(How = How.Name, Using = "gender")]
        public IWebElement Gender { get; set; }

        public void SetFirstName(string firstName)
        {
            FirstName.Clear();
            FirstName.SendKeys(firstName);
        }
        public void SetLastName(string lastName)
        {
            LastName.Clear();
            LastName.SendKeys(lastName);
        }

        public void SetMobileNumber(string mobileNumber)
        {
            MobileNumber.Clear();
            MobileNumber.SendKeys(mobileNumber);
        }
        public void SetGender(string gender)
        {
            //Gender.Clear();
            switch (gender) 
            {
                case "male":
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].checked = true;", GenderMale);
                    break;

                case "female":
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].checked = true;", GenderFemale);
                    break;

                default:
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].checked = true;", GenderOther);
                    break;
            }

           
            Gender.SendKeys(gender);
        }
        public string GetSuccessMessage()
        {
            return SuccessfullSubmissionMessage.Text;
        }

        public void SubmitPracticeForm()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", SubmitButton);
        }

        public void ValidateAndSubmitEmptyForm()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", SubmitButton);
        }
    }
}
