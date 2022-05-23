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
using MarsQA_2.Excel_Data_Reader;
using SeleniumExtras.PageObjects;

namespace MarsQA_2.Pages
{
    internal class ShareSkill
    {
        CommonDriver CommonDriverObj = new CommonDriver();
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[1]/div/div[2]/a")] IWebElement ShareSkillButton;
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[1]/div/div[2]/div/div[1]/input")] IWebElement Titletextbox;
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[2]/div/div[2]/div[1]/textarea")] IWebElement Descriptiontextbox;
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div/select")] IWebElement CategoryDropdown;
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div/select/option[6]")] IWebElement ProgrammingOption;  
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[2]/div[1]/select")] IWebElement SubCategoryDropdown;
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[2]/div[1]/select/option[4]")] IWebElement SubCategoryOption;
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div/div/div/div/input")] IWebElement Tag;
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div/div/div/div/input")] IWebElement ServiceType;
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input")] IWebElement LocationType;
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[1]/div[2]/input")] IWebElement StartDate;
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[1]/div[4]/input")] IWebElement EndDate;
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[2]/div[1]/div/input")] IWebElement AvailableDays;
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[3]/div[2]/input")] IWebElement AvailableDayStartTime;
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[3]/div[3]/input")]IWebElement AvailableDayEndTime;
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input")] IWebElement SkillTrade;
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input")] IWebElement SkillExchangeTag;
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i")] IWebElement Uploadfile;
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input")] IWebElement ActiveButton;
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[11]/div/input[1]")] IWebElement SaveButton;
        
        public void CreateShareSkill(IWebDriver driver)
        {
            PageFactory.InitElements(driver,this);

            ShareSkillButton.Click();   //Done
            string title = ExcelReader.ReadData(1, "Title");  //Done
            Titletextbox.SendKeys(title);

            string description = ExcelReader.ReadData(1, "Description"); //Done
            Descriptiontextbox.SendKeys(description);
            
            CategoryDropdown.Click();      //Done
            string category = ExcelReader.ReadData(1, "Category");
            ProgrammingOption.Click();

            SubCategoryDropdown.Click();
            SubCategoryOption.Click();
            
            
            Tag.Click();
            string tagName = ExcelReader.ReadData(1, "Tags");
            Tag.SendKeys(tagName);
            Tag.SendKeys(Keys.Enter);

            ServiceType.Click();  
            LocationType.Click();

            string startDateCol = ExcelReader.ReadData(1, "Start Date");
            StartDate.SendKeys(startDateCol);

            string endDateCol = ExcelReader.ReadData(1, "End Date");
            EndDate.SendKeys(endDateCol);

            AvailableDays.Click();

            AvailableDayStartTime.Click();
            string startTimeCol = ExcelReader.ReadData(1, "Start time");
            AvailableDayStartTime.SendKeys(startTimeCol);

           
            AvailableDayEndTime.Click();
            string endTimeCol = ExcelReader.ReadData(1, "End time");
            AvailableDayEndTime.SendKeys(endTimeCol);
            
            SkillTrade.Click();


            Thread.Sleep(2000);
            SkillExchangeTag.Click();
            string skillExchangeCol = ExcelReader.ReadData(1, "Skill Exchange");
            SkillExchangeTag.SendKeys(skillExchangeCol);
            SkillExchangeTag.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            CommonDriverObj.takeScreenShot(driver);

            //Uploadfile using AutoIt 
            Uploadfile.Click();
            AutoItX3 autoItObj = new AutoItX3();
            autoItObj.WinActivate("Open");
            Thread.Sleep(1000);
            autoItObj.Send("C:\\Users\\karis\\OneDrive\\Desktop\\Karishma.txt");
            Thread.Sleep(1000);
            autoItObj.Send("{ENTER}"); 

            ActiveButton.Click();
            
            SaveButton.Click();

            Thread.Sleep(2000);
            CommonDriverObj.takeScreenShot(driver);

            //Check if the Share Skill record was created.
            IWebElement ShareSkillRecord = driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]"));
            Assert.That(ShareSkillRecord.Text == "Test Karishma 1", "Skill is not the Same");

        }
    }
          
}
