using NUnit.Framework;
using Aardvark.Web;

namespace Aardvark.WebTests.Test
{   [TestFixture]
    public class Tests : TestBase
    {
        [Test]
        public void Test1()
        {
            string url = "https://phptravels.com/demo/";
            // Arrange
            App.Tests.Open();
            // Act
            Assert.AreEqual(url, App.Tests.CurrentUrl());
        }
    }
}
