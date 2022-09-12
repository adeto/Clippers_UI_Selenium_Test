using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clippers_UI_Selenium_Test.PageObjects
{
    public class BasePage
    {
        protected readonly IWebDriver driver;
        public virtual string? PageUrl { get; }

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();

        }

        public void Open()
        {
            driver.Navigate().GoToUrl(this.PageUrl);
        }
        public bool IsOpen()
        {
            return driver.Url == this.PageUrl;
        }
        public string GetPageTitle()
        {
            return driver.Title;
        }

    }
}
