using CATS.Framework.Actions;
using CATS.Framework.Categories;
using CATS.Framework.Configuration;
using CATS.Framework.Extensions;
using CATS.Framework.Helpers;
using CATS.Framework.Logging;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using Project.Automation.PageObjects.Home;

namespace Project.Automation.TestClasses
{
    internal class StoreAccountTest : TestHelper
    {
        private static CATSLogger _log = new CATSLogger();

        /// <summary>
        /// Can we even just access the home page? Test that.
        /// </summary>
        [Test, Smoke, Property("TestId", "10001")]
        public void AccessHomePageTest()
        {
            ExecuteTestActionsWithWebdriver((driver) =>
            {
                var url = EnvironmentConfiguration.GetValue("URL");
                new StoreHomePage(driver, url);

                // test that the title of the web pages in the tab header is the same
                Assert.AreEqual("My Store", driver.Title,
                    "Incorrect page: The page titles weren't the same");
            });
        }

        /// <summary>
        /// Next can we access the login page
        /// </summary>
        [Test, Smoke, Property("TestId", "10002")]
        public void AccessLoginPageTest()
        {
            ExecuteTestActionsWithWebdriver((driver) =>
            {
                var url = EnvironmentConfiguration.GetValue("URL");
                var HomePage = new StoreHomePage(driver, url);

                HomePage.ClickSignInButton();

                // test that the title of the web pages in the tab header is the same
                Assert.AreEqual("Login - My Store", driver.Title,
                    "Incorrect page: The page titles weren't the same");
            });
        }

        /// <summary>
        /// Can we access the created account page
        /// </summary>
        [Test, Smoke, Property("TestId", "10003")]
        public void AccessCreateAccountPageTest()
        {
            ExecuteTestActionsWithWebdriver((driver) =>
            {
                var Url = EnvironmentConfiguration.GetValue("URL");
                var HomePage = new StoreHomePage(driver, Url);

                var RegisterEmailPage = HomePage.ClickSignInButton();

                var Data = DataProviderAccess.GetTestData();
                var Email = AddRandomTextToEmail(Data.GetString("testEmail"));

                RegisterEmailPage.EnterEmail(Email);
                RegisterEmailPage.ClickRegisterButton();

                // test that the title of the web pages in the tab header is the same
                Assert.AreEqual("Login - My Store", driver.Title,
                    "Incorrect page: The page titles weren't the same");
            });
        }

        /// <summary>
        /// Tests that an account can be successfully created with test JSON data
        /// </summary>
        [Test, Smoke, Property("TestId", "10004")]
        public void CreateAccountTest()
        {
            ExecuteTestActionsWithWebdriver((driver) =>
            {
                try
                {
                    var Url = EnvironmentConfiguration.GetValue("URL");
                    var HomePage = new StoreHomePage(driver, Url);

                    var Data = DataProviderAccess.GetTestData();

                    var Email = AddRandomTextToEmail(Data.GetString("testEmail1"));

                    var RegisterEmailPage = HomePage.ClickSignInButton();

                    RegisterEmailPage.EnterEmail(Email);
                    var CreateAccountPage = RegisterEmailPage.ClickRegisterButton();

                    // Populate all the account fields

                    var UserFirstName = Data.GetString("userFirstName");
                    var UserLastName = Data.GetString("userLastName");

                    CreateAccountPage.PopulateCustomerFields(
                        UserFirstName,
                        UserLastName,
                        Data.GetString("customerPassword"));


                    CreateAccountPage.PopulateUserFields(
                        Data.GetString("userFirstName"),
                        Data.GetString("userLastName"),
                        Data.GetString("userAddressLine1"),
                        Data.GetString("userCity"),
                        Data.GetString("userState"),
                        Data.GetString("userZipCode"),
                        Data.GetString("userMobilePhone"));

                    var DashboardAccountPage = CreateAccountPage.ClickRegisterButton();

                    var result = DashboardAccountPage.CheckUserName();

                    // Verify that the first and last names of the registered user are what we entered
                    Assert.AreEqual(result, UserFirstName + " " + UserLastName,
                        "Incorrect page: The user names were not the same");
                }
                catch (Exception e)
                {
                    Console.Write(e);
                    _log.Info("System failed to find the given file" + e);
                }
            });
        }

