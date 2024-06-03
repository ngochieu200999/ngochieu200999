using OpenQA.Selenium;

namespace SimpleSeleniumTest.Page
{
    public class DashboardPage : BasePage
    {
        private By xpathLabelDashboard = By.XPath("//p[@class='text-muted m-b-0']");

        public DashboardPage(IWebDriver _driver) : base(_driver)
        {

        }

        /// <summary>
        /// True: element display
        /// False: element is not existed || not displayed
        /// </summary>
        /// <returns></returns>
        public bool IsLabelDashboardDisplay(int timeout = 1)
        {
            var defaultTimeout = driver.Manage().Timeouts().ImplicitWait; //lấy từ TimeSpan bên BrowserHelper
            try
            {
                //implicit wait 5s
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
                return driver.FindElement(xpathLabelDashboard).Displayed;
            }
            catch { return false; }
            finally
            {
                driver.Manage().Timeouts().ImplicitWait = defaultTimeout; //sửa xong timeout phải trả về ban đầu
            }

        }

        public bool IsLabelDashboardDisplay(object timout)
        {
            throw new NotImplementedException();
        }
    }
}
