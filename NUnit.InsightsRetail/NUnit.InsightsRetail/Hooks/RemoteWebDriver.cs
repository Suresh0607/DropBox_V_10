using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.Threading;
using System.Drawing;
using OpenQA.Selenium.Interactions;
using System.IO;

namespace NUnit.InsightsRetail
{

    public class RemoteWebDriverSetup 
    {
        private ChromeOptions options;
        private RemoteWebDriver _driver;

        public IWebDriver LaunchBrowser(String BrowserType)
        {
            if(BrowserType.Equals("chrome"))
            {
                options = new ChromeOptions();
                _driver = new ChromeDriver(@"C:\git\DropBox\Csharp_BDD_LastestV1\NUnit.InsightsRetail\ChromeDriver\", options); //<-Add your path
            }
            return _driver;
            //options = new ChromeOptions();
            //threadDriver = new ScreenShotRemoteWebDriver(new Uri("http://" + _host + ":" + _port + "/wd/hub"), options);
            //eveDriver = new MyEventFiringWebDriver(threadDriver);
            //return eveDriver;
        }
    }
}
