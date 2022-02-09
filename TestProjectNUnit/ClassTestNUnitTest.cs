using NUnit.Framework;


namespace TestProjectNUnit
{
    [TestFixture]
    internal class ClassTestNUnitTest
    {
        [Test]
        public void GetClienteIsType()
        {
            var cliente = new Cliente();
            Assert.That(cliente, Is.TypeOf<Cliente>());
        }
    }
}
