using AngleSharp.Common;
using FluentAssertions;
using Newtonsoft.Json;
using SimpleSeleniumTest.Model;
using SimpleSeleniumTest.Page;
using WebDriverHelper.Helper;

namespace SimpleSeleniumTest.Helper
{
    public class KeywordHelper
    {
        private List<KeywordData> keywords;
        private BrowserHelper browserHelper;
        public KeywordHelper(List<KeywordData> keywords)
        {
            this.keywords = keywords;
        }

        /// <summary>
        /// Execute keyword in the List
        /// </summary>
        /// //Execute nhiều keywords
        public void ExecuteKeywords()
        {
            foreach (var keyword in keywords)
            {
                //go one by one
                ExecuteKeyword(keyword);
            }
        }


        //Execute 1 keyword trước
        public void ExecuteKeyword(KeywordData keyword)
        {

            switch (keyword.Keyword)
            {
                case "Open Browser":
                    browserHelper = new BrowserHelper();
                    browserHelper.OpenBrowser(browserType: keyword.Data);
                    break;
                case "GotoUrl":
                    browserHelper.GoToURL(keyword.Data);
                    break;
                case "Enter username":
                    EnterUsername(keyword.Data);
                    break;
                case "Enter password":
                    EnterPassword(keyword.Data);
                    break;
                case "Click login button":
                    ClickLoginButton();
                    break;
                case "Verify dashboard display": 
                    VerifyDashboardModel model = JsonConvert.DeserializeObject<VerifyDashboardModel>(keyword.Data); 
                    VerifyDashboardDisplay(model); 
                    break;
                case "Quit Browser":
                    browserHelper.QuitBrowser();
                    break;
                case "Enter username and password": 
                    UserModel userModel = JsonConvert.DeserializeObject<UserModel>(keyword.Data); 
                    EnterUsernameAndPassword(userModel); 
                    break;
                default:
                    throw new Exception("Not support this keyword");
            }
        }

        private void EnterUsername(string username)
        {
            LoginPage loginPage = new LoginPage(browserHelper.Driver);
            loginPage.InputUsername(username);
        }

        private void EnterPassword(string password)
        {
            LoginPage loginPage = new LoginPage(browserHelper.Driver);
            loginPage.InputPassword(password);
        }
        private void EnterUsernameAndPassword(UserModel userModel)
        {
            LoginPage loginPage = new LoginPage(browserHelper.Driver);
            loginPage.InputUsername(userModel.Username);
            loginPage.InputPassword(userModel.Password);
        }

        private void VerifyDashboardDisplay(VerifyDashboardModel data)
        {
            DashboardPage dashboardPage = new DashboardPage(browserHelper.Driver);
            dashboardPage.IsLabelDashboardDisplay(data.Timeout).Should().Be(data.Expected);
        }

        private void ClickLoginButton()
        {
            LoginPage loginPage = new LoginPage(browserHelper.Driver);
            loginPage.ClickLogin();
        }
    }
}
