using AngleSharp;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System.Drawing;
using TestFrameworkCore.Helper;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace WebDriverHelper.Helper
{
    public class BrowserHelper
    {
        public IWebDriver Driver;
        /// <summary>
        /// Init browser/open browser and navigate to url
        /// </summary>
        /// <param name="url"></param>
        /// <exception cref="Exception"></exception>
        public void OpenBrowser(string url = null, string browserType = null)
        {
            //Nếu không truyền browserType thì đọc từ Config
            //Ngược lại truyền cái thứ mình truyền vô
            if (string.IsNullOrEmpty(browserType))
            {
                browserType = ConfigurationHelper.GetConfig<string>("browser");
            }
            Driver = DriverfactoryHelper.InitDriver(browserType);

            //Setting implicit wait
            int timeout = ConfigurationHelper.GetConfig<int>("timeout");
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);

            Driver.Manage().Window.Maximize();

            if (!string.IsNullOrEmpty(url))
            {
                GoToURL(url);
            }
        }

        /// <summary>
        /// Quit and dispose all resources
        /// </summary>
        public void QuitBrowser()
        {
            if (Driver is null)
            {
                return;
            }

            Driver.Quit();
        }
        public void GoToURL(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public string TakeScreenshotAsBase64()
        {
            // Chụp màn hình và lưu vào biến image
            var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();

            //Chuyển đổi ảnh thành dạng byte array
            byte[] screenshotAsByteArray = screenshot.AsByteArray;

            // Chuyển đổi byte array thành ảnh
            using (MemoryStream stream = new MemoryStream(screenshotAsByteArray))
            {
                using (Bitmap image = new Bitmap(stream))
                {

                    // Chuyển đổi ảnh thành chuỗi base64
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                        byte[] imageBytes = memoryStream.ToArray();
                        return Convert.ToBase64String(imageBytes);
                    }
                }
            }
        }

        //public string TakeScreenShotAsBase64()
        //{
        //    // Convert WebDriver object to ITakesScreenshot
        //    ITakesScreenshot screenshotDriver = (ITakesScreenshot)Driver;

        //    // Take the screenshot
        //    Screenshot screenshot = screenshotDriver.GetScreenshot();

        //    return screenshot.AsBase64EncodedString;
        //}
    }
}
