using OpenQA.Selenium;

namespace Project.Automation.PageObjects.Home
{
    internal static class StoreHomePageConst
    {
        public static By SignInButton = By.ClassName("login");

        public static By DressesNavigationButton = By.XPath("//*[@id=\"block_top_menu\"]/ul/li[2]/a");

        public static By SignOutButton = By.ClassName("signout");

        public static By HoverDressesNavigationButton = By.XPath("//*[@id=\"block_top_menu\"]/ul/li[2]/ul/li[2]/a");
    }
}