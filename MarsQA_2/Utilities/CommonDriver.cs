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
using MarsQA_2.Excel_Data_Reader;

namespace MarsQA_2.Utilities
{
    public class CommonDriver   
    {
     //For Screen shot;
        public static string screenshotDirectory;
     // For Extent Reports:
       public static ExtentReports extentreportobj; 
       public static ExtentHtmlReporter htmlreporterobj;
       public static ExtentTest extenttestobj;
     //For Common driver
       public static IWebDriver driver;
     //For Excel reader
        public static FileStream stream;

        [OneTimeSetUp]
        public void LoginFunction()
        {
            string fileName = @"C:\IndustryConnect\MarsTask_2\MarsQA-2\MarsQA_2\Excel_Use_Data\Excel_Test_data.xlsx";
            //open file and returns as stream
            stream = File.Open(fileName, FileMode.Open, FileAccess.Read);
            ExcelReader.ReadDataTable(stream, "LoginSheet");

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

        public void takeScreenShot(IWebDriver driver)
        {
            string screenshotFileName = Directory.GetParent(@"../../../").FullName
                 + Path.DirectorySeparatorChar + "Screenshot"
                 + Path.DirectorySeparatorChar + "Screentshot_" + DateTime.Now.ToString("ddMMyyyy HHmmss") + ".png";
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(screenshotFileName, ScreenshotImageFormat.Png);
        }


    }
}
