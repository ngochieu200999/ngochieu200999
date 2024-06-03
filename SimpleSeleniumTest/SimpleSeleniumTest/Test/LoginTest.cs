using FluentAssertions;
using SimpleSeleniumTest.Page;
using TestFrameworkCore.Helper;
using TestFrameworkCore.Helper.Report;

namespace SimpleSeleniumTest.Test
{
    [TestClass]
    public class LoginTest : BaseTest
    {
        private LoginPage loginPage;
        private DashboardPage dashboardPage;

        public override void SetUpPage()
        {
            loginPage = new LoginPage(browser.Driver);
            dashboardPage = new DashboardPage(browser.Driver);
        }

        //Cách 1
        //[TestInitialize]
        //public void SetUpPage() {
        //    loginPage = new LoginPage(browser.Driver);
        //    dashboardPage = new DashboardPage(browser.Driver);
        //}

        [TestMethod("TC01: Login with valid username and password")]
        public void VerifyValidUser()
        {
            //throw new Exception("aaaaaaddd");
            //Input username & password
            string username = ConfigurationHelper.GetConfig<string>("username");
            extentTest.LogMessage($"Read configuration - username: {username}");

            string password = ConfigurationHelper.GetConfig<string>("password");
            extentTest.LogMessage($"Read configuration - password: {password}");

            extentTest.LogMessage("Login with valid username: ");
            loginPage.LoginWithUsernameAndPassword(username, password);

            //Verify the dashboard is display
            //// Cách 1: MS Assert
            //Assert.IsTrue(dashboardPage.IsLabelDashboardDisplay());

            //Cách 2: FLUENT ASSERT (chỉ dùng MS Assert hoặc Fluent, không dùng cả 2)
            extentTest.LogMessage("Verify label Dashboard is display: ");
            dashboardPage.IsLabelDashboardDisplay(10).Should().BeTrue();
        }

        [TestMethod("TC02: Login with invalid username and password")]
        public void VerifyInvalidUser()
        {
            //Input wrong username ||  password
            string username = ConfigurationHelper.GetConfig<string>("username");
            loginPage.LoginWithUsernameAndPassword(username, "admin1234");

            //Verify error message
            //Assert.AreEqual(loginPage.GetErrorMessage(), "Invalid credentials");
            loginPage.GetErrorMessage().Should().Contain("Invalid");

            //Verify the dashboard page is NOT display
            //Assert.IsFalse(dashboardPage.IsLabelDashboardDisplay());
            dashboardPage.IsLabelDashboardDisplay().Should().BeFalse();
        }

        [TestMethod("TC03: Dynamic data -  Login test")]
        [DynamicData(nameof(DataLoginUser))]
        public void VerifyLoginUser(string username, string password, bool isLabelDashboardDisplay)
        {
            loginPage.LoginWithUsernameAndPassword(username, password);
            dashboardPage.IsLabelDashboardDisplay().Should().Be(isLabelDashboardDisplay);
        }

        public static IEnumerable<object[]> DataLoginUser
        {
            get
            {
                return new ExcelHelper(Path.Combine("Resource", "VerifyLoginUser.xlsx")).GetLoginUserData();
            }
        }
    }
}

