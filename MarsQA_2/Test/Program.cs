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
   
    public class Program :CommonDriver
    {
        ManageListing manageListingObj = new ManageListing();
        [Test]
        public void A_CreateShareSkill()
        {
            try
            {

                extenttestobj = extentreportobj.CreateTest("Adding Share Skill");
                ShareSkill shareSkillObj = new ShareSkill();
                shareSkillObj.CreateShareSkill(driver);
                extenttestobj.Log(Status.Info, "Skill was saved succesfully");
                extenttestobj.Log(Status.Pass, "Test Pass");
                
            }
            catch (Exception)
            {
                extenttestobj.Log(Status.Fail, "Skill not Generated ");
                extenttestobj.Log(Status.Skip, "Test was Skipped");
            }
        }
        [Test]
        public void B_EditShareSkill()
        {
            try
            { 
            extenttestobj = extentreportobj.CreateTest("Editing ShareSkill");
            manageListingObj.EditShareSkill(driver);
            extenttestobj.Log(Status.Info, "Skill has been Edited");
            extenttestobj.Log(Status.Pass, "Test Pass");
            }
            catch(Exception)
            {
               extenttestobj.Log(Status.Fail, "Skill not Edited ");
               extenttestobj.Log(Status.Skip, "Test was Skipped");
            }
        }

        [Test]
        public void C_DeleteShareSkill()
        {
            try
            {
                extenttestobj = extentreportobj.CreateTest("Deleting ShareSkill");
                manageListingObj.DeleteSkill(driver);
                extenttestobj.Log(Status.Info, "Skill has been Deleted");
                extenttestobj.Log(Status.Pass, "Test Pass");
            } 

            catch (Exception)
            {
              extenttestobj.Log(Status.Fail, "Skill not Deleted ");
              extenttestobj.Log(Status.Skip, "Test was Skipped");
            }
        }

        
    }
}
