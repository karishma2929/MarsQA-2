using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using AutoItX3Lib;
using System.IO;
using MarsQA_2.Utilities;

namespace MarsQA_2.Pages
{
    internal class ShareSkill
    {
        CommonDriver CommonDriverObj = new CommonDriver();
        public void CreateShareSkill(IWebDriver driver)
        {
            //Click on ShareSkill Button
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/div[2]/a")).Click();
            //Enter the Title in textbox
            driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[1]/div/div[2]/div/div[1]/input")).SendKeys("Test Karishma 1");
            //Enter the Description in textbox
            driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[2]/div/div[2]/div[1]/textarea")).SendKeys("Description");
            //Click on Category Dropdown
            driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div/select")).Click();
            driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[1]/select/option[4]")).Click();
            //Click on SubCategory Dropdown
            driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[2]/div[1]/select")).Click();
            driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[2]/div[1]/select/option[5]")).Click();
            //Enter Tag names in textbox
            IWebElement TagEnter = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));
            TagEnter.SendKeys("Tag");
            TagEnter.SendKeys(Keys.Enter);
            //Select the Service type
            driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input")).Click();
            //Select the Location Type
            driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input")).Click();
            //Click on Start Date dropdown
            IWebElement StartDate = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[1]/div[2]/input"));
            StartDate.Click();
            StartDate.Click();
            StartDate.SendKeys("20");
            StartDate.SendKeys("04");
            StartDate.SendKeys("2025");
            //Click on End Date dropdown
            IWebElement EndDate = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[1]/div[4]/input"));
            EndDate.Click();
            EndDate.Click();
            EndDate.SendKeys("20");
            EndDate.SendKeys("06");
            EndDate.SendKeys("2025");
            //Storing the table of available days
            driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[2]/div[1]/div/input")).Click();
            //Click on StartTime dropdown
            IWebElement StartTime = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[2]/div[2]/input"));
            //Storing the starttime 
            StartTime.SendKeys("08");
            StartTime.SendKeys("10");
            StartTime.SendKeys("am");
            //Click on EndTime dropdown
            IWebElement EndTime = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[2]/div[3]/input"));
            EndTime.SendKeys("10");
            EndTime.SendKeys("40");
            EndTime.SendKeys("am");
            //Click on Skill Trade option
            driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input")).Click();
            //Enter Skill Exchange
            IWebElement SkillExchangeTag = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input"));
            SkillExchangeTag.SendKeys("Talent");
            SkillExchangeTag.SendKeys(Keys.Enter);
            //Enter the amount for Credit  ___ Case2
            CommonDriverObj.takeScreenShot(driver);
            //Upload file using AutoIt 
            IWebElement Open = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i"));
            Open.Click();
            AutoItX3 autoItObj = new AutoItX3();
            autoItObj.WinActivate("Open");
            Thread.Sleep(1000);
            autoItObj.Send("C:\\Users\\karis\\OneDrive\\Desktop\\Karishma.txt");
            Thread.Sleep(1000);
            autoItObj.Send("{ENTER}"); 

            //Click on Active/Hidden option
            driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input")).Click();
            //Click on Save button
            driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[11]/div/input[1]")).Click();

            Thread.Sleep(2000);
            CommonDriverObj.takeScreenShot(driver);

            //Check if the Share Skill record was created.
            IWebElement ShareSkillRecord = driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]"));
            Assert.That(ShareSkillRecord.Text == "Test Karishma 1", "Skill is not the Same");

        }
    }
          
}
