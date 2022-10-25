using CATS.Framework.Actions;
using CATS.Framework.Logging;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace Trizetto.Onboarding.PageObjects.MyAccount
{
    internal class MyAccountPage
    {
        private static CATSLogger _log = new CATSLogger();
        private IWebDriver driver;
        private CATSElementActions elementActions;

        public MyAccountPage(IWebDriver driver)
        {
            elementActions = new CATSElementActions(driver);
            this.driver = driver;
        }

        /// <summary>
        /// Checks returns the user name located on the screen
        /// </summary>
        /// <param name="userFirstName"></param>
        /// <param name="userLastName"></param>
        /// <returns></returns>
        internal string CheckUserName()
        {
            try
            {
                var FullUserName = elementActions.GetText(MyAccountPageConst.UserNameLocator);

                _log.Info("Found the full name and compared it to the test data name:" + FullUserName);

                return FullUserName;
            }
            catch (Exception ex)
            {
                _log.Info(ex.Message);
                Assert.Fail("Failed to find the user name element: " + ex.Message);
                return null;
            }
        }
    }
}