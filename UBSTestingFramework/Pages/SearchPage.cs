using OpenQA.Selenium;
using UBSTestingFramework.Core;
using UBSTestingFramework.Pages.Abstracts;

namespace UBSTestingFramework.Pages
{
    public class SearchPage : BasePage
    {
        private IWebElement Header => FindElement(By.XPath("//span[@class='header__hlTitle' and contains(text(),'Search')]"));

        public SearchPage(Driver driver) : base(driver)
        {
        }

        public override bool IsOnPage()
        {
            return Header != null;
        }
    }
}
