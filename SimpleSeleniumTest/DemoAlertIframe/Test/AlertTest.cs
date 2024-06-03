using OpenQA.Selenium;
using WebDriverHelper.Helper;

namespace DemoAlertIframe.Test
{
    [TestClass]
    public class AlertTest
    {
        BrowserHelper browserHelper;
        private By xpathButtonAlert(string text) => By.XPath($"//button[text() = '{text}']"); //vì cái này là method nên dùng =>
        //private By xpathLabel = 
        [TestInitialize]
        public void Initiallize()
        {
            browserHelper = new BrowserHelper();
            browserHelper.OpenBrowser("https://the-internet.herokuapp.com/javascript_alerts");
        }

        [TestMethod]
        public void VerifyAlert()
        {
            //Click button
            browserHelper.Driver.FindElement(xpathButtonAlert("Click for JS Alert")).Click();
            browserHelper.Driver.SwitchTo().Alert().Accept();
        }

        [TestMethod]
        public void VerifyConfirm()
        {
            browserHelper.Driver.FindElement(xpathButtonAlert("Click for JS Confirm")).Click();
            browserHelper.Driver.SwitchTo().Alert().Dismiss();
        }

        [TestMethod]
        public void VerifyPrompt()
        {
            browserHelper.Driver.FindElement(xpathButtonAlert("Click for JS Prompt")).Click();
            
            //Input random value
            string inputValue = "Hieu" + DateTime.Now.ToFileTimeUtc();
            browserHelper.Driver.SwitchTo().Alert().SendKeys(inputValue);
            browserHelper.Driver.SwitchTo().Alert().Accept();

            ////Get result
            //string actualValue = browserHelper.Driver.FindElement(xpa)
        }


    }
}
