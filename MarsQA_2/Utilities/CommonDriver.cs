using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework;
using MarsQA_2.Pages;

namespace MarsQA_2.Utilities
{
    public class CommonDriver   
    {
       // For Extent Reports:
       public static ExtentReports extentreportobj;
       public static ExtentHtmlReporter htmlreporterobj;
       public static ExtentTest extenttestobj;
       //For Common driver
       public static IWebDriver driver;

        [OneTimeSetUp]
        public void LoginFunction()
        {
            extentreportobj = new ExtentReports();
            htmlreporterobj = new ExtentHtmlReporter(@"C:\IndustryConnect\MarsTask_2\MarsQA-2\MarsQA_2\ExtentReports\test.html");
            extentreportobj.AttachReporter(htmlreporterobj);

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            SignIn SignInObj = new SignIn();
            SignInObj.LoginSteps(driver);
        }

        [OneTimeTearDown]
        public void CloseTest()
        {
            extentreportobj.Flush();
            driver.Close();
        }


    }
}
