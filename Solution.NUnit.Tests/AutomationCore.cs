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

        [SetUp]
        public void PrepareForTesting()
        {
            Browsers.Init();
        }

        [TearDown]
        public void CleanAfterTesting()
        {
            Browsers.Close();
        }
        
    }
}
