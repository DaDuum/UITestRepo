using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Solution.NUnit.Tests
{
    [TestFixture]
    class TestingCases : AutomationCore
    {
        [Test]
        public void ClickLogin()
        {
            Browsers.getDriver.Navigate().GoToUrl("https://is.paneurouni.com/?lang=sk");
            Browsers.getDriver.FindElement(By.LinkText("Prihlásenie do osobnej administratívy UIS")).Click();
        }
        [Test]
        public void Test_ValidationTitleContainIS()
        {
            Browsers.getDriver.Navigate().GoToUrl("https://is.paneurouni.com/?lang=sk");
            Assert.IsTrue(Browsers.Title.Contains("Univerzitný informačný systém"));
        }
        [Test]
        public void Test_ValidationTitleDoesNotContainIS()
        {
            Assert.IsFalse(Browsers.Title.Contains("Br4ti5l4v5kA p14vareň"));
        }

        // TODO 
        public void ContactUsTestflow()
        {
            Pages.contactUs.GoTo();
            Assert.IsTrue(Pages.contactUs.IsAt());
            Pages.contactUs.SendYourName("testUserName");
            Pages.contactUs.SendYourEmail("testEmail@email.com");
            Pages.contactUs.SendYourSubject("testSubject");
            Pages.contactUs.SendYourMessage("testMessage");
            Pages.contactUs.AcceptSubmit();
            Pages.contactUs.ValidateMessage();
        }

        //TODO 
        public void ContactUsTestFlowFromCSV()
        {
            Pages.contactUs.GoTo();
            Assert.IsTrue(Pages.contactUs.IsAt());
            Pages.contactUs.FilldatafromCsv();
        }

        [Test]
        public void FillForm()
        {
            Pages.registrationForm.GoTo();
            Pages.registrationForm.FilldatafromCsv();

        }
        [Test]
        public void Test_InvalidLogin()
        {
            ClickLogin();
            //IWebElement link = Browsers.getDriver.FindElement(By.PartialLinkText("Prihlásenie do osobnej administratívy UIS"));
            //link.Click();
            Browsers.getDriver.FindElement(By.Id("credential_0")).SendKeys("dummyUser");
            Browsers.getDriver.FindElement(By.Id("credential_1")).SendKeys("dummyPassword");
            Browsers.getDriver.FindElement(By.Id("login-btn")).Submit();
            System.Threading.Thread.Sleep(2000);
            IWebElement errorMessage = Browsers.getDriver.FindElement(By.Id("error_message"));

            Assert.IsNotNull(errorMessage);

        }
        [Test]
        public void Test_ValidLogin()
        {
            ClickLogin();
            Browsers.getDriver.FindElement(By.Id("credential_0")).SendKeys(ConfigurationManager.AppSettings["user"]);
            Browsers.getDriver.FindElement(By.Id("credential_1")).SendKeys(ConfigurationManager.AppSettings["password"]);
            Browsers.getDriver.FindElement(By.Id("login-btn")).Submit();
            System.Threading.Thread.Sleep(2000);

            bool isPresent = Browsers.getDriver.FindElements(By.Id("error_message")).Count > 0;

            Assert.AreEqual(false, isPresent);
        }

    }
}
