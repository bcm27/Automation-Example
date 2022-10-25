using CATS.Framework.Actions;
using CATS.Framework.Logging;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using Trizetto.Onboarding.PageObjects.Product;
using Trizetto.Onboarding.PageObjects.SignInRegister;

namespace Trizetto.Onboarding.PageObjects.Home
{
    internal class StoreHomePage
    {
        private string url;
        private static CATSLogger _log = new CATSLogger();
        private IWebDriver driver;
        private CATSElementActions elementActions;

        public StoreHomePage(IWebDriver driver, string url)
        {
            elementActions = new CATSElementActions(driver);

            this.driver = driver;
            this.url = url;

            driver.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Clicks the sign in button that exists on the home page of the store website
        /// </summary>
        /// <returns></returns>
        internal StoreSignInRegisterPage ClickSignInButton()
        {
            try
            {
                elementActions.WaitForElementToBeClickable(StoreHomePageConst.SignInButton, 10);
                elementActions.Click(StoreHomePageConst.SignInButton);
                _log.Info("Clicked the login button");
            }
            catch (Exception ex)
            {
                _log.Info(ex.Message);
                Assert.Fail("Failed to click the sign in button: " + ex.Message);
            }

            return new StoreSignInRegisterPage(driver);
        }

        /// <summary>
        /// Clicks the sign out button that exists on the home page of the store website
        /// </summary>
        /// <returns>Returns itself a storehomepage object</returns>
        internal StoreHomePage ClickSignOutButton()
        {
            try
            {
                elementActions.WaitForElementToBeClickable(StoreHomePageConst.SignOutButton, 10);
                elementActions.Click(StoreHomePageConst.SignOutButton);
                _log.Info("Clicked the sign out button");

                return this;
            }
            catch (Exception ex)
            {
                _log.Info(ex.Message);
                Assert.Fail("Failed to click the sign out button: " + ex.Message);
            }

            return this;
        }

        /// <summary>
        /// Clicks the dresses navigation button on the navigation tab without hovering and selecting anything
        /// </summary>
        /// <returns>Returns a new store product page object</returns>
        internal StoreProductPage ClickDressesNavigationButton()
        {
            try
            {
                elementActions.WaitForElementToBeClickable(StoreHomePageConst.DressesNavigationButton, 10);
                elementActions.Click(StoreHomePageConst.DressesNavigationButton);

                _log.Info("Clicked the dress navigation button");

                return new StoreProductPage(driver);
            }
            catch (Exception ex)
            {
                _log.Info("Failed to click the dress navigation button\n" + ex.Message);
            }

            return null;
        }

        /// <summary>
        /// Hovers over the navigation window and clicks on the evening dress drop down selection
        /// </summary>
        /// <returns>Returns a store product page with a driver attached for refreshing the page</returns>
        internal StoreProductPage HoverClickEveningDressesNavigationButton()
        {
            try
            {
                elementActions.HoverAndClick(StoreHomePageConst.DressesNavigationButton,
                    StoreHomePageConst.HoverDressesNavigationButton);

                _log.Info("Clicked the dress navigation button");

                return new StoreProductPage(driver);
            }
            catch (Exception ex)
            {
                _log.Info("Failed to click the dress navigation button\n" + ex.Message);
            }

            return null;
        }
    }
}