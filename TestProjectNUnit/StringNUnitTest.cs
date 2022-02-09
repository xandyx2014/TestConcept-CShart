using NUnit.Framework;

namespace TestProjectNUnit
{
    [TestFixture]
    internal class StringNUnitTest
    {
        [TestCase("Andy jesus", "Macias gomez")]
        public void ShouldReturnNameComplete(string firstName, string lasName)
        {
            // arrange
            var operationLibrary = new OperacionLibrary();
            // act
            var nameComplete = operationLibrary.CreateNameComplete(name: firstName, lastName: lasName);
            // assert
            // Is,  para valor concretos
            Assert.That(nameComplete, Is.EqualTo($"{firstName} {lasName}"));
            // Does, para valores que contienen

            // Assert.That(nameComplete, Does.Contain($"{firstName}"));
            // Assert.That(nameComplete, Does.Contain($"{firstName}").IgnoreCase);
            // Assert.That(nameComplete, Does.StartWith(firstName).IgnoreCase);
        }
    }
}
