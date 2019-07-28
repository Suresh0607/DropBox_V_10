using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NUnit.InsightsRetail
{
    public class Login_Page
    {
        private IWebDriver LoginDriver;

        public Login_Page(IWebDriver driver)
        {
            this.LoginDriver = driver;
            
        }

        public void gotologinPage(string userName)
        {
            try
            {
                LoginDriver.Navigate().GoToUrl("https://www.dropbox.com/login");
                new WebDriverWait(LoginDriver, TimeSpan.FromSeconds(500000)).Until(
                 d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
                LoginDriver.Manage().Window.Maximize();
                LoginDriver.FindElement(By.XPath("//*[@name='login_email']")).SendKeys(userName);
                LoginDriver.FindElement(By.XPath("//*[@name='login_password']")).SendKeys("Sydney@0607");
                LoginDriver.FindElement(By.XPath("//*[@class='login-button signin-button button-primary']")).Click();

                //new WebDriverWait(LoginDriver, TimeSpan.FromSeconds(500000)).Until(
                //d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
                Thread.Sleep(25000);
                IWebElement HomeLink =LoginDriver.FindElement(By.XPath("//*[@id='home']"));
                Assert.AreEqual(true, HomeLink.Displayed);
            }
            catch(Exception e)
            {
                throw (e);
            }
            
        }
    }
}
