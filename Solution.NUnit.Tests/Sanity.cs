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
    class Sanity : AutomationCore
    {
        [Test]
        public void ClickContactUs()
        {
            //Browsers.getDriver.FindElement(By.Id("")).Click();
           Browsers.getDriver.FindElement(By.Id("menu-item-1296")).Click();
        }
    }
}
