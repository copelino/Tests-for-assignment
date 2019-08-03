using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanityTests
{
    public partial class MainFunction
    {
        IWebDriver driver;
        int i = 0;

        [SetUp]
        public void DriverStart()
        {
            driver = new ChromeDriver();
        }

        [TearDown]
        public void CloseDriver()
        {
            driver.Quit();
        }
    }
}
