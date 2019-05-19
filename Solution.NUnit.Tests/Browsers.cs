using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.NUnit.Tests
{
    class Browsers
    {
        private static IWebDriver webDriver;
        public static ReportsManager reports; 
        private static string browser = ConfigurationManager.AppSettings["browser"];
        private static string baseURL = ConfigurationManager.AppSettings["url"];
      
        public static void Init()
        {
            switch (browser)
            {
                case "Chrome":
                    webDriver = new ChromeDriver();
                    break;
                case "IE":
                    webDriver = new InternetExplorerDriver();
                    break;
                case "Firefox":
                    webDriver = new FirefoxDriver();
                    break;
            }
            webDriver.Manage().Window.Maximize();
            reports = new ReportsManager(browser, baseURL);

            Goto(baseURL);
        }
        public static string Title
        {
            get { return webDriver.Title; }
        }
        public static IWebDriver getDriver
        {
            get { return webDriver; }
        }
        public static void Goto(string url)
        {
            webDriver.Url = url;
            reports.verifyURL(url); 
        }
        public static void Close()
        {
            webDriver.Quit();
        }

        public static void NavigateTo(string url)
        {
            webDriver.Navigate().GoToUrl(url);
        }
    }
}
