using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanityTests
{
    public partial class MainFunction
    {
        [Test]
        public void BlankLogin()
        {
            string stepName = "";
            string testName = "BlankLogin";
            string date = DateTimeNow.GetFormatedDateNow(testName);

            try
            {
                //1. Navigate to Humanityy

                stepName = "1. Navigate to Humanity";
                driver.Url = "http://www.humanity.com";
                driver.Manage().Window.Maximize();
                Thread.Sleep(3000);
                LogStatus.LogSuccess(stepName, testName, date);

                //2. Try to login with blank input fields

                stepName = "2. Try to login with blank input fields";
                driver.FindElement(By.CssSelector(".nav-trial>a:nth-child(3)")).Click();
                driver.FindElement(By.ClassName("btn")).Click();
                Thread.Sleep(5000);
                LogStatus.LogSuccess(stepName, testName, date);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                LogStatus.LogError(stepName, testName, date, msg);
                Assert.Fail(msg);
            }
        }
    }
}

