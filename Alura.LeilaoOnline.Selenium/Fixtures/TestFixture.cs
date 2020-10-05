using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.Fixtures
{
    public class TestFixture : IDisposable
    {
        public IWebDriver Driver { get; private set; }

        //Setup
        public TestFixture()
        {
            var chromeOptions = new ChromeOptions();

            chromeOptions.AddArgument("--window-size=1920,1080");
            
            Driver = new ChromeDriver(TestHelper.PastaDoExecutavel, chromeOptions);
            
        }

        //TearDown
        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
