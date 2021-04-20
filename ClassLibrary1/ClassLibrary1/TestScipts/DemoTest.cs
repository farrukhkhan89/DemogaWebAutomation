using NUnit.Framework;
using SeleniumAutomation.BaseClass;
using SeleniumAutomation.PageObjectModel;
using SeleniumAutomation.PageObjects.Demoga;
using System;

namespace SeleniumAutomation.TestScipts
{
    [TestFixture]
    public class DemoTest : BaseTest
    {
        public const string formsUrl = "https://demoqa.com/forms";

        [Test]
        public void SubmitFormWithOnlyRequiredFields()
        {
            var requiredFiledObj = new RequiredFieldsModel()
            {
                FirstName = "Farrukh",
                LastName = "Khan",
                MobileNumber = "3132417761",
                Gender = "male"
            };
            
            var homePage = new HomePage(driver);
            var formsPage = homePage.NavigateToForms(formsUrl);
            var practiceForms = formsPage.ClickToToPracticeForms();

            practiceForms.SubmitPracticeForm(requiredFiledObj);

            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            Assert.AreEqual("Thanks for submitting the form", practiceForms.GetSuccessMessage());
        }

        [Test]
        public void SubmitEmptyFormsAndValidate()
        {
            var homePage = new HomePage(driver);
            var formsPage = homePage.NavigateToForms(formsUrl);
            var practiceForms = formsPage.ClickToToPracticeForms();
            practiceForms.SubmitEmptyForm();

            #region Assertions
            Assert.AreEqual(true, practiceForms.IsAttribtuePresent(practiceForms.FirstName, "required"));
            Assert.AreEqual(true, practiceForms.IsAttribtuePresent(practiceForms.LastName, "required"));
            Assert.AreEqual(true, practiceForms.IsAttribtuePresent(practiceForms.MobileNumber, "required"));
            Assert.AreEqual(true, practiceForms.IsAttribtuePresent(practiceForms.Gender, "required"));
            #endregion

        }
    }
}
