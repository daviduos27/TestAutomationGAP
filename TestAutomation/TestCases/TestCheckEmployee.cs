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
    class TestCheckEmployee
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void CheckEmployee()
        {
            CheckEmployee check = new CheckEmployee(driver);
            check.goToPage();
            check.checkAction("Employee");
            check.clickOnbtnSubmit();
            Assert.AreEqual(true, check.checkTitle("Employee"));
                      
        }
              

        [TearDown]
        public void TearDown()
        {
            //driver.Close();
        }
    }
}
