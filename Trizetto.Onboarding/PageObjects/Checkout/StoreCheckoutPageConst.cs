using OpenQA.Selenium;

namespace Trizetto.Onboarding.PageObjects.Checkout
{
    internal static class StoreCheckoutPageConst
    {
        public static By ProceedToCheckoutButton = By.XPath("////*[@id=\"layer_cart\"]/div[1]/div[2]/div[4]/a/span/text()");

        public static By CartTitle = By.ClassName("navigation_page");

        public static By DeliveryAddress = By.XPath("//*[@id=\"center_column\"]/div[3]/div[1]/ul");

        public static By InvoiceAddress = By.XPath("//*[@id=\"center_column\"]/div[3]/div[2]/ul");
    }
}