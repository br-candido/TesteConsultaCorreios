using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;


namespace ConsultaCorreios.StepDefinitions
{
    [Binding]
    public sealed class ConsultaCorreios
    {
        string test_url = "https://correios.com.br/";
        IWebDriver driver;

        private readonly ScenarioContext context;

        public ConsultaCorreios(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [Given(@"that I am on the Correios website")]
        public void GivenThatIAmOnTheCorreiosWebsite()
        {
            driver = new ChromeDriver();
            driver.Url = test_url;
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
        }

        [Then(@"find the text box to enter the CEP ""(.*)""")]
        public void ThenFindTheTextBoxToEnterTheCep(string cep)
        {
            IWebElement CEPField = driver.FindElement(By.Name("relaxation"));
            CEPField.SendKeys(cep);
            CEPField.Submit();
        }


        [Then(@"switch to the package search tab")]
        public void ThenSwitchToThePackageSearchTab()
        {
            IWebElement CEPField = driver.FindElement(By.Name("objetos"));
            CEPField.Submit();
            ThenEnterTheResultTab();
        }

        [Then(@"find the text box to enter the Package ID ""(.*)""")]
        public void ThenFindTheTextBoxToEnterThePackageId(string packId)
        {
            IWebElement cepField = driver.FindElement(By.Name("objeto"));
            cepField.SendKeys(packId);
        }

        [Then(@"wait for the user to solve the captcha")]

        public void ThenWaitForTheUserToSolveTheCaptcha()
        {
            IWebElement captchaBox = driver.FindElement(By.Name("captcha"));
            captchaBox.Click();
            Thread.Sleep(15000);
            captchaBox.SendKeys(Keys.Enter);

        }

        [Then(@"validate if the package is non-existent")]

        public void ValidateIfThePackageIsNonExisting()
        {
            Thread.Sleep(1000);
            IWebElement alertPopUp = driver.FindElement(By.CssSelector("div.msg"));
            Assert.IsTrue(alertPopUp.Text == "Objeto não encontrado na base de dados dos Correios.", "The Package Id is Valid");
        }

        [Then(@"enter the result tab")]

        public void ThenEnterTheResultTab()
        {
            string currentTab = driver.CurrentWindowHandle;

            foreach (string tab in driver.WindowHandles)
            {
                if (tab != currentTab)
                {
                    driver.SwitchTo().Window(tab);
                    break;
                }
            }
        }

        [Then(@"check if the CEP doesn't exist")]

        public void ThenCheckIfTheCepDoesntExist()
        {
            IWebElement searchResult = driver.FindElement(By.Id("mensagem-resultado-alerta"));
            Assert.IsTrue(searchResult != null);

        }

        [Then(@"check if the CEP matches the location ""(.*)""")]
        public void ThenCheckIfTheCepMatchesTheLocation(string location)
        {
            IWebElement streetName = driver.FindElement(By.XPath("//*[@id=\"resultado-DNEC\"]/tbody/tr/td[1]"));
            IWebElement cityState = driver.FindElement(By.XPath("//*[@id=\"resultado-DNEC\"]/tbody/tr/td[3]"));
            string simpleStreetName = streetName.Text.Split(" -")[0];

            
            Assert.IsTrue($"{simpleStreetName}, {cityState.Text}" == location, $"The given CEP exists ({$"{simpleStreetName}, {cityState.Text}"}) but doesn't match the given location: {location}");

        }

        [Then(@"close the browser instance")]
        public void ThenCloseTheBrowserInstance()
        {
            driver.Quit();
        }
    }
}