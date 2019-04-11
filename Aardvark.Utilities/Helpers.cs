using Aardvark.Core;
using OpenQA.Selenium;
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
    }
}
