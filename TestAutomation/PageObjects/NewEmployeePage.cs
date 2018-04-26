using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

     

        public void fillForm(String fname,String lname,String email, String id, String leaderName, String year,String month,String day)
        {
            inputFirstName.Clear();
            inputFirstName.SendKeys(fname);

            inputLastName.Clear();
            inputLastName.SendKeys(lname);

            inputEmail.Clear();
            inputEmail.SendKeys(email);

            inputID.Clear();
            inputID.SendKeys(id);

            inputLeaderName.Clear();
            inputLeaderName.SendKeys(leaderName);

            var yearSelect = new SelectElement(dpdYear);
            yearSelect.SelectByValue(year);

            var monthSelect = new SelectElement(dpdMonth);
            monthSelect.SelectByText(month);

            var daySelect = new SelectElement(dpdDay);
            daySelect.SelectByValue(day);
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
