using NUnit.Framework;

namespace TestProjectNUnit
{
    [TestFixture]
    internal class ClientNUnitTest
    {
        [TestCase("Andy jesus", "Macias gomez")]
        public void ShouldReturnNameComplete(string firstName, string lasName)
        {
            // arrange
            var operationLibrary = new OperacionLibrary();
            // act
            var nameComplete = operationLibrary.CreateNameComplete(name: firstName, lastName: lasName);
            // assert
            Assert.That(nameComplete, Is.EqualTo($"{firstName} {lasName}"));

        }
    }
}
