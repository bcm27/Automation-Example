using OpenQA.Selenium;

namespace Trizetto.Onboarding.PageObjects.Register
{
    internal static class StoreRegisterPageConst
    {
        public static By RegisterButton = By.Id("submitAccount");

        public static By CustomerFirstNameTextField = By.Name("customer_firstname");

        public static By CustomerLastNameTextField = By.Name("customer_lastname");

        public static By PasswordTextField = By.Name("passwd");

        public static By DOBDayTextField = By.Id("uniform-days");

        public static By DOBMonthTextField = By.Id("uniform-months");

        public static By DOBYearsTextField = By.Id("uniform-years");

        public static By UserFirstName = By.Id("firstname");

        public static By UserLastName = By.Id("lastname");

        public static By AddressLineOne = By.Id("address1");

        public static By AddressCity = By.Id("city");

        public static By AddressStateSelection = By.Id("uniform-id_state");

        public static By AddressStateDropDown = By.Id("id_state");

        public static By AddressPostCode = By.Id("postcode");

        public static By PhoneMobile = By.Id("phone_mobile");

        public static By ErrorPane = By.CssSelector(@"    -webkit-text-size-adjust: 100%;
    -webkit-tap-highlight-color: rgba(0, 0, 0, 0);
    color: white;
    text-shadow: 1px 1px rgba(0, 0, 0, 0.1);
    box-sizing: border-box;
    padding: 0;
    border: 0;
    font: inherit;
    font-size: 100%;
    vertical-align: baseline;
    margin: 0 0 9px;
    margin-bottom: 0;");
    }
}