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
    public class SystemZapisowyTest: BaseSeleniumTestClass
    {
        [TestMethod]
        public void LoginAsAdministrator()
        {
            try
            {
                driver.Navigate().GoToUrl(url);

                if (!driver.PageSource.Contains("Login") && !driver.PageSource.Contains("Add"))
                {
                    var logoutButton = driver.FindElement(By.Id("logout"));
                    logoutButton.Click();
                }

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
                logger.SaveLog(e, "login");
                screenshooter.SaveScreenShot("LoginAsAdministrator", driver);
                driver.Quit();
            }
        }

        [TestMethod]
        public void LoginAsNewRegisteredStudent()
        {
            AddNewStudent();

            try
            {
                if(driver.PageSource.Contains("Logout"))
                {
                    var logoutButton = driver.FindElement(By.Id("logout"));
                    logoutButton.Click();
                    Thread.Sleep(delay);
                }

                var loginButton = driver.FindElement(By.Id("login"));
                loginButton.Click();

                Thread.Sleep(delay);

                var emailInput = driver.FindElement(By.Id("Email"));
                emailInput.SendKeys("zuzannaboltuc@gmail.com");

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
                logger.SaveLog(e, "LoginAsNewRegisteredStudent");
                screenshooter.SaveScreenShot("LoginAsNewRegisteredStudent", driver);
                driver.Quit();
            }
        }

        [TestMethod]
        public void AddNewGroup()
        {
            LoginAsAdministrator();

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
                maxiumSeatsInput.Clear();
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
                logger.SaveLog(e, "AddNewGroup");
                screenshooter.SaveScreenShot("AddNewGroup", driver);
                driver.Quit();
            }
        }

        [TestMethod]
        public void DeleteGroup()
        {
            LoginAsAdministrator();

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
                logger.SaveLog(e, "DeleteGroup");
                screenshooter.SaveScreenShot("DeleteGroup", driver);
                driver.Quit();
            }
        }

        [TestMethod]
        public void AddNewStudent()
        {
            LoginAsAdministrator();

            try
            {
                var addButton = driver.FindElement(By.ClassName("dropdown-toggle"));
                addButton.Click();

                Thread.Sleep(delay);

                var addStudentButton = driver.FindElement(By.LinkText("Student"));
                addStudentButton.Click();

                Thread.Sleep(delay);

                var peselInput = driver.FindElement(By.Id("PESEL"));
                peselInput.Clear();
                peselInput.SendKeys("97110707070");

                Thread.Sleep(delay);

                var firstNameInput = driver.FindElement(By.Id("FirstName"));
                firstNameInput.Clear();
                firstNameInput.SendKeys("Zuzanna");

                Thread.Sleep(delay);

                var lastNameInput = driver.FindElement(By.Id("LastName"));
                lastNameInput.Clear();
                lastNameInput.SendKeys("Bołtuć");

                Thread.Sleep(delay);

                var birthDateInput = driver.FindElement(By.Id("BirthDate"));
                birthDateInput.SendKeys("07111997");

                Thread.Sleep(delay);

                var genderInput = driver.FindElement(By.Id("Gender"));
                genderInput.SendKeys("Female");

                Thread.Sleep(delay);

                var emailInput = driver.FindElement(By.Id("Email"));
                emailInput.SendKeys("zuzannaboltuc@gmail.com");

                Thread.Sleep(delay);

                var passwordInput = driver.FindElement(By.Id("Password"));
                passwordInput.SendKeys("123");

                Thread.Sleep(delay);

                var indexNumberInput = driver.FindElement(By.Id("IndexNumber"));
                indexNumberInput.Clear();
                indexNumberInput.SendKeys("238366");

                Thread.Sleep(delayLonger);

                var submitButton = driver.FindElement(By.Id("submit"));
                submitButton.Click();

                Thread.Sleep(delay);

                CheckStudentsList();
            }
            catch (Exception e)
            {
                logger.SaveLog(e, "AddNewStudent");
                screenshooter.SaveScreenShot("AddNewStudent", driver);
                driver.Quit();
            }
        }

        [TestMethod]
        public void CheckStudentsList()
        {
            try
            {
                if(driver.PageSource.Contains("Login"))
                {
                    LoginAsAdministrator();
                }
                else if (!driver.PageSource.Contains("Add"))
                {

                }

                var studentsButton = driver.FindElement(By.Id("students"));
                studentsButton.Click();

                Thread.Sleep(delayLonger);
            }
            catch (Exception e)
            {
                logger.SaveLog(e, "CheckStudentsList");
                screenshooter.SaveScreenShot("CheckStudentsList", driver);
                driver.Quit();
            }
        }

        [TestMethod]
        public void SignUpForTheGroupAsNewRegisteredStudent()
        {
            LoginAsNewRegisteredStudent();

            try
            {
                var groupsButton = driver.FindElement(By.Id("groups"));
                groupsButton.Click();

                Thread.Sleep(delayLonger);


                var signUpCell = driver.FindElement(By.LinkText("Sign up"));
                signUpCell.Click();

                Thread.Sleep(delayLonger);

                IAlert alert = driver.SwitchTo().Alert();
                Thread.Sleep(delayLonger);
                alert.Accept();

                Thread.Sleep(delayLonger);
            }
            catch (Exception e)
            {
                logger.SaveLog(e, "SignUpForTheGroupAsNewRegisteredStudent");
                screenshooter.SaveScreenShot("SignUpForTheGroupAsNewRegisteredStudent", driver);
                driver.Quit();
            }

        }

        [TestMethod]
        public void SignOutNewRegisteredStudentFromGroup()
        {
            SignUpForTheGroupAsNewRegisteredStudent();
            LoginAsAdministrator();

            try
            {
                var studentsButton = driver.FindElement(By.Id("students"));
                studentsButton.Click();

                Thread.Sleep(delayLonger);


                var studentCell = driver.FindElement(By.LinkText("Bołtuć"));
                studentCell.Click();

                var signOutCell = driver.FindElement(By.LinkText("Sign Out"));
                signOutCell.Click();

                Thread.Sleep(delayLonger);

                IAlert alert = driver.SwitchTo().Alert();
                Thread.Sleep(delayLonger);
                alert.Accept();

                Thread.Sleep(delayLonger);
            }
            catch (Exception e)
            {
                logger.SaveLog(e, "SignOutNewRegisteredStudentFromGroup");
                screenshooter.SaveScreenShot("SignOutNewRegisteredStudentFromGroup", driver);
                driver.Quit();
            }

        }

    }
}
