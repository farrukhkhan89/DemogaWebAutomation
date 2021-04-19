using NUnit.Framework;
using SeleniumAutomation.BaseClass;
using SeleniumAutomation.PageObjects.Demoga;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomation.TestScipts
{
    [TestFixture]
    public class DemoTest:BaseTest
    {
        public const string formsUrl = "https://demoqa.com/forms";

         [Test]
        public void Check_SubmitFormWithOnlyRequiredFields()
        {
            var homePage = new HomePage(driver);
            var formsPage = homePage.NavigateToForms(formsUrl);
            var practiceForms = formsPage.ClickToToPracticeForms();

            practiceForms.SetFirstName("Farrukh");
            practiceForms.SetLastName("Khan");
            practiceForms.SetMobileNumber("3132417761");
            practiceForms.SetGender("male");

            practiceForms.SubmitPracticeForm();

            Assert.AreEqual("Thanks for submitting the form", practiceForms.GetSuccessMessage());
        }

        [Test]
        public void Check_SubmitEmptyFormsAndValidate()
        {
            bool isGenderSelected = false;
            var homePage = new HomePage(driver);
            var formsPage = homePage.NavigateToForms(formsUrl);
            var practiceForms = formsPage.ClickToToPracticeForms();

            practiceForms.ValidateAndSubmitEmptyForm();

            Assert.AreEqual(true, practiceForms.IsAttribtuePresent(practiceForms.FirstName, "required"));
            Assert.AreEqual(true, practiceForms.IsAttribtuePresent(practiceForms.LastName, "required"));
            Assert.AreEqual(true, practiceForms.IsAttribtuePresent(practiceForms.MobileNumber, "required"));

            Assert.AreEqual(true, practiceForms.IsAttribtuePresent(practiceForms.Gender, "required"));

        }
    }
}
