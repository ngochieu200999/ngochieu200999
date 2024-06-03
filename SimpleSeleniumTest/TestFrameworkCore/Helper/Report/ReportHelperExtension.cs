using AventStack.ExtentReports;

namespace TestFrameworkCore.Helper.Report
{
    public static class ReportHelperExtension
    {
        public static void LogMessage(this ExtentTest test, string message)
        {
            test.Log(Status.Info, message);
        }

        /// <summary>
        /// Passed/ Failed (chỉ chấp nhận pass hoặc fail)
        /// </summary>
        /// <param name="test"></param>
        /// <param name="result"></param>
        public static void AddResult(this ExtentTest test, string result)
        {
            if (result.Equals("Passed"))
            {
                test.Pass("Testcase is passed");
            }
            else
            {
                test.Fail("Testcase is failed");
            }
        }

        public static void AddImageBase64(this ExtentTest test, string base64)
        {
            test.AddScreenCaptureFromBase64String(base64, "Screenshot");
        } 
    }
}
