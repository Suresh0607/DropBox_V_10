using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using BoDi;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
//using NUnit.InsightsRetail.CommonClasses;
using NUnit.InsightsRetail.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using TechTalk.SpecFlow;
using Unity;

namespace NUnit.InsightsRetail.Steps
{
    [Binding]
    public class ReportSteps
    {
        private IWebDriver _driver;        
        MyReports_Page myReportsPage;
        Login_Page login_Page;
        Home_Page home_page;
        File_Page file_page;
       
        public ReportSteps(IWebDriver driver)
        {
            this._driver = driver;
        }

        [Given(@"user (.*) logs into the CE Client application")]
        public void GivenUserLogsIntoTheCEClientApplication(string userName)
        {
            this.login_Page = new Login_Page(_driver);
            this.login_Page.gotologinPage(userName);
           

        }

        [Then(@"user logout")]
        public void User_Logout()
        {
            _driver.FindElement(By.XPath("/html/body/div/div[1]/div[1]/a[3]")).Click();          
        }
               
        [Then(@"user NaviateTo '(.*)'")]
        public void ThenUserNaviateTo(string Menu)
        {
            switch (Menu)
            {
                case "Files":
                    this.home_page = new Home_Page(_driver);
                    home_page.goTo_FilesPage();
                    break;
                case "Paper":
                    Console.WriteLine("Case 2");
                    break;               
            }
        }
                      
        [Then(@"Click on ""(.*)""")]
        public void ClickOn(string ObjectName)
        {
            myReportsPage = new MyReports_Page(_driver);
            myReportsPage.clickon(ObjectName);
            Console.WriteLine("ClickOn"+ ObjectName);
        }

        [Then(@"user creates NewFolder '(.*)'")]
        public void ThenUserCreatesNewFolder(string folderName)
        {
            file_page = new File_Page(_driver);
            file_page.createNewFolder(folderName);
        }

        [Then(@"user upload files '(.*)' to '(.*)'")]
        public void ThenUserUploadFilesTo(string files, string folderName)
        {
            file_page = new File_Page(_driver);
            file_page.uploadFiles(files,folderName);
        }

        [Then(@"user can share '(.*)' to '(.*)'")]
        public void ThenUserCanShareTo(string folderName, string eMailID)
        {
            file_page = new File_Page(_driver);
            file_page.shareFolder(folderName, eMailID);
        }


    }
}
