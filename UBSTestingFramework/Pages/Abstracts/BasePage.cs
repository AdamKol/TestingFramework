using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using UBSTestingFramework.Core;

namespace UBSTestingFramework.Pages.Abstracts
{
    public abstract class BasePage : IValidatable
    {
        private IWebDriver driverInstance;
        private WebDriverWait wait;    

        public BasePage(Driver driver)
        {
            this.driverInstance = driver.Instance;
            wait = new WebDriverWait(driverInstance, TimeSpan.FromSeconds(30));
        }

        protected IWebElement FindElement(By by)
        {
            if(wait.Until(ExpectedConditions.ElementExists(by)) != null)
            {
                if(wait.Until(ExpectedConditions.ElementIsVisible(by)) != null)
                {
                    return wait.Until(ExpectedConditions.ElementIsVisible(by));
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        protected bool WaitForElementToBeExistent(By by)
        {
            if (wait.Until(ExpectedConditions.ElementExists(by)) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        protected void Refresh()
        {
            driverInstance.Navigate().Refresh();
        }

        public abstract bool IsOnPage();
    }
}