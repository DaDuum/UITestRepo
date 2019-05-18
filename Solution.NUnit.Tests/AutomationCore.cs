// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;

namespace Solution.NUnit.Tests
{
    [TestFixture]
    public class AutomationCore
    {
        IWebDriver driver;

        // Our Core Test Automation class
        [SetUp]
        public void startTest() // This method will be fired at the start of the test
        {
            //driver = new ChromeDriver();
            //driver.Url = "https://blog.testproject.io/wp-login.php";
            driver = Browsers.Init();

        }
        [TearDown]
        public void endTest() // This method will be fired at the end of the test
        {
            Browsers.Close();
        }

        [Test]
        public void Menu_Item_Test()
        {
            //data - title
            //driver.FindElement(By.Id("user_login")).SendKeys("Something usefull");
            driver.FindElement(By.Id("menu-item-117")).Click();
            System.Threading.Thread.Sleep(1000);
        }
    }
}
