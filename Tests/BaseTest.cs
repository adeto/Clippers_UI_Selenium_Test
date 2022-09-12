using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Clippers_UI_Selenium_Test.Tests.Tests
{
    public class BaseTest
    {
        protected IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [OneTimeTearDown]
        public void ShutDown()
        {
            driver.Quit();
        }
    }
}
