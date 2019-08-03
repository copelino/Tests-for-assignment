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
        public void LoginAddEmployee()
        {
            string stepName = "";
            string testName = "LoginAddEmployee";
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

                // 3. Clock in

                stepName = "3. Clock in";
                driver.FindElement(By.CssSelector("#topMenu>li:nth-child(3)")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("tc_tl_ci")).Click();
                Thread.Sleep(2000);
                LogStatus.LogSuccess(stepName, testName, date);

                //4. Navigate to Staff, add new employee

                stepName = "4. Navigate to Staff, check if Add Employees link is present";
                driver.FindElement(By.CssSelector("#topMenu>li:nth-child(6)")).Click();
                Thread.Sleep(5000);
                string name = driver.FindElement(By.Id("act_primary")).Text;
                string expectedName = "Add Employees";
                Assert.AreEqual(name.ToLower(), expectedName.ToLower());
                Thread.Sleep(2000);
                LogStatus.LogSuccess(stepName, testName, date);

                // 5. Click on Add Employees link and add employee first employee

                stepName = "5. Click on Add Employees link and add employee first employee";
                driver.FindElement(By.Id("act_primary")).Click();
                Thread.Sleep(5000);
                driver.FindElement(By.CssSelector("#_as_container>._add_staff_tb>tbody>tr:nth-child(2)>td:nth-child(2)>input")).SendKeys("Sigmund");
                Thread.Sleep(2000);
                driver.FindElement(By.CssSelector("#_as_container>._add_staff_tb>tbody>tr:nth-child(2)>td:nth-child(3)>input")).SendKeys("Frojd");
                Thread.Sleep(2000);
                driver.FindElement(By.CssSelector("#_as_container>._add_staff_tb>tbody>tr:nth-child(2)>td:nth-child(4)>input")).SendKeys("test@analiza.com");
                Thread.Sleep(2000);

                // 6. Add second employee

                stepName = "6. Add second employee";
                driver.FindElement(By.CssSelector("#_as_container>._add_staff_tb>tbody>tr:nth-child(3)>td:nth-child(2)>input")).SendKeys("Leopold");
                Thread.Sleep(2000);
                driver.FindElement(By.CssSelector("#_as_container>._add_staff_tb>tbody>tr:nth-child(3)>td:nth-child(3)>input")).SendKeys("Sondi");
                Thread.Sleep(2000);
                driver.FindElement(By.CssSelector("#_as_container>._add_staff_tb>tbody>tr:nth-child(3)>td:nth-child(4)>input")).SendKeys("testna@analitika.com");
                Thread.Sleep(2000);
                driver.FindElement(By.CssSelector("#_as_container>._add_staff_tb>tbody>tr:nth-child(9)>td>button")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.CssSelector("#stafftl_>div")).Click();
                Thread.Sleep(3000);
                LogStatus.LogSuccess(stepName, testName, date);

                // 7. Give Supervisor position to first employee

                stepName = " 7. Give Supervisor position to first employee";
                driver.FindElement(By.CssSelector(".employeesList>tbody>tr:nth-child(4)>td>a")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.ClassName("positionList__checkbox")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.CssSelector(".EmployeeTop>a:nth-child(9)")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("acc-type")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.CssSelector("#acc-type>option:nth-child(3)")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("btn-perms")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.CssSelector("#stafftl_>div")).Click();
                Thread.Sleep(3000);
                string Name = driver.FindElement(By.CssSelector(".employeesList>tbody>tr:nth-child(4)>td>a")).Text;
                string ExpectedName = "Sigmund Frojd";
                Assert.AreEqual(Name.ToLower(), ExpectedName.ToLower());
                Thread.Sleep(2000);
                string Position = driver.FindElement(By.CssSelector("#_cd_staff>div.right>div.staff-list>table>tbody>tr:nth-child(4)>td:nth-child(6)")).Text;
                string ExpectedPosition = "Manager";
                Assert.AreEqual(Position.ToLower(), ExpectedPosition.ToLower());
                Thread.Sleep(2000);
                LogStatus.LogSuccess(stepName, testName, date);


                // 8. Clock out

                stepName = "8. Clock out";
                driver.FindElement(By.CssSelector("#topMenu>li:nth-child(3)")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("tc_tl_co")).Click();
                Thread.Sleep(2000);
                LogStatus.LogSuccess(stepName, testName, date);

                //9. Logout

                stepName = "9. Logout";
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
