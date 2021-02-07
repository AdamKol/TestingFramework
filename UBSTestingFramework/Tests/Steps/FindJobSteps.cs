using NUnit.Framework;
using System.Configuration;
using TechTalk.SpecFlow;
using UBSTestingFramework.Core;
using UBSTestingFramework.Pages;

namespace UBSTestingFramework.Tests.Steps
{
    [Binding]
    public class FindJobSteps
    {
        protected static Driver driver { get; set; }
        protected string homeUrl;
        protected HomePage homePage;
        protected SearchJobsPage searchJobsPage;
        protected SearchPage searchPage;

        [BeforeTestRun]
        public static void SetUpTestRun()
        {
            driver = new Driver();
        }

        [AfterTestRun]
        public static void TearDownTestRun()
        {
            driver.Instance.Quit();
        }

        [BeforeScenario]
        public static void SetUpScenario()
        {
            driver.Instance.Manage().Cookies.DeleteAllCookies();
            driver.Instance.Navigate().GoToUrl("about:blank");
        }

        [Given(@"I have homepage url")]
        public void GivenIHaveHomepageUrl()
        {
            homeUrl = ConfigurationManager.AppSettings["baseUrl"];
        }
        
        [When(@"I navigate to homepage url")]
        public void WhenIHaveNavigatedToHomepageUrl()
        {
            driver.Instance.Navigate().GoToUrl(homeUrl);
            homePage = new HomePage(driver);
        }
        
        [Then(@"The homepage will be visible")]
        public void ThenTheHomepageWillBeVisible()
        {
            Assert.That(homePage.IsOnPage() == true);
        }

        [When(@"I navigate to Search Jobs page")]
        public void WhenINavigateToSearchJobsPage()
        {
            homePage.NavigateToSearchJobsPage();
            searchJobsPage = new SearchJobsPage(driver);

        }

        [Then(@"Search Jobs page will be visible")]
        public void ThenSearchJobsPageWillBeVisible()
        {
            Assert.That(searchJobsPage.IsOnPage() == true);
        }

        [When(@"I click on search button and type '(.*)'")]
        public void WhenIClickOnSearchButtonAndType(string p0)
        {
            homePage.SearchForText(p0);
            searchPage = new SearchPage(driver);
        }

        [Then(@"Search Page will be visible")]
        public void ThenSearchPageWillBeVisible()
        {
            Assert.That(searchPage.IsOnPage() == true);
        }
    }
}
