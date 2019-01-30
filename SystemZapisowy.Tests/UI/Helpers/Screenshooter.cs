using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SystemZapisowy.Tests.UI.Helpers
{
    public class Screenshooter
    {
        private readonly string screenShotPath = "E:\\Programowanie\\Projekty\\C# VisualStudio\\SystemZapisowy\\SystemZapisowy.Tests\\Content\\images\\";

        public void SaveScreenShot(string methodName, ChromeDriver driver)
        {
            try
            {
                var screenShotDriver = driver as ITakesScreenshot;
                var screenshot = screenShotDriver.GetScreenshot();
                var fileName = methodName + "-" + DateTime.Now.ToString("yyyyMMddTHHmmss") + ".png";
                screenshot.SaveAsFile((screenShotPath + fileName), ScreenshotImageFormat.Png);
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}
