using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestAutomation.PageObjects;

namespace TestAutomation
{
    class TestLoginSucces
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void LoginSuccess()
        {
            LoginPage login = new LoginPage(driver);
            login.goToPage();
            login.loginAction("User");
            login.clickOnbtnSubmit();
            Assert.AreEqual(true, login.checkTitle("Signed in successfully."));
                      
        }
              

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
