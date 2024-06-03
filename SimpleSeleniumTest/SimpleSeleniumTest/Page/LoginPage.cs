using OpenQA.Selenium;

namespace SimpleSeleniumTest.Page
{
    public class LoginPage : BasePage
    {
        private By xpathInputUsername = By.XPath("//input[contains(@name, 'username')]");
        private By xpathInputPassword = By.XPath("//input[@name='password'] | //input[@id='ipassword']");
        private By xpathButtonLogin = By.XPath("//button[contains(.,'Login')]");
        private By xpathErrorMessage = By.XPath("//p[contains(@class, 'oxd-alert-content-text')]");



        public LoginPage(IWebDriver _driver) : base(_driver)
        {
        }

        public void InputUsername(string username)
        {
            driver.FindElement(xpathInputUsername).SendKeys(username);
        }

        public void InputPassword(string password)
        {
            driver.FindElement(xpathInputPassword).SendKeys(password);
        }

        public void ClickLogin()
        {
            driver.FindElement(xpathButtonLogin).Click();
        }
        public void LoginWithUsernameAndPassword(string username, string password)
        {
            InputUsername(username);
            InputPassword(password);
            ClickLogin();
        }
        public string GetErrorMessage()
        {
            return driver.FindElement(xpathErrorMessage).Text;
        }
    }
}
