
using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class DetalheLeilaoPO
    {
        private readonly IWebDriver driver;
        private readonly By byInputValor;
        private readonly By byBotaoOfertar;
        private readonly By byLanceAtual;

        public double LanceAtual 
        { 
            get
            {
                var valorTexto = driver.FindElement(byLanceAtual).Text;
                var valor = double.Parse(valorTexto, System.Globalization.NumberStyles.Currency);
                return valor;
            }
        }

        public DetalheLeilaoPO(IWebDriver driver)
        {
            this.driver = driver;
            byInputValor = By.Id("Valor");
            byBotaoOfertar = By.Id("btnDarLance");
            byLanceAtual = By.Id("lanceAtual");
        }

        public void Visitar(int idLeilao) =>
            driver.Navigate().GoToUrl($"http://localhost:5000/Home/Detalhes/{idLeilao}");

        public void OfertarLance(double valor)
        {
            driver.FindElement(byInputValor).SendKeys(valor.ToString());
            driver.FindElement(byBotaoOfertar).Click();
        }
    }
}
