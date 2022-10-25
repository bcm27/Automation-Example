using CATS.Framework.Actions;
using CATS.Framework.Logging;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using Trizetto.Onboarding.PageObjects.Register;
using Trizetto.Onboarding.PageObjects.SignIn;

namespace Trizetto.Onboarding.PageObjects.SignInRegister
{
    internal class StoreSignInRegisterPage
    {
        private static CATSLogger _log = new CATSLogger();
        private IWebDriver driver;
        private CATSElementActions elementActions;

        public StoreSignInRegisterPage(OpenQA.Selenium.IWebDriver driver)
        {
            elementActions = new CATSElementActions(driver);

            this.driver = driver;
        }

        /// <summary>
        /// Takes a string as an email and enters it into the email textbox on the sign in page
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        internal StoreSignInRegisterPage EnterEmail(string email)
        {
            try
            {
                elementActions.WaitForElementToBeDisplayed(StoreSignInRegisterPageConst.CreateAccountEmail, 10);
                elementActions.Type(StoreSignInRegisterPageConst.CreateAccountEmail, email);
                _log.Info("Email entered for the register button on the sign in or register page");
            }
            catch (Exception ex)
            {
                _log.Info("Failed to enter the email: " + ex.Message);
                Assert.Fail();
            }

            return this;
        }

        /// <summary>
        /// clicks the register button on the sign in and register page
        /// </summary>
        /// <returns></returns>
        internal StoreRegisterPage ClickRegisterButton()
        {
            try
            {
                elementActions.WaitForElementToBeClickable(StoreSignInRegisterPageConst.CreateAccountButton, 10);
                elementActions.Click(StoreSignInRegisterPageConst.CreateAccountButton);
                _log.Info("Clicked the register button");
            }
            catch (Exception ex)
            {
                _log.Info(ex.Message);
                Assert.Fail("Failed to click the register button: " + ex.Message);
            }

            return new StoreRegisterPage(driver);
        }
    }
}