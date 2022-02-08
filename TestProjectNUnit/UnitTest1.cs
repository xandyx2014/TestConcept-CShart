using NUnit.Framework;

namespace TestProjectNUnit
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(4)]
        [TestCase(6)]
        [TestCase(8)]
        public void Test1(int numero)
        {
            bool isPar = numero % 2 == 0;
            Assert.IsTrue(isPar);
            Assert.That(isPar, Is.EqualTo(true));
        }
        // esta es otra forma esperando un resultado 
        [Test]
        [TestCase(3, ExpectedResult = false)]
        [TestCase(5, ExpectedResult = false)]
        [TestCase(7, ExpectedResult = false)]
        public bool IsValueOdd_InputNumber_ReturFalse(int numero)
        {
            bool isPar = numero % 2 == 0;
            /*Assert.IsTrue(isPar);
            Assert.That(isPar, Is.EqualTo(false));*/
            return isPar;
        }
        [Test]
        [TestCase(2.2, 1.2)] // resultado debe ser 3.4
        [TestCase(2.23, 1.24)] // resultado debe ser 4.47
        public void IsSumarDecimal_InputDosNumeros_GetValueCorrect(double decimalOne, double decimalTwo)
        {
            // arrage
            var op = new OperacionLibrary();
            // act
            double resultado = op.SumarDecimal(decimalOne, decimalTwo);
            // assert
            // Assert.That(3.4, Is.EqualTo(resultado));
            // se agrega el delta
            Assert.AreEqual(3.4, resultado, 0.2);
        }
    }
}