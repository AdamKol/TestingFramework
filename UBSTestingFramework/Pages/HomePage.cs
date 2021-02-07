using OpenQA.Selenium;
using UBSTestingFramework.Core;
using UBSTestingFramework.Pages.Abstracts;

namespace UBSTestingFramework.Pages
{
    public class HomePage : BasePage
    {
        private IWebElement Header => FindElement(By.XPath("//span[@class='header__hlTitle' and contains(text(),'Global')]"));
        private IWebElement AllowCookiesButton => FindElement(By.ClassName("privacysettings__allowAllCookies"));
        private IWebElement CareersMenu => FindElement(By.XPath("//button[contains(text(),'Careers')]"));
        private IWebElement CareersMenuSearchJobsItem => FindElement(By.XPath("//a[contains(text(),'Search jobs')]"));
        private IWebElement ShowSearchFieldButton => FindElement(By.XPath("//button[contains(@class, 'headerSearch__toggle')]"));
        private IWebElement SearchboxInput => FindElement(By.XPath("//input[@id='searchbox']"));
        private IWebElement SearchButton => FindElement(By.XPath("//button[@class='search-button']"));

        public HomePage(Driver driver) : base(driver)
        {
            if(AllowCookiesButton != null)
            {
                AllowCookiesButton.Click();
            }
        }

        public override bool IsOnPage()
        {
            return Header != null;
        }

        public void NavigateToSearchJobsPage()
        {
            if (CareersMenu != null) CareersMenu.Click();
            if (CareersMenuSearchJobsItem != null) CareersMenuSearchJobsItem.Click();
        }

        public void SearchForText(string text)
        {
            if (ShowSearchFieldButton != null) ShowSearchFieldButton.Click();
            if (SearchboxInput != null) SearchboxInput.SendKeys(text);
            if (SearchButton != null) SearchButton.Click();
        }
    }
}
