using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomation.PageObjects;

namespace TestAutomation
{
    class TestCreateEmployee
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        
        [Test]
        public void CreateNewEmployee()
        {
            //SETUP
            LoginPage login = new LoginPage(driver);
            login.goToPage();
            //ARRANGE
            login.loginAction("User");
            login.clickOnbtnSubmit();
            //ASSERT
            Assert.AreEqual(true, login.checkTitle("Signed in successfully."));

            NewEmployeePage newEmployee = login.goToNewEmployee();
            newEmployee.fillFormAction("Employee");
            newEmployee.clickOnbtnSubmit();

            Assert.AreEqual(true, newEmployee.checkTitle("Employee was successfully created."));
        }

        [TearDown]
        public void TearDown()
        {
            //driver.Close();
        }
    }
}
