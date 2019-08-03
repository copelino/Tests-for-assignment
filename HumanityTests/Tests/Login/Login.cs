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
        public void Login()
        {
            string stepName = "";
            string testName = "Login Forms";
            string date = DateTimeNow.GetFormatedDateNow(testName);

            try
            {
                //1. Navigate to Humanity

                stepName = "1. Navigate to Humanity";
                driver.Url = "http://www.humanity.com";
                driver.Manage().Window.Maximize();
                Thread.Sleep(3000);
                LogStatus.LogSuccess(stepName, testName, date);

                //2. Try to login with invalid credentials

                stepName = "2. Try to login with invalid credentials";
                driver.FindElement(By.CssSelector(".nav-trial>a:nth-child(3)")).Click();
                driver.FindElement(By.Id("email")).SendKeys("invalid@mail.com");
                driver.FindElement(By.Id("password")).SendKeys("InvalidPassword");
                driver.FindElement(By.ClassName("btn")).Click();
                Thread.Sleep(2000);
                LogStatus.LogSuccess(stepName, testName, date);
                
           

                driver.FindElement(By.Id("email")).Clear();
                driver.FindElement(By.Id("password")).Clear();
                Thread.Sleep(2000);

                //3. Login with valid credentials and verify that profile name is correct

                stepName = "3. Login with valid credentials and verify that profile name is correct";
                driver.FindElement(By.Id("email")).SendKeys("testnimail@yopmail.com");
                driver.FindElement(By.Id("password")).SendKeys("Testiranje1");
                driver.FindElement(By.ClassName("btn")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.CssSelector("._navBottom>i")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.CssSelector("#userm>div>a:nth-child(3)")).Click();
                Thread.Sleep(3000);
                string name = driver.FindElement(By.ClassName("EmployeeName")).Text;
                string expectedName = "Petar Radosavljevic";
                Assert.AreEqual(name.ToLower(), expectedName.ToLower());
                Thread.Sleep(2000);
                LogStatus.LogSuccess(stepName, testName, date);

                //4. Logout

                stepName = "4. Logout";
                driver.FindElement(By.CssSelector("._navBottom>i")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.CssSelector("#userm>div>div:nth-child(15)>a")).Click();
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



