using CATS.Framework.Actions;
using CATS.Framework.Logging;
using OpenQA.Selenium;
using System;
using Project.Automation.PageObjects.ProductSelection;

namespace Project.Automation.PageObjects.Product
{
    internal class StoreProductPage
    {
        private static CATSLogger _log = new CATSLogger();
        private IWebDriver driver;
        private CATSElementActions elementActions;

        public StoreProductPage(IWebDriver driver)
        {
            elementActions = new CATSElementActions(driver);
            this.driver = driver;
        }

        /// <summary>
        /// Clicks the add to cart button
        /// </summary>
        internal void ClickAddToCartButton()
        {
            try
            {
                elementActions.HoverAndClick(StoreProductPageConst.DressProduct, StoreProductPageConst.AddToCartButton);

                _log.Info("Clicked the add to cart button");
            }
            catch (Exception ex)
            {
                _log.Info("Failed to click the add to cart button\n" + ex.Message);
            }
        }

        /// <summary>
        /// clicks the checkout button
        /// </summary>
        /// <returns>returns a store checkout page object</returns>
        internal StoreCheckoutPage ProceedToCheckoutButton()
        {
            try
            {
                elementActions.WaitForElementToBeClickable(StoreProductPageConst.ProceedToCheckoutButton, 10);
                elementActions.Click(StoreProductPageConst.ProceedToCheckoutButton);

                _log.Info("Clicked the Proceed to Checkout Button");

                return new StoreCheckoutPage(driver);
            }
            catch (Exception ex)
            {
                _log.Info("Failed to click the Proceed to Checkout Button\n" + ex.Message);
            }

            return null;
        }
    }
}