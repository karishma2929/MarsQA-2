


using MarsQA_2.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
    
     public void LoginSteps (IWebDriver driver)
     {
       //Lauch the Website Portal
        driver.Navigate().GoToUrl("http://localhost:5000");
         try
         {
           
           // Click on Sign In Button
             driver.FindElement(By.XPath("//*[@id='home']/div/div/div[1]/div/a")).Click();
          // get the excel data reader
         // Identify Username text box and enter user nanem
           driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input")).SendKeys("karishmanaik78@gmail.com");
         //Identify Passwor and enetr passwrod
           driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input")).SendKeys("123123");
         // Click login button.
           driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button")).Click();
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
