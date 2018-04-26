using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using TestAutomation.DataAccess;

namespace TestAutomation.PageObjects
{
    class LoginPage
    {

        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        
        [FindsBy(How = How.XPath, Using = "//*[@id='user_email']")]
        private IWebElement inputName;
        [FindsBy(How = How.XPath, Using = "//*[@id='user_password']")]
        private IWebElement inputPassword;
        [FindsBy(How = How.XPath, Using = "//*[@id='new_user']/div[3]/p[4]/input")]
        private IWebElement btnSubmit;
        [FindsBy(How = How.XPath, Using = "//*[@id='content']/p[1]")]
        private IWebElement lblTitle;
        [FindsBy(How = How.XPath, Using = "//*[@id='content']/p/a")]
        private IWebElement lnkSignIn;

        public void goToPage()
        {
            driver.Navigate().GoToUrl("http://vacations-management.herokuapp.com/users/sign_in");
        }

        public void loginAction(String key)
        {
            var userData = ExcelDataAccess.GetTestData(key);

            inputName.Clear();
            inputName.SendKeys(userData.Email);
            inputPassword.Clear();
            inputPassword.SendKeys(userData.Pass);
        }

        public void clickOnbtnSubmit()
        {
            btnSubmit.Submit();
        }

        public bool checkTitle(String title)
        {
            return lblTitle.Text.Equals(title);
        }

        public NewEmployeePage goToNewEmployee()
        {
            lnkSignIn.Click();
            return new NewEmployeePage(driver);
        }

        public DeleteEmployee goToDeleteEmployee()
        {
            return new DeleteEmployee(driver);
        }

    }
}
