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
    class TestClass
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        /*[Test]
        public void LoginSucces()
        {
            LoginPage login = new LoginPage(driver);
            login.goToPage();
            login.writeName("gap-automation-test@mailinator.com");
            login.writePass("12345678");
            login.clickOnbtnSubmit();
            Assert.AreEqual(true, login.checkTitle("Signed in successfully."));
                      
        }*/

        [Test]
        public void CreateNewEmployee()
        {
            //SETUP
            LoginPage login = new LoginPage(driver);
            login.goToPage();
            //ARRANGE
            login.writeName("Default");
            login.writePass("12345678");
            login.clickOnbtnSubmit();
            //ASSERT
            Assert.AreEqual(true, login.checkTitle("Signed in successfully."));

            NewEmployeePage newEpmloyee = login.goToNewEmployee();
            newEpmloyee.fillForm("angel","peña","a@test.com", "1222333444", "Nelson Duarte", "2014", "January", "24");
            newEpmloyee.clickOnbtnSubmit();

            Assert.AreEqual(true, newEpmloyee.checkTitle("Employee was successfully created."));
        }

        [TearDown]
        public void TearDown()
        {
            //driver.Close();
        }
    }
}
