using SimpleSeleniumTest.Helper;
using System.Security.Cryptography.X509Certificates;
using TestFrameworkCore.Helper;

namespace SimpleSeleniumTest.Test
{
    [TestClass]
    public class KeywordDrivenTest
    {
        [TestMethod("TC04: Verify login by using Keyword driven")]
        public void VerifyLogin()
        {
            // Read keywords
            ExcelHelper excelHelper = new ExcelHelper(Path.Combine("Resources", "KeywordDriven.xlsx"));
            var keywords = excelHelper.GetKeywordDatas();

            // Execute keywords
            var keywordHelper = new KeywordHelper(keywords);
            keywordHelper.ExecuteKeywords();
        }

        [TestMethod("TC05: Verify login by using Keyword driven with Model")]
        public void VerifyLoginWithModel()
        {
            // Read keywords
            ExcelHelper excelHelper = new ExcelHelper(Path.Combine("Resources", "KeywordDriven2.xlsx"));
            var keywords = excelHelper.GetKeywordDatas();

            // Execute keywords
            var keywordHelper = new KeywordHelper(keywords);
            keywordHelper.ExecuteKeywords();
        }
    }
}
