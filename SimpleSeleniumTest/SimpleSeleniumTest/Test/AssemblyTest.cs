using TestFrameworkCore.Helper;
using TestFrameworkCore.Helper.Report;
[assembly: Parallelize(Workers = 4, Scope = ExecutionScope.MethodLevel)]
namespace SimpleSeleniumTest.Test
{
    [TestClass]
    public class AssemblyTest
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext)
        {
            // Setup report
            BaseTest.ReportHelper = new ReportHelper();
            //BaseTest.ReportHelper.InitReport(); //cách 2 tạo contructor
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            //Export report
            if (BaseTest.ReportHelper != null)
            {
                BaseTest.ReportHelper.ExportReport();
            }
        }
    }
}
