using System;
using System.IO;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Shouldly;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace SystemZapisowy.Tests.UI
{
    [TestClass]
    public class SystemZapisowyTest
    {
        private ChromeDriver driver = new ChromeDriver();
        private WebDriverWait wait;
        private readonly string screenShotPath = "E:\\Programowanie\\Projekty\\C# VisualStudio\\SystemZapisowy\\SystemZapisowy.Tests\\Content\\images\\";
        private readonly string logPath = "E:\\Programowanie\\Projekty\\C# VisualStudio\\SystemZapisowy\\SystemZapisowy.Tests\\Content\\logs\\";
        private readonly string url = "http://localhost:55648/";
        private readonly int delay = 500;
        private readonly int delayLonger = 2000;

        [TestMethod]
        public void Login()
        {
            try
            {
                driver.Navigate().GoToUrl(url);
                driver.Manage().Window.Maximize();

                var loginButton = driver.FindElement(By.Id("login"));
                loginButton.Click();

                Thread.Sleep(delay);

                var emailInput = driver.FindElement(By.Id("Email"));
                emailInput.SendKeys("administrator@gmai.com");

                Thread.Sleep(delay);

                var passwordInput = driver.FindElement(By.Id("Password"));
                passwordInput.SendKeys("123");

                Thread.Sleep(delay);

                var submitButton = driver.FindElement(By.Id("submit"));
                submitButton.Click();

                wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
                wait.Until(wt => wt.FindElement(By.Id("home-index-div")));

                Thread.Sleep(delay);
            }
            catch (Exception e)
            {
                SaveLog(e, "login");
                SaveScreenShot("Login");
                driver.Quit();
            }
        }

        [TestMethod]
        public void AddNewGroup()
        {
            Login();

            try
            {
                var addButton = driver.FindElement(By.ClassName("dropdown-toggle"));
                addButton.Click();

                Thread.Sleep(delay);

                var addGroupButton = driver.FindElement(By.LinkText("Group"));
                addGroupButton.Click();

                Thread.Sleep(delay);

                var dropdownCourse = driver.FindElement(By.Id("CourseId"));
                var selectCourse = new SelectElement(dropdownCourse);
                selectCourse.SelectByText("Databases");

                Thread.Sleep(delay);

                var dropdownType = driver.FindElement(By.Id("Type"));
                var selectType = new SelectElement(dropdownType);
                selectType.SelectByText("Lecture");

                Thread.Sleep(delay);

                var dropdownStartTime = driver.FindElement(By.Id("StartTime"));
                var selectStartTime = new SelectElement(dropdownStartTime);
                selectStartTime.SelectByText("9:15");

                Thread.Sleep(delay);

                var dropdownDay = driver.FindElement(By.Id("DayId"));
                var selectDay = new SelectElement(dropdownDay);
                selectDay.SelectByText("Friday");

                Thread.Sleep(delay);

                var maxiumSeatsInput = driver.FindElement(By.Id("MaximumSeats"));
                maxiumSeatsInput.SendKeys("30");

                Thread.Sleep(delay);

                var teacherInput = driver.FindElement(By.Id("Teacher"));
                teacherInput.SendKeys("mgr. Mariusz Pudzianowski");

                Thread.Sleep(delay);

                var submitButton = driver.FindElement(By.Id("submit"));
                submitButton.Click();

                Thread.Sleep(delay);

                wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
                wait.Until(wt => wt.FindElement(By.LinkText("Groups")));

                Thread.Sleep(delayLonger);
            }
            catch (Exception e)
            {
                SaveLog(e, "AddNewGroup");
                SaveScreenShot("AddNewGroup");
                driver.Quit();
            }
        }

        [TestMethod]
        public void DeleteGroup()
        {
            Login();

            try
            {
                var groupsButton = driver.FindElement(By.Id("groups"));
                groupsButton.Click();

                Thread.Sleep(delayLonger);


                var deleteCell = driver.FindElement(By.LinkText("Delete"));
                deleteCell.Click();

                Thread.Sleep(delayLonger);

                IAlert alert = driver.SwitchTo().Alert();
                Thread.Sleep(delayLonger);
                alert.Accept();

                Thread.Sleep(delayLonger);
            }
            catch (Exception e)
            {
                SaveLog(e, "CheckAddedGroup");
                SaveScreenShot("CheckAddedGroup");
                driver.Quit();
            }
        }



        private void SaveLog(Exception exception, string methodName)
        {
            var fileName = methodName + "-" + DateTime.Now.ToString("yyyyMMddTHHmmss") + ".txt";
            using (StreamWriter writer = new StreamWriter(logPath + fileName, true))
            {
                writer.WriteLine("-----------------------------------------------------------------------------");
                writer.WriteLine("Date : " + DateTime.Now);
                writer.WriteLine();

                while (exception != null)
                {
                    writer.WriteLine(exception.GetType().FullName);
                    writer.WriteLine("Message : " + exception.Message);
                    writer.WriteLine("StackTrace : " + exception.StackTrace);

                    exception = exception.InnerException;
                }
            }
        }

        private void SaveScreenShot(string methodName)
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