        /// <summary>
        /// Click on the dress navigation button not the hover dress selection
        /// </summary>
        [Test, Smoke, Property("TestId", "10008")]
        public void DressesNavigationTest()
        {
            ExecuteTestActionsWithWebdriver((driver) =>
            {
                var url = EnvironmentConfiguration.GetValue("URL");
                var HomePage = new StoreHomePage(driver, url);

                HomePage.ClickDressesNavigationButton();

                // test that the title of the web pages in the tab header is the same
                Assert.AreEqual("Dresses - My Store", driver.Title,
                    "Incorrect page: The page titles weren't the same");
            });
        }

        /// <summary>
        /// Hover and then click on the dress navigation button
        /// </summary>
        [Test, Smoke, Property("TestId", "10009")]
        public void DressesHoverNavigationTest()
        {
            ExecuteTestActionsWithWebdriver((driver) =>
            {
                var url = EnvironmentConfiguration.GetValue("URL");
                var HomePage = new StoreHomePage(driver, url);

                HomePage.HoverClickEveningDressesNavigationButton();

                // test that the title of the web pages in the tab header is the same
                Assert.AreEqual("Evening Dresses - My Store", driver.Title,
                    "Incorrect page: The page titles weren't the same");
            });
        }

        /// <summary>
        /// Can we navigate to the cart after adding a dress to it
        /// </summary>
        [Test, Smoke, Property("TestId", "10010")]
        public void AddEveningDressToCartTest()
        {
            ExecuteTestActionsWithWebdriver((driver) =>
            {
                var url = EnvironmentConfiguration.GetValue("URL");
                var HomePage = new StoreHomePage(driver, url);

                var ProductDressCategoryPage = HomePage.HoverClickEveningDressesNavigationButton();

                ProductDressCategoryPage.ClickAddToCartButton();

                var ViewCheckoutCart = ProductDressCategoryPage.ProceedToCheckoutButton();

                var CartTitle = ViewCheckoutCart.GetCartTitle();

                Assert.AreEqual("Your shopping cart", CartTitle, "Failed; you are not at the shopping cart page");
            });
        }

        /// <summary>
        /// Create  an account from the existing test data and then add an evening dress to it
        /// </summary>
        [Test, Smoke, Property("TestId", "10011")]
        public void CreateAccountAndAddEveningDressToCartTest()
        {
            ExecuteTestActionsWithWebdriver((driver) =>
            {
                var Url = EnvironmentConfiguration.GetValue("URL");
                var HomePage = new StoreHomePage(driver, Url);

                var Data = DataProviderAccess.GetTestData();

                var Email = AddRandomTextToEmail(Data.GetString("testEmail1"));

                var RegisterEmailPage = HomePage.ClickSignInButton();

                RegisterEmailPage.EnterEmail(Email);
                var CreateAccountPage = RegisterEmailPage.ClickRegisterButton();

                var UserFirstName = Data.GetString("userFirstName");
                var UserLastName = Data.GetString("userLastName");

                CreateAccountPage.PopulateCustomerFields(
                    UserFirstName,
                    UserLastName,
                    Data.GetString("customerPassword"));


                CreateAccountPage.PopulateUserFields(
                    Data.GetString("userFirstName"),
                    Data.GetString("userLastName"),
                    Data.GetString("userAddressLine1"),
                    Data.GetString("userCity"),
                    Data.GetString("userState"),
                    Data.GetString("userZipCode"),
                    Data.GetString("userMobilePhone"));

                CreateAccountPage.ClickRegisterButton();

                // finish registering account

                var ProductDressCategoryPage = HomePage.HoverClickEveningDressesNavigationButton();

                ProductDressCategoryPage.ClickAddToCartButton();

                var ViewCheckoutCart = ProductDressCategoryPage.ProceedToCheckoutButton();

                var DeliveryAddress = ViewCheckoutCart.GetDeliveryAddress().ToString();
                var InvoiceAddress = ViewCheckoutCart.GetInvoiceAddress().ToString();

                // According to our test cases comparing the delivery address and invoice address will prove this test passed
                Assert.AreEqual(DeliveryAddress, InvoiceAddress, "The two compared addresses are not equal and the test case fails");
            });
        }

        /// <summary>
        /// Adds some random 5 character so the beginning of the email to avoid duplication errors during testing
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        private string AddRandomTextToEmail(string v)
        {
            return DataRandomizer.CreateString(CATS.Framework.Helpers.Type.AlphaUpper, 5) + v;
        }
    }

}