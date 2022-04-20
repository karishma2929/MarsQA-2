using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsQA_2.Utilities
{
    public class CommonDriver
    {
        public static IWebDriver driver;

        public void OpenChromeBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }
        public void CloseTestRun()
        {
            driver.Quit();
        }


    }
}
