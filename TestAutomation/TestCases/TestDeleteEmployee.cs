using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestAutomation.PageObjects;

namespace TestAutomation.TestCases
{
    class TestDeleteEmployee
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }


        [Test]
        public void DeleteEmployee()
        {
            //SETUP
            LoginPage login = new LoginPage(driver);
            login.goToPage();
            //ARRANGE
            login.loginAction("User");
            login.clickOnbtnSubmit();
            //ASSERT
            Assert.AreEqual(true, login.checkTitle("Signed in successfully."));

            DeleteEmployee deleteEmployee = login.goToDeleteEmployee();
            deleteEmployee.waitAction();
            deleteEmployee.deleteAction("Employee");
            deleteEmployee.acceptConfirmAction();

            Assert.AreEqual(false, deleteEmployee.searchAction("Employee"));

            
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
