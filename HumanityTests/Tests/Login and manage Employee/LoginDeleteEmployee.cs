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
        public void LoginDeleteEmployee()
        {
            string stepName = "";
            string testName = "LoginDeleteEmployee";
            string date = DateTimeNow.GetFormatedDateNow(testName);

            try
            {
                //1. Navigate to Humanity

                stepName = "1. Navigate to Humanity";
                driver.Url = "http://www.humanity.com";
                driver.Manage().Window.Maximize();
                Thread.Sleep(3000);
                LogStatus.LogSuccess(stepName, testName, date);

                //2. Login with valid credentials

                stepName = "2. Login with valid credentials";
                driver.FindElement(By.CssSelector(".nav-trial>a:nth-child(3)")).Click();
                driver.FindElement(By.Id("email")).SendKeys("testnimail@yopmail.com");
                driver.FindElement(By.Id("password")).SendKeys("Testiranje1");
                driver.FindElement(By.ClassName("btn")).Click();
                Thread.Sleep(10000);
                LogStatus.LogSuccess(stepName, testName, date);

                // 3. Clock in and add note

                stepName = "3. Clock in";
                driver.FindElement(By.CssSelector("#topMenu>li:nth-child(3)")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("tc_tl_ci")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("tc_tl_no")).SendKeys("Dont forget to add new Employee");
                Thread.Sleep(2000);
                driver.FindElement(By.Id("tc_tl_no_a")).Click();
                Thread.Sleep(2000);
                LogStatus.LogSuccess(stepName, testName, date);

                //4. Navigate to Staff, and delete employee

                stepName = "4. Navigate to Staff, and delete employee";
                driver.FindElement(By.CssSelector("#topMenu>li:nth-child(6)")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.ClassName("j-bulk-check-all")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.ClassName("bulk-edit-button")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.CssSelector(".bulk-management_form>div:nth-child(3)>label>input")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.CssSelector("#_cd_staff>div.right>div>form>button")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.CssSelector("#_cd_staff>div.right>div>div>button")).Click();
                Thread.Sleep(3000);
                driver.SwitchTo().Alert().Accept();
                Thread.Sleep(3000);
                LogStatus.LogSuccess(stepName, testName, date);

                // 5. Add new Employee and test input fields

                stepName = "5. Add new Employee and test input fields";
                driver.FindElement(By.CssSelector("#topMenu>li:nth-child(3)")).Click();
                Thread.Sleep(6000);
                string noteText = driver.FindElement(By.CssSelector("#tc_timeline>li>ul>li:nth-child(4)>div>span>span")).Text;
                string expectedNoteText = "Dont forget to add new Employee";
                Assert.AreEqual(noteText.ToLower(), expectedNoteText.ToLower());
                Thread.Sleep(2000);
                driver.FindElement(By.CssSelector("#topMenu>li:nth-child(6)")).Click();
                Thread.Sleep(5000);
                driver.FindElement(By.Id("act_primary")).Click();
                Thread.Sleep(5000);
                driver.FindElement(By.CssSelector("#_as_container>._add_staff_tb>tbody>tr:nth-child(2)>td:nth-child(2)>input")).SendKeys("Marc");
                Thread.Sleep(2000);
                driver.FindElement(By.CssSelector("#_as_container>._add_staff_tb>tbody>tr:nth-child(2)>td:nth-child(3)>input")).SendKeys("Ruby");
                Thread.Sleep(2000);
                driver.FindElement(By.CssSelector("#_as_container>._add_staff_tb>tbody>tr:nth-child(2)>td:nth-child(4)>input")).SendKeys("new@employee.com");
                Thread.Sleep(3000);
                driver.FindElement(By.CssSelector("#_as_container>._add_staff_tb>tbody>tr:nth-child(9)>td>button")).Click();
                Thread.Sleep(5000);
                driver.FindElement(By.CssSelector("#_as_container>._add_staff_tb>tbody>tr:nth-child(2)>td:nth-child(4)>input")).Clear();
                Thread.Sleep(3000);
                driver.FindElement(By.CssSelector("#_as_container>._add_staff_tb>tbody>tr:nth-child(2)>td:nth-child(4)>input")).SendKeys("Marc@Ruby.com");
                Thread.Sleep(3000);
                driver.FindElement(By.CssSelector("#_as_container>._add_staff_tb>tbody>tr:nth-child(9)>td>button")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.CssSelector("#_as_container>._add_staff_tb>tbody>tr:nth-child(2)>td:nth-child(4)>input")).Clear();
                Thread.Sleep(3000);
                driver.FindElement(By.CssSelector("#_as_container>._add_staff_tb>tbody>tr:nth-child(2)>td:nth-child(3)>input")).SendKeys("Ruby");
                Thread.Sleep(2000);
                driver.FindElement(By.CssSelector("#_as_container>._add_staff_tb>tbody>tr:nth-child(9)>td>button")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.CssSelector("#_as_container>._add_staff_tb>tbody>tr:nth-child(2)>td:nth-child(3)>input")).Clear();
                Thread.Sleep(3000); 
                driver.FindElement(By.CssSelector("#_as_container>._add_staff_tb>tbody>tr:nth-child(2)>td:nth-child(2)>input")).SendKeys("Marc");
                Thread.Sleep(2000);
                driver.FindElement(By.CssSelector("#_as_container>._add_staff_tb>tbody>tr:nth-child(2)>td:nth-child(3)>input")).SendKeys("Ruby");
                Thread.Sleep(2000);
                driver.FindElement(By.CssSelector("#_as_container>._add_staff_tb>tbody>tr:nth-child(2)>td:nth-child(4)>input")).SendKeys("Marc@.Ruby.com");
                Thread.Sleep(3000);
                driver.FindElement(By.CssSelector("#_as_container>._add_staff_tb>tbody>tr:nth-child(9)>td>button")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.CssSelector("#_as_container>._add_staff_tb>tbody>tr:nth-child(2)>td:nth-child(4)>input")).Clear();
                Thread.Sleep(3000);
                driver.FindElement(By.CssSelector("#_as_container>._add_staff_tb>tbody>tr:nth-child(2)>td:nth-child(4)>input")).SendKeys("Marc@Ruby.com");
                Thread.Sleep(3000);
                driver.FindElement(By.CssSelector("#_as_container>._add_staff_tb>tbody>tr:nth-child(9)>td>button")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.CssSelector("#stafftl_>div")).Click();
                Thread.Sleep(4000);
                LogStatus.LogSuccess(stepName, testName, date);

                //6. Clock out

                stepName = "6. Clock out";
                driver.FindElement(By.CssSelector("#topMenu>li:nth-child(3)")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("tc_tl_co")).Click();
                Thread.Sleep(2000);
                LogStatus.LogSuccess(stepName, testName, date);

                //7. Logout

                stepName = "7. Logout";
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
