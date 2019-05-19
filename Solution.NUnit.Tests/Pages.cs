using OpenQA.Selenium.Support.PageObjects;
using Solution.NUnit.Tests.Sections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.NUnit.Tests
{
    class Pages
    {
        private static T getPages<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(Browsers.getDriver, page);
            return page;
        }
        public static ContactUs contactUs
        {
            get { return getPages<ContactUs>(); }
        }
    }
}
