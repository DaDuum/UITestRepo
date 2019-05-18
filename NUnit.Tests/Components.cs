using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests
{
    [TestFixture]
    class Components : Browsers
    {
        [Test]
        public void ClickContactUs()
        {
            Browsers.getDriver.FindElement(By.Id("menu-item-1296")).Click();
        }
    }
}
