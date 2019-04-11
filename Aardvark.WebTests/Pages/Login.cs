using Aardvark.Core;
using Aardvark.Resources;
using Aardvark.Utilities;
using Aardvark.Web;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;

namespace Aardvark.WebTests.Pages
{
    public class Login
    {
        Helpers help = new Helpers();
        public Login()
        {
            /* empty constructor */
        }

        public IWebDriver driver => (IWebDriver)Context.Get("driver");
        #region Page Elements

        public WebElement UserName => new WebElement(By.Id(LoginObj.UserName));
        public WebElement Password => new WebElement(By.Id(LoginObj.Password));
        public WebElement LoginBtn => new WebElement(By.CssSelector(LoginObj.LoginBtn) );


        #endregion Page Elements

        #region Page Specific Methods

        /// <summary>
        /// Open the 'Home' page.
        /// </summary>
        public void Open()
        {
            AppBase.GoToUrl("/");
        }

        public void EnterCredentials()
        {

                UserName.ClickViaJavaScript();
                Sleep(1000);
                UserName.SendKeys(LoginResource.UserName);
                Password.SendKeys(LoginResource.Password);
                LoginBtn.Click();
           
        }
        public void EnterBadCredentials()
        {
            UserName.ClickViaJavaScript();
            Sleep(1000);
            UserName.SendKeys("");
            Password.SendKeys(LoginResource.Password);
            LoginBtn.Click();

        }
        public void Sleep(int time)
        {
            Core.Sleep.Milliseconds(time);
        }
        public string CurrentUrl()
        {
            return help.CurrentUrl();
        }
        #endregion Page Specific Methods
    }
}
