using CATS.Framework.Actions;
using CATS.Framework.Logging;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using Trizetto.Onboarding.PageObjects.MyAccount;

namespace Trizetto.Onboarding.PageObjects.Register
{
    internal class StoreRegisterPage
    {
        private static CATSLogger _log = new CATSLogger();
        private IWebDriver driver;
        private CATSElementActions elementActions;

        public StoreRegisterPage(OpenQA.Selenium.IWebDriver driver)
        {
            elementActions = new CATSElementActions(driver);

            this.driver = driver;
        }

        /// <summary>
        /// A function that will populate a text by the parameterized locator with the given input string
        /// </summary>
        /// <param name="Locator"></param>
        /// <param name="Timeout"></param>
        /// <param name="InputValue"></param>
        public void AddTextByLocator(By Locator, int Timeout, string InputValue)
        {
            elementActions.WaitForElementToBeDisplayed(Locator, Timeout);
            elementActions.Type(Locator, InputValue);

            _log.Info(Locator + " " + InputValue +
                "entered for the register button on the sign in or register page");
        }

        /// <summary>
        /// Populates the text boxes for the customer fields at the top of the screen.
        /// </summary>
        /// <param name="customerFirstName"></param>
        /// <param name="customerLastName"></param>
        /// <param name="customerPassword"></param>
        /// <exception cref="NotImplementedException"></exception>
        internal void PopulateCustomerFields(string customerFirstName, string customerLastName, string customerPassword)
        {
            int TimeOutValue = 10;

            try
            {
                AddTextByLocator(StoreRegisterPageConst.CustomerFirstNameTextField, TimeOutValue, customerFirstName);
                AddTextByLocator(StoreRegisterPageConst.CustomerLastNameTextField, TimeOutValue, customerLastName);
                AddTextByLocator(StoreRegisterPageConst.PasswordTextField, TimeOutValue, customerPassword);
            }
            catch (Exception ex)
            {
                _log.Info("Account already exists: " + ex.Message);
                Assert.Fail();
            }
        }

        /// <summary>
        /// Populates the text boxes for the customer fields at the top of the screen.
        /// </summary>
        /// <param name="userFirstName"></param>
        /// <param name="userLastName"></param>
        /// <param name="userAddressLine1"></param>
        /// <param name="userCity"></param>
        /// <param name="userState"></param>
        /// <param name="userZipCode"></param>
        /// <param name="userMobilePhone"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        internal void PopulateUserFields(string userFirstName, string userLastName, string userAddressLine1, string userCity, string userState, string userZipCode, string userMobilePhone)
        {
            int TimeOutValue = 10;

            try
            {
                // We don't actually need these as they are added automatically to the text fields.
                // However I will leave them in for posterity

                //AddTextByLocator(StoreRegisterPageConst.UserFirstName, TimeOutValue, userFirstName);
                //AddTextByLocator(StoreRegisterPageConst.UserLastName, TimeOutValue, userLastName);

                AddTextByLocator(StoreRegisterPageConst.AddressLineOne, TimeOutValue, userAddressLine1);

                AddTextByLocator(StoreRegisterPageConst.AddressCity, TimeOutValue, userCity);

                elementActions.SelectDropdownByText(StoreRegisterPageConst.AddressStateDropDown, userState);

                AddTextByLocator(StoreRegisterPageConst.AddressPostCode, TimeOutValue, userZipCode);
                AddTextByLocator(StoreRegisterPageConst.PhoneMobile, TimeOutValue, userMobilePhone);
            }
            catch (Exception ex)
            {
                _log.Info("Failed to enter the user data: " + ex.Message);
                Assert.Fail();
            }
        }

        /// <summary>
        /// Clicks the register user button on the new account details page
        /// </summary>
        /// <returns></returns>
        internal MyAccountPage ClickRegisterButton()
        {
            try
            {
                elementActions.WaitForElementToBeClickable(StoreRegisterPageConst.RegisterButton, 10);
                elementActions.Click(StoreRegisterPageConst.RegisterButton);
                _log.Info("Clicked the register button");
            }
            catch (Exception ex)
            {
                _log.Info(ex.Message);
                Assert.Fail("Failed to click the register button: " + ex.Message);
            }

            return new MyAccountPage(driver);
        }
    }
}