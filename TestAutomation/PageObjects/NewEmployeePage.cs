using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using TestAutomation.DataAccess;

namespace TestAutomation.PageObjects
{
    class NewEmployeePage
    {
        private IWebDriver driver;

        public NewEmployeePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='employee_first_name']")]
        private IWebElement inputFirstName;
        [FindsBy(How = How.XPath, Using = "//*[@id='employee_last_name']")]
        private IWebElement inputLastName;
        [FindsBy(How = How.XPath, Using = "//*[@id='employee_email']")]
        private IWebElement inputEmail;
        [FindsBy(How = How.XPath, Using = "//*[@id='employee_identification']")]
        private IWebElement inputID;
        [FindsBy(How = How.XPath, Using = "//*[@id='employee_leader_name']")]
        private IWebElement inputLeaderName;
        
        [FindsBy(How = How.XPath, Using = "//*[@id='employee_start_working_on_1i']")]
        private IWebElement dpdYear;
        [FindsBy(How = How.XPath, Using = "//*[@id='employee_start_working_on_2i']")]
        private IWebElement dpdMonth;
        [FindsBy(How = How.XPath, Using = "//*[@id='employee_start_working_on_3i']")]
        private IWebElement dpdDay;

        [FindsBy(How = How.XPath, Using = "//*[@id='new_employee']/div[8]/input")]
        private IWebElement btnSubmit;

        [FindsBy(How = How.XPath, Using = "//*[@id='notice']")]
        private IWebElement lblTitle;

     

        public void fillFormAction(String key)
        {

            var userData = ExcelDataAccess.GetTestData(key);

            inputFirstName.Clear();
            inputFirstName.SendKeys(userData.FirstName);

            inputLastName.Clear();
            inputLastName.SendKeys(userData.LastName);

            inputEmail.Clear();
            inputEmail.SendKeys(userData.Email);

            inputID.Clear();
            inputID.SendKeys(userData.ID);

            inputLeaderName.Clear();
            inputLeaderName.SendKeys(userData.LeaderName);

            var yearSelect = new SelectElement(dpdYear);
            yearSelect.SelectByValue(userData.Year);

            var monthSelect = new SelectElement(dpdMonth);
            monthSelect.SelectByText(userData.Month);

            var daySelect = new SelectElement(dpdDay);
            daySelect.SelectByValue(userData.Day);
        }

        

        public void clickOnbtnSubmit()
        {
            btnSubmit.Submit();
        }

        public bool checkTitle(String title)
        {

            return lblTitle.Text.Equals(title);
        }
    }
}
