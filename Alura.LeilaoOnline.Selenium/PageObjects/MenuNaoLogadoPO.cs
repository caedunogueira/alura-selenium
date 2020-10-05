using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class MenuNaoLogadoPO
    {
        private readonly IWebDriver driver;
        private readonly By byMenuMobile;

        public bool MenuMobileVisivel 
        {
            get
            {
                var elemento = driver.FindElement(byMenuMobile);
                return elemento.Displayed;
            }
        }

        public MenuNaoLogadoPO(IWebDriver driver)
        {
            this.driver = driver;
            byMenuMobile = By.ClassName("sidenav-trigger");
        }
    }
}