using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestAutomation
{
    [TestFixture]
    public class UITest
    {
        [Test]
        public void Login()
        {

            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://vacations-management.herokuapp.com/users/sign_in";
            // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            IWebElement inputName = driver.FindElement(By.XPath("//*[@id='user_email']"));
            inputName.SendKeys("gap-automation-test@mailinator.com");

            IWebElement inputPassword = driver.FindElement(By.XPath("//*[@id='user_password']"));
            inputPassword.SendKeys("12345678");

            //Submit Button
            driver.FindElement(By.XPath("//*[@id='new_user']/div[3]/p[4]/input")).Click();

        }
    }
}
