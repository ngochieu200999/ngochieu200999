using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace TestFrameworkCore.Helper.Report
{
    public class ReportHelper
    {
        private ExtentReports extent;

        public ReportHelper()
        {
            InitReport();
        }

        public void InitReport()
        {
            extent = new ExtentReports(); //khởi tạo mới (nếu để kiểu dữ liệu nó sẽ hiểu khai báo một đối tượng mới khác với extent trong ExportTest
            var reportName = $"Report_{DateTime.Now.ToFileTimeUtc()}.html";
            var reportPath = Path.Combine(Directory.GetCurrentDirectory(), "Reports", reportName);
            var spark = new ExtentSparkReporter(reportPath); //Cái này hỗ trợ mutile report cả HTML và Email
            extent.AttachReporter(spark);
        }

        public void ExportReport()
        {
            extent.Flush();
        }

        public ExtentTest CreateTest(string testName, string description)
        {
            //chỉ chú ý tên và description còn mấy chi tiết khác library tự tạo
            return extent.CreateTest(testName, description);
        }
    }
}
