using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Alura.LeilaoOnline.Selenium.Helpers
{
    public class SelectMaterialize
    {
        private IWebDriver driver;
        private IWebElement selectWrapper;
        private IEnumerable<IWebElement> opcoes;

        public SelectMaterialize(IWebDriver driver, By locatorSelectWrapper)
        {
            this.driver = driver;
            selectWrapper = driver.FindElement(locatorSelectWrapper);
            opcoes = selectWrapper.FindElements(By.CssSelector("li>span"));
        }

        public IEnumerable<IWebElement> Options => opcoes;

        private void OpenWrapper()
        {
            var waitDriver = new WebDriverWait(driver, TimeSpan.FromSeconds(7));
            _ = waitDriver.Until(_ => selectWrapper.Displayed && selectWrapper.Enabled);
            selectWrapper.Click();
        }

        private void LoseFocus()
        {
            selectWrapper
                .FindElement(By.TagName("li"))
                .SendKeys(Keys.Tab);
        }

        public void DeselectAll()
        {
            OpenWrapper();
            opcoes.ToList().ForEach(o =>
            {
                o.Click();
            });
            LoseFocus();
        }

        public void SelectByText(string option)
        {
            OpenWrapper();
            opcoes
                .Where(o => o.Text.Contains(option))
                .ToList()
                .ForEach(o =>
                {
                    o.Click();
                });
            LoseFocus();
        }
    }
}
