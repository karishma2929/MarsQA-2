using MarsQA_2.Pages;
using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using MarsQA_2.Utilities;
using AventStack.ExtentReports;
using System.IO;
using AventStack.ExtentReports.Reporter;

namespace MarsQA_2
{
    [TestFixture]
    public class Program :CommonDriver
    {
        ManageListing manageListingObj = new ManageListing();
        //public IWebDriver driver;

        [OneTimeSetUp]
        public void LoginFunction()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            SignIn SignInObj =new SignIn();
            SignInObj.LoginSteps(driver);
        }
        [Test]
        public void A_CreateShareSkill()
        {
            ShareSkill shareSkillObj = new ShareSkill();
            shareSkillObj.CreateShareSkill(driver);
        }
        [Test]
        public void B_EditShareSkill()
        {

            manageListingObj.EditShareSkill(driver);
        }

        [Test]
        public void C_DeleteShareSkill()
        {
            manageListingObj.DeleteSkill(driver);
        }














    }
}
