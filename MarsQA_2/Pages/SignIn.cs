
using MarsQA_2.Excel_Data_Reader;
using MarsQA_2.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsQA_2.Pages
{
   
    internal class SignIn
    {
        [FindsBy(How = How.XPath, Using = "//*[@id='home']/div/div/div[1]/div/a")] IWebElement SignInButton;
        [FindsBy(How =How.XPath, Using = "/html/body/div[2]/div/div/div[1]/div/div[1]/input")] IWebElement emailTextBox;
        [FindsBy(How =How.XPath,Using = "/html/body/div[2]/div/div/div[1]/div/div[2]/input")] IWebElement passwordTextbox;
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div/div[1]/div/div[4]/button")] IWebElement LoginButton;
        
        
        public void LoginSteps (IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
         
            //Lauch the Website Portal
            driver.Navigate().GoToUrl("http://localhost:5000");
          
            try
            {
                SignInButton.Click();

                string userName = ExcelReader.ReadData(1, "UserName");
                emailTextBox.SendKeys(userName);

                string password = ExcelReader.ReadData(1, "Password");
                passwordTextbox.SendKeys(password);

                LoginButton.Click();
                Thread.Sleep(2000);
        

            }

              catch (Exception)
            {
              Console.WriteLine("Login Failed");
              throw;
            }
        }
        
    }
}
