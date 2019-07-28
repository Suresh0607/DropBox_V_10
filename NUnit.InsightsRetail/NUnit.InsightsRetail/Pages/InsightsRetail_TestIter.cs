using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.InsightsRetail
{
    public class InsightsRetail_TestIter
    {
        public IWebDriver driver;

        public InsightsRetail_TestIter(String BrowserType) 
        {
            CommonTestExecute cte = new CommonTestExecute();
		    this.driver = cte.SetUp(BrowserType);		    
	    }
    }
}
