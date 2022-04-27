using MarsQA_2.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsQA_2.Pages
{
    internal class ManageListing
    {
        CommonDriver CommonDriverObj = new CommonDriver();
        public void EditShareSkill(IWebDriver driver)
        {
            //Go to Manage Listing  
            driver.FindElement(By.XPath("//*[@id='listing-management-section']/section[1]/div/a[3]")).Click();
            Thread.Sleep(1000);
            //Click on Edit button
            driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[2]")).Click();
            //Edit Title
            IWebElement TitleTab = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[1]/div/div[2]/div/div[1]/input"));
            TitleTab.Clear();
            TitleTab.SendKeys("Karishma Test Edit");
            //click on Save button
            driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[11]/div/input[1]")).Click();
            Thread.Sleep((1000));
            CommonDriverObj.takeScreenShot(driver);
            //Assertion
            IWebElement EditedData = driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]"));
            Assert.That(EditedData.Text == "Karishma Test Edit", "Tile is not Edited");
        }

        public void DeleteSkill(IWebDriver driver)
        {
            Thread.Sleep(1000);
            //Go to Manage Listing  
            driver.FindElement(By.XPath("//*[@id='listing-management-section']/section[1]/div/a[3]")).Click();
            Thread.Sleep(1000);
            // Click on Delete Button
            driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]/i")).Click();
            // Click Yes in Pop up message
            driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[2]")).Click();
            Thread.Sleep(1000);
            CommonDriverObj.takeScreenShot(driver);
            IWebElement DeletedData = driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]"));
            Assert.That(DeletedData.Text != "Karishma Test Edit", "Tile is Deleted succesfully");
        }
    }
    

}
