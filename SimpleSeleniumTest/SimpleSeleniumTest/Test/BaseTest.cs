using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using TestFrameworkCore.Helper;
using TestFrameworkCore.Helper.Report;
using WebDriverHelper.Helper;

namespace SimpleSeleniumTest.Test
{
    public class BaseTest
    {
        protected BrowserHelper browser;
        public static ReportHelper ReportHelper;
        public TestContext TestContext { get; set; }
        protected ExtentTest extentTest; //để protect cho các thằng con dùng, extentTest viết thường do private

        public virtual void SetUpPage()
        {

        }

        [TestInitialize]
        public void TestInitialize()
        {
            // Init browser
            browser = new BrowserHelper();
            string? url = ConfigurationHelper.GetConfig<string>("url");
            browser.OpenBrowser(url);

            // Call Setup page
            SetUpPage();

            // Create a test
            // REFLECTION
            // Find the method with the given name
            MethodInfo testMethod = GetType().GetMethod(TestContext.TestName);

            // Check if the method has the DisplayName attribute
            TestMethodAttribute displayNameAttribute = testMethod.GetCustomAttribute<TestMethodAttribute>();

            string displayName = displayNameAttribute != null ? displayNameAttribute.DisplayName : TestContext.TestName;

            // Lấy Description (chính là TC01:..)
            extentTest = ReportHelper.CreateTest(TestContext.TestName, displayName);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            
            //Add result
            if(extentTest != null)
            {
                if(TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
                {
                    extentTest.AddImageBase64(browser.TakeScreenshotAsBase64());
                }
                extentTest.AddResult(TestContext.CurrentTestOutcome.ToString());
            }

            browser.QuitBrowser();
        }
    }
}
