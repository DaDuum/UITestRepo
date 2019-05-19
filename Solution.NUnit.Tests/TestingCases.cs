using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
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
            Browsers.getDriver.FindElement(By.Id("menu-item-1296")).Click();
        }

        [Test]
        public void ContactUsTestflow()
        {
            Pages.contactUs.GoTo();
            Assert.IsTrue(Pages.contactUs.isAt());
            Pages.contactUs.SendYourName("Asya test");
            Pages.contactUs.SendYourEmail("TestProject@testproject.com");
            Pages.contactUs.SendYourSubject("Test");
            Pages.contactUs.SendYourMessage("Test 123");
            Pages.contactUs.AcceptSubmit();
            Pages.contactUs.ValidateMessage();
        }
        [Test]
        public void ContactUsTestFlowFromCSV()
        {
            Pages.contactUs.GoTo();
            Assert.IsTrue(Pages.contactUs.isAt());
            Pages.contactUs.filldatafromCsv();
        }

    }
}
