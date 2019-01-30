using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemZapisowy.Tests.UI.Helpers;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SystemZapisowy.Tests.UI
{
    public class BaseSeleniumTestClass
    {
        protected ChromeDriver driver;
        protected WebDriverWait wait;
        protected readonly string url;
        protected readonly int delay;
        protected readonly int delayLonger;
        protected Logger logger;
        protected Screenshooter screenshooter;

        public BaseSeleniumTestClass()
        {
            driver = new ChromeDriver();
            logger = new Logger();
            screenshooter = new Screenshooter();
            url = "http://localhost:55648/";
            delay = 500;
            delayLonger = 2000;
        }
    }
}
