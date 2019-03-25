using Aardvark.Core;
using Aardvark.Web;
using OpenQA.Selenium;

namespace Aardvark.WebTests.Poms
{
    public class Tests
    {
        public Tests()
        {
            /* empty constructor */
        }

        public IWebDriver driver => (IWebDriver)Context.Get("driver");
        #region Page Elements


        public WebElement Login => new WebElement
                (
                    By.XPath("//*[@id=main - menu]/ul/li[8]/a/span")
                );

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
