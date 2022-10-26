using OpenQA.Selenium;

namespace Project.Automation.PageObjects.ProductSelection
{
    internal static class StoreProductPageConst
    {
        public static By EveningDressSelector = By.XPath("//*[@id=\"center_column\"]/ul/li/div/div[1]/div/a[1]/img");

        public static By AddToCartButton = By.XPath("//*[@id=\"center_column\"]/ul/li/div/div[2]/div[2]/a[1]/span");

        public static By ProceedToCheckoutButton = By.XPath("//*[@id=\"layer_cart\"]/div[1]/div[2]/div[4]/a/span");

        public static By DressProduct = By.XPath("//*[@id=\"center_column\"]/ul/li/div/div[1]/div/a[1]/img");
    }
}