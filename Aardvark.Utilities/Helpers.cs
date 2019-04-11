using Aardvark.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aardvark.Utilities
{
    public class Helpers
    {
        public IWebDriver driver => (IWebDriver)Context.Get("driver");

        public string CurrentUrl()
        {
            string url = driver.Url.ToString();

            return url;
        }

        public void SelectDrp(IWebElement element, SelectType type, string options)
        {
            SelectElement select = new SelectElement(element);
            switch (type)
            {
                case SelectType.SelectByIndex:
                    try
                    {
                        select.SelectByIndex(Int32.Parse(options));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.GetBaseException().ToString());
                        throw new ArgumentException("Please input numberic when using selectByIndex");
                    }
                    break;
                case SelectType.SelectByText:
                    select.SelectByText(options);
                    break;
                case SelectType.SelectByValue:
                    select.SelectByValue(options);
                    break;
                default:
                    throw new Exception("Get error in using Selected");
            }
        }

        public void SetText(IWebElement element, string text)
        {
            try
            {
                element.Clear();
                element.SendKeys(text);
            }
            catch (WebDriverException e)
            {
                throw new SystemException("Not able to set text error" + e.Message);
            }
        }

        public string GetTitle()
        {
            return driver.Title;
        }

        public enum SelectType
        {
            SelectByIndex,
            SelectByText,
            SelectByValue,
        }
    }
}
