using CATS.Framework.Actions;
using CATS.Framework.Logging;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using Project.Automation.PageObjects.Checkout;

namespace Project.Automation.PageObjects
{
    internal class StoreCheckoutPage
    {
        private static CATSLogger _log = new CATSLogger();
        private IWebDriver driver;
        private CATSElementActions elementActions;

        public StoreCheckoutPage(IWebDriver driver)
        {
            elementActions = new CATSElementActions(driver);
            this.driver = driver;
        }

        /// <summary>
        /// User clicks the proceed to checkout button from the store checkout cart page
        /// </summary>
        /// <returns>Returns a new store checkout page with a driver attached</returns>
        internal StoreCheckoutPage ProceedToCheckOut()
        {
            try
            {
                elementActions.WaitForElementToBeClickable(StoreCheckoutPageConst.ProceedToCheckoutButton, 10);
                elementActions.Click(StoreCheckoutPageConst.ProceedToCheckoutButton);

                _log.Info("Clicked the add to cart button");

                return new StoreCheckoutPage(driver);
            }
            catch (Exception ex)
            {
                _log.Info("Failed to click the add to cart button\n" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Gets the delivery address as a list
        /// </summary>
        /// <returns>Returns a IList<IwebElement></returns>
        internal IList<IWebElement> GetDeliveryAddress()
        {
            return elementActions.GetElementsAsList(StoreCheckoutPageConst.DeliveryAddress);
        }

        /// <summary>
        /// Gets the invoice address as a list
        /// </summary>
        /// <returns>Returns a IList<IWebElement> list with the invoice address</returns>
        internal IList<IWebElement> GetInvoiceAddress()
        {
            return elementActions.GetElementsAsList(StoreCheckoutPageConst.InvoiceAddress);
        }

        /// <summary>
        /// Returns the title of the shopping cart
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        internal string GetCartTitle()
        {
            try
            {
                return elementActions.GetText(StoreCheckoutPageConst.CartTitle);
            }
            catch (Exception ex)
            {
                _log.Info("Failed to find the shopping cart title" + ex.Message);
            }
            return " ";
        }
    }
}