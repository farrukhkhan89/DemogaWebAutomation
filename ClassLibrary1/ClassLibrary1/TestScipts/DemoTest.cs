﻿using NUnit.Framework;
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
            var homePage = new HomePage(driver);
            var formsPage = homePage.NavigateToForms(formsUrl);
            var practiceForms = formsPage.ClickToToPracticeForms();

            practiceForms.SetFirstName("Farrukh");
            practiceForms.SetLastName("Khan");
            practiceForms.SetMobileNumber("3132417761");
            practiceForms.SetGender("male");


            Assert.True(!string.IsNullOrEmpty(practiceForms.FirstName.GetAttribute("value")), "first name is required field");
            Assert.True(!string.IsNullOrEmpty(practiceForms.LastName.GetAttribute("value")), "last name is required field");
            Assert.True(!practiceForms.Gender.Selected, "Gender is required field");

            practiceForms.ValidateAndSubmitEmptyForm();

            Assert.AreEqual("Thanks for submitting the form", practiceForms.GetSuccessMessage());
        }
    }
}
