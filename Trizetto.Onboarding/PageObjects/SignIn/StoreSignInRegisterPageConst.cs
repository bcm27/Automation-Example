using OpenQA.Selenium;

namespace Project.Automation.PageObjects.SignIn
{
    internal static class StoreSignInRegisterPageConst
    {
        public static By SignInButton = By.Id("SubmitLogin");

        public static By SignInEmail = By.Id("email");

        public static By SignInPassword = By.Id("passwrd");

        public static By CreateAccountButton = By.Id("SubmitCreate");

        public static By CreateAccountEmail = By.Id("email_create");
    }
}