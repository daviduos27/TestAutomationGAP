using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using TestAutomation.DataAccess;

namespace TestAutomation.PageObjects
{
    class DeleteEmployee
    {

        private IWebDriver driver;

        public DeleteEmployee(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        
        [FindsBy(How = How.CssSelector, Using = "#content > table")]
        private IWebElement tblEmployees;

        public void waitAction()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.CssSelector("#content > table"))));
        }


        public void deleteAction(String key)
        {
            var userData = ExcelDataAccess.GetTestData(key);
            //*[@id="content"]/table
            IList<IWebElement> tableRow = tblEmployees.FindElements(By.TagName("tr"));
            
            foreach (IWebElement row in tableRow)
            {
                IList<IWebElement> cells = row.FindElements(By.TagName("td"));
                if (cells.Count > 8 && cells[2].Text.Equals(userData.ID) && cells[3].Text.Equals(userData.LeaderName))
                {
                    cells[8].Click();
                }
            }
        }

        public void acceptConfirmAction()
        {           
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();
            }
            catch (NoAlertPresentException ex)
            {              
            }
        }
        public bool searchAction(String key)
        {
            var userData = ExcelDataAccess.GetTestData(key);
            //*[@id="content"]/table
            IList<IWebElement> tableRow = tblEmployees.FindElements(By.TagName("tr"));

            foreach (IWebElement row in tableRow)
            {
                IList<IWebElement> cells = row.FindElements(By.TagName("td"));
                if (cells.Count > 8 && cells[2].Text.Equals(userData.ID) && cells[3].Text.Equals(userData.LeaderName))
                {
                   return true;
                }
            }
            return false;
        }
    }
}
