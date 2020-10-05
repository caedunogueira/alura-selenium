﻿using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoOfertarLance
    {
        private readonly IWebDriver driver;

        public AoOfertarLance(TestFixture fixture) => driver = fixture.Driver;

        [Fact]
        public void DadoLoginInteressadaDeveAtualizarLanceAtual()
        {
            //arrange
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencheFormulario("fulano@example.org", "123");
            loginPO.SubmeteFormulario();

            var detalhePO = new DetalheLeilaoPO(driver);
            detalhePO.Visitar(1); //em andamento

            //act
            detalhePO.OfertarLance(300);

            //assert
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            var iguais = wait.Until(_ => detalhePO.LanceAtual == 300);

            Assert.True(iguais);
        }
    }
}
