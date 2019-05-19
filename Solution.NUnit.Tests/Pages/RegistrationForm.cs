using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Solution.NUnit.Tests.Sections;
using System;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.NUnit.Tests.Sections
{
    public class RegistrationForm : IPages
    {
        [FindsBy(How = How.Name, Using = "jmeno")]
        private IWebElement yourName;
        [FindsBy(How = How.Name, Using = "prijmeni")]
        private IWebElement yourSurname;
        [FindsBy(How = How.Name, Using = "rod_cislo")]
        private IWebElement yourDOB;
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement yourEmail;
        [FindsBy(How = How.Name, Using = "telefon")]
        private IWebElement yourCell;
        [FindsBy(How = How.Name, Using = "statni_prislusnost")]
        private IWebElement yourNationality;
        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        private IWebElement submit;
        [FindsBy(How = How.Name, Using = "zaloz_e_osobu")]
        private IWebElement submitNewRequest;
        // TODO implement 
        [FindsBy(How = How.ClassName, Using = "")]
        private IWebElement SuccMessage;
        [FindsBy(How = How.Id, Using = "menu-item-27")]
        private IWebElement ePrihlaska;
        [FindsBy(How = How.PartialLinkText, Using = "nový používateľ")]
        private IWebElement enterSystem;
        [FindsBy(How = How.PartialLinkText, Using = "Fakulta informatiky")]
        private IWebElement enterFI;
        [FindsBy(How = How.Name, Using = "vybrat_stupen")]
        private IWebElement typeOfStudySubmit;
        [FindsBy(How = How.XPath, Using = "//img[@sysid='base-op']")]
        private IWebElement typeOfProgram;
        [FindsBy(How = How.Name, Using = "agreement_21")]
        private IWebElement gDPRCheckBox;

        //findElement(By.cssSelector("a[href='images/shim.gif']")

        public bool IsAt()
        {
            return Browsers.Title.Contains("Contact Us");
        }

        public void GoTo()
        {
            GoToPEVS();
            System.Threading.Thread.Sleep(1000);
            ePrihlaska.Click();
            System.Threading.Thread.Sleep(1000);
            enterSystem.Click();
            System.Threading.Thread.Sleep(1000);
            enterFI.Click();
            System.Threading.Thread.Sleep(1000);
            typeOfStudySubmit.Submit();
            System.Threading.Thread.Sleep(1000);
            typeOfProgram.Click();        
        }

        // ?? What was that for ? 
        public void NavigateToForm() {

        }
        public void GoToPEVS()
        {
            Browsers.NavigateTo("https://www.paneurouni.com/");
        }

        public void SendYourName(string name)
        {
            yourName.SendKeys(name);
        }

        public void SendYourDOB(string dOB)
        {
            yourDOB.SendKeys(dOB);
        }
 
        public void ConfirmCheckBox()
        {
            gDPRCheckBox.Click();
        }

        public void SendYourSurname(string surname)
        {
            yourSurname.SendKeys(surname);
        }

        public void SendYourEmail(string email)
        {
            yourEmail.SendKeys(email);
        }
        public void SendYourCell(string cell)
        {
            yourCell.SendKeys(cell);
        }
        public void SendYourNationality(string nationality)
        {
            var dropdownNationality = Browsers.getDriver.FindElement(By.Name("statni_prislusnost"));
            var selectElement = new SelectElement(dropdownNationality);
            selectElement.SelectByValue(nationality);
        }
        public void SubmitApplicationForm()
        {
            submitNewRequest.Submit();
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
            string filePath = @"C:\Users\Admin\source\repos\NUnit.Tests\Solution.NUnit.Tests\Inputs\inputsRegistraionForm.csv";
            List<string> data = new List<string>();
            data = Servers.general.loadCsvFile(filePath);

            for (int i = 0; i < data.Count; i++)
            {
                var values = data[i].Split(';');
                SendYourName(values[0]);
                SendYourSurname(values[1]);
                SendYourEmail(values[2]);
                SendYourNationality(values[3]);
                SendYourDOB(values[4]);
                ConfirmCheckBox();
                //SubmitApplicationForm();
                //ValidateMessage();
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
