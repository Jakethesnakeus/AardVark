using NUnit.Framework;
using Aardvark.Web;
using Aardvark.WebTests.Pages;
using Aardvark.Resources;

namespace Aardvark.WebTests.Test
{   [TestFixture]
    public class LoginTests : TestBase
    {
        Login Login = new Login();
        [Test]
        public void LoginTest()
        {
            Login.Open();
            Login.EnterCredentials();
            Assert.AreEqual(Urls.Products, Login.CurrentUrl());
        }
        [Test]
        public void LoginFailureTest()
        {
            Login.Open();
            Login.EnterBadCredentials();
            Assert.AreNotEqual(Urls.Products, Login.CurrentUrl());
        }
    }
}
