using NUnit.Framework;
using Aardvark.Web;
using Aardvark.WebTests.Pages;

namespace Aardvark.WebTests.Test
{   [TestFixture]
    public class Test : TestBase
    {
        Tests Tests = new Tests();
        [Test]
        public void Test1()
        {
            string url = "https://phptravels.com/demo/";
            // Arrange
            Tests.Open();
            // Act
            Assert.AreEqual(url, Tests.CurrentUrl());
        }
    }
}
