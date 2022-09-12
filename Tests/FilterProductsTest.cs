using Clippers_UI_Selenium_Test.Constants;
using Clippers_UI_Selenium_Test.PageObjects;
using Clippers_UI_Selenium_Test.Tests.Tests;

namespace Clippers_UI_Selenium_Test.Tests
{
    public class FilterProductsTests : BaseTest
    {
        [Test]
        public void FilterProductsByMinMaxValuePositiveTest()
        {
            var searchPage = new SearchPage(driver);
            searchPage.Open();
            Assert.True(searchPage.IsOpen());
            Assert.AreEqual("Search on | Clippings", searchPage.GetPageTitle());

            searchPage.SelectEuroCurrency();
            searchPage.FilterProductsUsingMinMaxFilter(GlobalTestConstants.minValue, GlobalTestConstants.maxValue);
            Assert.That("ˆ11.59", Is.EqualTo(searchPage.FirstElementPrice.Text));
            Assert.That("ˆ26.66", Is.EqualTo(searchPage.LastElementPrice.Text));
        }
    }
}