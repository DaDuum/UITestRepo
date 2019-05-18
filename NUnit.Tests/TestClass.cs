
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnit.Tests
{
    [TestFixture]
    
    public class TestClass 
    {
        IWebDriver driver;

        [SetUp]
        public void StartTest()
        {          
            driver = new ChromeDriver();
            driver.Url = "https://is.paneurouni.com/?lang=sk";
        }

        [TearDown]
        public void EndTest()
        {
            driver.Quit();
        }
        
        public void Test_ValidationTitleContainIS()
        {      
            Assert.IsTrue(driver.Title.Contains("Univerzitný informačný systém"));
        }
  
        public void Test_ValidationTitleDoesNotContainIS()
        {
            Assert.IsFalse(driver.Title.Contains("Bratislavska plavaren"));
        }

     
        public void Test_InvalidLogin()
        {
            IWebElement link = driver.FindElement(By.PartialLinkText("Prihlásenie do osobnej administratívy UIS"));
            link.Click();
            driver.FindElement(By.Id("credential_0")).SendKeys("unitesting");
            driver.FindElement(By.Id("credential_1")).SendKeys("unitesting");
            driver.FindElement(By.Id("login-btn")).Submit();
            System.Threading.Thread.Sleep(2000);
            IWebElement errorMessage = driver.FindElement(By.Id("error_message"));

            Assert.IsNotNull(errorMessage);
          
        }

        public void Test_ValidLogin()
        {
            IWebElement link = driver.FindElement(By.PartialLinkText("Prihlásenie do osobnej administratívy UIS"));
            link.Click();
            driver.FindElement(By.Id("credential_0")).SendKeys(new Credentials().Name);
            driver.FindElement(By.Id("credential_1")).SendKeys(new Credentials().Password);
            driver.FindElement(By.Id("login-btn")).Submit();
            System.Threading.Thread.Sleep(2000);

            bool isPresent = driver.FindElements(By.Id("error_message")).Count > 0;

            Assert.AreEqual(false, isPresent);


        }

    }
}
