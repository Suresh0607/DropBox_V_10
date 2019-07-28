using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.InsightsRetail
{
    public class BrowserUtil
    {
        private IWebDriver driver;

        public BrowserUtil(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void mouseOverClick( IWebDriver driver, IWebElement webObj, Boolean doMouseOver)
        {
         
            if (doMouseOver)
            {
                if (webObj.GetAttribute("onmouseover") != null)
                {
                    runJSFireEvent(driver, webObj, "mouseover");
                }
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            webObj.Click();
        }

        public void runJSFireEvent(IWebDriver driver, IWebElement weObj, String fireEvent)
        {
            String fireEventScript = "if(document.createEvent)" + "{" //alert('OK');"
                    + "var evObj = document.createEvent('MouseEvents');" + "evObj.initEvent('" + fireEvent + "', true, false); " + "arguments[0].dispatchEvent(evObj);} " + "else if(document.createEventObject) " + "{" //alert('OK 2');"
                    + "var evObj = document.createEventObject();" + " arguments[0].fireEvent('on" + fireEvent + "', evObj);}";

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(fireEventScript, weObj);
        }
    }
}
