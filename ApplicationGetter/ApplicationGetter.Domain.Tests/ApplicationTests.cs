using ApplicationGetter.Domain.ValueObjects;
using NUnit.Framework;

namespace ApplicationGetter.Domain.Tests
{
    public class ApplicationTests
    {
        [Test]
        public void TestInitializerWithoutId()
        {
            //
            // Arrange
            Url url = new Url("sss");
            PathLocal pathLocal = new PathLocal("ssss");
            bool debbugingMode = false;

            //
            // Act
            Application.Application application = new Application.Application(url, pathLocal, debbugingMode);

            //
            // Assert
            Assert.AreEqual(url, application.Url);
            Assert.AreEqual(pathLocal, application.PathLocal);
            Assert.AreEqual(debbugingMode, application.DebuggingMode);

        }

        [Test]
        public void TestLoadApplication()
        {
            //
            // Arrange
            int id = 2;
            Url url = new Url("sss");
            PathLocal pathLocal = new PathLocal("ssss");
            bool debbugingMode = false;

            //
            // Act
            var application = Application.Application.Load(id, url, pathLocal, debbugingMode);

            //
            // Assert
            Assert.AreEqual(id, application.Id);
            Assert.AreEqual(url, application.Url);
            Assert.AreEqual(pathLocal, application.PathLocal);
            Assert.AreEqual(debbugingMode, application.DebuggingMode);

        }
    }
}
