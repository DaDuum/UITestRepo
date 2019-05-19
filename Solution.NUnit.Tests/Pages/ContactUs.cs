using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;

namespace Solution.NUnit.Tests.Sections
{
    public class ContactUs : IPages
    {
        [FindsBy(How = How.Name, Using = "your-name")]
        private IWebElement yourName;

        [FindsBy(How = How.Name, Using = "your-email")]
        private IWebElement yourEmail;

        [FindsBy(How = How.Name, Using = "your-subject")]
        private IWebElement yourSubject;

        [FindsBy(How = How.Name, Using = "your-message")]
        private IWebElement yourMessage;

        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        private IWebElement submit;

        [FindsBy(How = How.ClassName, Using = "")]
        private IWebElement SuccMessage;

        [FindsBy(How = How.Id, Using = "")]
        private IWebElement contactUs;

        public bool IsAt()
        {
            return Browsers.Title.Contains("Contact Us");
        }

        /// Implement for : https://is.paneurouni.com/prihlaska/dotaz.pl?sekce=10;zpet=/prihlaska/zaloz_eosobu.pl?fakulta=40;;lang=sk

        public void GoTo()
        {
            contactUs.Click();
        }
        // TODO : unified function for sending items without exposing details .. 
        public void SendItem(IWebElement item, string value) {
            item.SendKeys(value);
        }
        public void SendYourName(string name)
        {
            yourName.SendKeys(name);
        }
        public void SendYourEmail(string email)
        {
            yourEmail.SendKeys(email);
        }
        public void SendYourSubject(string Subject)
        {
            yourSubject.SendKeys(Subject);
        }
        public void SendYourMessage(string massage)
        {
            yourMessage.SendKeys(massage);
        }
        public void AcceptSubmit()
        {
            submit.Submit();
        }
        public void ValidateMessage()
        {
            try
            {
                var text = SuccMessage.Text;
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        public void FilldatafromCsv()
        {
            string filePath = @"C:\Users\Admin\source\repos\NUnit.Tests\Solution.NUnit.Tests\Inputs\inputs.csv";
            List<string> data = new List<string>();
            data = Servers.general.loadCsvFile(filePath);
            for (int i = 0; i < data.Count; i++)
            {
                var values = data[i].Split(';');
                SendYourName(values[0]);
                SendYourEmail(values[1]);
                SendYourSubject(values[2]);
                SendYourMessage(values[3]);
                AcceptSubmit();
                ValidateMessage();
            }
        }
    }

}
