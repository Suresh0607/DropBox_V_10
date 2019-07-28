using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace NUnit.InsightsRetail.Pages
{
    public class MyReports_Page:CommonTestExecute
    {
        private IWebDriver MyReportDriver;
        private BrowserUtil bu;
        private WebDriverWait wait;
        

        public MyReports_Page(IWebDriver driver)
        {
            this.MyReportDriver = driver;
            this.bu = new BrowserUtil(MyReportDriver);
            this.wait = new WebDriverWait(MyReportDriver, TimeSpan.FromSeconds(10));
        }

        Dictionary<string, string> dicRepo = new Dictionary<string, string>()
        {
            { "CreateNewReport"            , "/html/body/div/div[6]/div/div[1]/div/div"},
            { "ReportName"                 , "//*[@id='reportName']"},
            { "Style"                      , ".//*[contains(@id,'core-ajaxForm-')]/form/div/div[2]/fieldset/div/div/div[2]/div[1]/div[7]/button"},
            { "ReportType"                 , "//*[@id='showReportType']/div[3]/button"},
            { "GraphType"                  , ".//*[@id='showGraphType']/div[3]/button"},
            { "DataType"                   , ".//*[@id='showDataType']/div[3]/button"},
            { "ReportTypeParameter"        , ".//*[@id='subTypePopulate']/div[3]/button"},
            { "Category"                   , ".//*[@id='categoryPopulate']/button"},
            { "Retailer"                   , ".//*[@id='onlineRetailerPopulate']/button"},
            { "Date"                       , ".//*[@id='row_date']/td[2]/button"},
            { "Increments_Daily"           , "//*[@id='timeIncrement_daily']"},
            { "Style_Options"              , "ui-multiselect-reportStyle-option"},
            { "GraphType_Options"          , "ui-multiselect-reportGraphType-option"},
            { "DataType_Options"           , "ui-multiselect-dataType-option"},
            { "ReportType_Options"         , "ui-multiselect-reportType-option"},
            { "ReportTypeParameter_Options", "ui-multiselect-reportSubType-option"},
            { "Category_Options"           , "ui-multiselect-category-option"},
            { "Retailer_Options"           , "ui-multiselect-onlineRetailer-option"},
            { "Date_Options"               , "ui-multiselect-date-option"},
            { "Save"                       , "//*[@id='tmpButton']"},
            { "Go"                         , "//*[@id='goButton']"},
            { "DataTab"                    , "//*[@id='spinnerTab2']" }
        };

       
        public int goTo_MyReportsPage() 
        {
            Thread.Sleep(20000);


            String Xpath1 = "//ul[@class='nav']";
            String Xpath2 = "div[@class='subNav']";
            
            List<IWebElement> Menus = new List<IWebElement>();
            Menus = MyReportDriver.FindElement(By.XPath(Xpath1)).FindElements(By.TagName("li")).ToList();
                        

            IWebElement Menu = null;
            IWebElement SubMenu = null;


            for (int i = 0; i <= MyReportDriver.FindElement(By.XPath(Xpath1)).FindElements(By.TagName("li")).Count; i++)
            {
                Menu = Menus.ElementAt(i);
                if (Menu.Text.Equals("REPORTS"))
                {
                    break;
                }
            }


            IWebElement Report = Menu;

           
            String strJavaScript = "var element = arguments[0];"
                    + "var mouseEventObj = document.createEvent('MouseEvents');"
                    + "mouseEventObj.initEvent( 'mouseover', true, true );"
                    + "element.dispatchEvent(mouseEventObj);";

            ////Then JavascriptExecutor class is used to execute the script to trigger the dispatched event.
            ((IJavaScriptExecutor)MyReportDriver).ExecuteScript(strJavaScript, Report);


            List<IWebElement> SubMenus = Report.FindElements(By.XPath(Xpath2)).ToList().ElementAt(0).FindElement(By.ClassName("subNav")).FindElements(By.TagName("li")).ToList();


            for (int j = 0; j <= SubMenus.Count(); j++)
            {
                SubMenu = SubMenus.ElementAt(j);
                if (SubMenu.Text.Equals("My Reports"))
                {
                    break;
                }
            }

            IWebElement MyReport = SubMenu;
            bu.mouseOverClick(MyReportDriver, MyReport, true);
            return 1;
        }

        public void enter(string objectName, string objectValue)
        {
            MyReportDriver.FindElement(By.XPath(dicRepo[objectName])).SendKeys(objectValue);
        }

        public int select(string objectName, string objectValue)
        {
            string TestObjectXpath=null;
            clickon(objectName);
            TestObjectXpath = objectName + "_Options";
            List<IWebElement> listObj = MyReportDriver.FindElements(By.XPath(".//*[contains(@" + "for" + ",'" + dicRepo[TestObjectXpath] + "')]")).ToList();
            IWebElement Obj = null;

            for (int i = 0; i <= listObj.Count() - 1; i++)
            {
                if (listObj.ElementAt(i).FindElement(By.TagName("span")).Text.Equals(objectValue))
                {
                    Obj = listObj.ElementAt(i).FindElement(By.TagName("span"));
                    break;
                }
            }

            Actions action = new Actions(MyReportDriver);
            action.MoveToElement(Obj).Build().Perform();
            action.Click(Obj).Build().Perform();

            MyReportDriver.FindElement(By.XPath("/html/body/div[1]/div[6]/div/div[3]/div/form/div")).Click();
            Thread.Sleep(2000);
            return 1;
        }
               
        public void clickon(string objectName)
        {
            Thread.Sleep(200);
            MyReportDriver.FindElement(By.XPath(dicRepo[objectName])).Click();          
        }

        public void downloadReport()
        {

        }
    }
}
