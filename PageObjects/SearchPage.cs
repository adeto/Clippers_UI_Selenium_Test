using Clippers_UI_Selenium_Test.Constants;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V102.Debugger;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clippers_UI_Selenium_Test.PageObjects
{
    public class SearchPage : BasePage
    {
        public SearchPage(IWebDriver driver) : base(driver)
        {
        }
        public override string PageUrl =>
            "https://clippings.com/search?next=%2F&hierarchicalMenu%5BcategoryList.lvl0%5D=Lighting%2FLight%20Bulbs&page=1&range%5BcurrentPriceInCurrency.GBP%5D%5Bmax%5D=30";

        public IWebElement CurrencyDropDownMenu =>
           driver.FindElement(By.Id("mui-component-select-currency"));

        public IWebElement EuroCurrencyOption =>
          driver.FindElement(By.XPath("//li[@data-value='EUR']"));

        public IWebElement MinFilterInputField =>
         driver.FindElement(By.CssSelector("#currentPriceInCurrency\\.EUR-inputMin"));

        public IWebElement MaxFilterInputField =>
        driver.FindElement(By.CssSelector("#currentPriceInCurrency\\.EUR-inputMax"));

        public IWebElement SearchButtonMinMaxFilter =>
        driver.FindElement(By.XPath("(//button[@class='ais-RangeInput-submit'])[1]"));

        public IWebElement FirstElementPrice =>
        driver.FindElement(By.XPath("(//span[@data-testid='component-price-regular'])[1]"));
        public IWebElement LastElementPrice =>
        driver.FindElement(By.XPath("(//span[@data-testid='component-price-regular'])[21]"));

        public IWebElement ResultsGrid =>
        driver.FindElement(By.Id("hits-grid"));

        public void SelectEuroCurrency()
        {
            CurrencyDropDownMenu.Click();
            EuroCurrencyOption.Click();
            driver.FindElement(By.XPath("(//div[contains(.,'Euro (EUR)')])[8]"));
        }

        public void FilterProductsUsingMinMaxFilter(string minValue, string maxValue)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            MinFilterInputField.SendKeys(minValue);
            MaxFilterInputField.SendKeys(maxValue);
            SearchButtonMinMaxFilter.Click();
            IWebElement enteredMinValue = wait.Until(e => e.FindElement(By.XPath("//input[@id='currentPriceInCurrency.EUR-inputMin'][@value=\"10\"]")));
            IWebElement enteredMaxValue = wait.Until(e => e.FindElement(By.XPath("//input[@id='currentPriceInCurrency.EUR-inputMax'][@value=\"30\"]")));
            IWebElement firstResult = wait.Until(e => e.FindElement(By.XPath("(//div[contains(.,'Totem I 3W LED lightbulb')])[10]")));
        }
    }
}
