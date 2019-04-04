using Aardvark.Core;
using Aardvark.Web;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Aardvark.WebTests.Pages
{
    public class Tests
    {
        public Tests()
        {
            /* empty constructor */
        }

        public IWebDriver driver => (IWebDriver)Context.Get("driver");
        #region Page Elements

        [FindsBy(How = How.XPath, Using = "//*[@id=main - menu]/ul/li[8]/a/span")]
        public IWebElement Login { get; set; }
       

        #endregion Page Elements

        #region Page Specific Methods

        /// <summary>
        /// Open the 'Home' page.
        /// </summary>
        public void Open()
        {
            AppBase.GoToUrl("/");
        }

        public string CurrentUrl()
        {
            string url;
           url = driver.Url.ToString();

            return url;
        }
        #endregion Page Specific Methods
    }
}
