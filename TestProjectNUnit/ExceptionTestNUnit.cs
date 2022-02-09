using NUnit.Framework;
using System;


namespace TestProjectNUnit
{
    [TestFixture]
    internal class ExceptionTestNUnit
    {
        [Test]
        public void CreateNameComplete()
        {
            var operation = new OperacionLibrary();
            var exceptionDetail = Assert.Throws<ArgumentException>(() => operation.CreateNameComplete("", ""));
            Assert.AreEqual("El nombre esta en blanco", exceptionDetail?.Message ?? "");
            Assert.That(
                () => operation.CreateNameComplete("", ""),
                Throws.ArgumentException.With.Message.EqualTo("El nombre esta en blanco")
            );
            Assert.Throws<ArgumentException>(() => operation.CreateNameComplete("", ""));
            // verfica unicamente que lanza la exception
            Assert.Throws<ArgumentException>(() => operation.CreateNameComplete("", ""));
            Assert.That(
                () => operation.CreateNameComplete("", ""),
                Throws.ArgumentException
            );
        }
    }
}
