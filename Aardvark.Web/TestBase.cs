using Aardvark.Core;
using Aardvark.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.IO;
using Assert = Aardvark.Core.Assert;
using TestContext = Aardvark.Core.Context;

namespace Aardvark.Web
{
    public class TestBase
    {
        #region Test Run Variable Defaults
        public static ReportingTasks _reportingTasks;

        public const int defaultTimeoutInSeconds = 60;

        #endregion Test Run Variable Defaults

        #region Test Properties

        /// <summary>
        /// Get the WebDriver from the current Test's Context.
        /// </summary>
        protected static IWebDriver driver => (IWebDriver)TestContext.Get("driver");

        /// <summary>
        /// Get the Base URL from the current Test's Context.
        /// </summary>
        protected static string baseUrl => TestContext.Get("baseUrl").ToString();

        #endregion Test Properties

        [SetUp]
        public void Setup()
        {
            // Save a reference to the current Test's log in its TestContext
            TestContext.Set("log", "");


            // Log the test attributes of the current [Test]
            Log.StandardAttributes();

            // Log Before Action
            Log.BeforeAction();

            
            BeginReporting();

            // Perform the action
            try
            {
                _reportingTasks.InitializeTest();
                Session.Create();
                // Set WebDriver's window to full screen
                AppBase.Maximize();

                // Delete all cookies
                AppBase.DeleteAllCookies();


                // Logging - After action success
                Log.Success();

            }
            catch (Exception e)
            {
                // Logging - After action exception
                Log.Failure(e.Message);
                // Fail current test
                Assert.Fail(e.Message);
            }
            finally
            {
                // Logging - After action
                Log.Finally();
            }
        }

        [TearDown]
        public void TearDown()
        {
            // Log Before Action
            Log.BeforeAction();
                            

            // Perform the action
            try
            {
                // Check if the Test that is ending was a failure
                if (NUnit.Framework.TestContext.CurrentContext.Result.Outcome != NUnit.Framework.Interfaces.ResultState.Success)
                {
                    // Take screenshot of the failure state
                    AppBase.TakeScreenshot();
                }
                _reportingTasks.FinalizeTest();
                _reportingTasks.CleanUpReporting();
                // Quit this driver, closing every associated window.
                AppBase.Quit();
               
                // Logging - After action success
                Log.Success();
            }
            catch (Exception e)
            {
                // Logging - After action exception
                Log.Failure(e.Message);
                // Fail current test
                Assert.Fail(e.Message);
            }
            finally
            {
                // Logging - After action
                Log.Finally();
                // Print log to console (for Visual Studio and Bamboo)
                string log = TestContext.Get("log").ToString();
                if (log.Length > 0)
                {
                    Console.WriteLine(log);
                }
            }
        }
        public static void BeginReporting()
        {
            ExtentReports extentReports = ReportingManager.Instance;
            //extentReports.LoadConfig(Directory.GetParent(NUnit.Framework.TestContext.CurrentContext.TestDirectory).Parent.FullName + "\\extent-config.xml");
            extentReports.LoadConfig("C:/Users/jaket/source/repos/AardVark/Aardvark.Reporting/extent-config.xml");
            //Note we have hardcoded the browser, we will deal with this later
            //extentReports.AddSystemInfo("Browser", "Chrome");

            _reportingTasks = new ReportingTasks(extentReports);

        }
        
    }
}
