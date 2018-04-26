using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomation.DataAccess;

namespace TestAutomation.PageObjects
{
    class CheckEmployee
    {
        private IWebDriver driver;

        public CheckEmployee(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='employee_identification']")]
        private IWebElement inputId;
        [FindsBy(How = How.XPath, Using = "//*[@id='new_employee']/div[3]/input")]
        private IWebElement btnSubmit;
        [FindsBy(How = How.XPath, Using = "//*[@id='content']/h1")]
        private IWebElement lblTitle;

        public void goToPage()
        {
            driver.Navigate().GoToUrl("http://vacations-management.herokuapp.com/public/find_employee");
        }

        public void checkAction(String key)
        {
            var userData = ExcelDataAccess.GetTestData(key);

            inputId.Clear();
            inputId.SendKeys(userData.ID);
        }

        public void clickOnbtnSubmit()
        {
            btnSubmit.Submit();
        }

        public bool checkTitle(String key)
        {
            var userData = ExcelDataAccess.GetTestData(key);
            String userName = userData.FirstName + " " + userData.LastName;
            return lblTitle.Text.Contains(userName);
        }
    }
}
