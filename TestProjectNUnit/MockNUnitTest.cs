using Moq;
using NUnit.Framework;


namespace TestProjectNUnit
{
    [TestFixture]
    internal class MockNUnitTest
    {
        /*private CuentaBancaria cuentaBancaria;
        [SetUp]
        public void Setup()
        {
            
        }*/
        [Test]
        public void Deposito_Input_Monto_100()
        {
            var mocking = new Mock<ILoggerGeneral>();
            // mocking.SetupAllProperties();
            mocking.Setup(s => s.IsLog).Returns(true);
            // verifica cuantas veces el mock esta lmado al metodo

            // mocking.Verify(u => u.LogDatabase(It.IsAny<string>()), Times.Exactly(1));
            var cuentaBancaria = new CuentaBancaria(mocking.Object);

            var resultado = cuentaBancaria.Deposito(100);

            Assert.That(resultado, Is.True);
            Assert.That(cuentaBancaria.GetBalance(), Is.EqualTo(100));
        }
        [TestCase(200, 100)]
        [TestCase(200, 150)]
        public void Retiro_Retiro100Balance200_Returns(int balance, int retiro)
        {
            var mocking = new Mock<ILoggerGeneral>();
            mocking.Setup(s => s.IsLog).Returns(true);
            mocking.Setup(u => u.LogDatabase(It.IsAny<string>())).Returns(true);
            // It.IsInRange<int>(int.MinValue, -1, Moq.Range.Inclusive);
            mocking.Setup(u => u.LogBalanceDespuesRetiro(It.Is<int>(x => x > 0))).Returns(true);
            var cuentaBancaria = new CuentaBancaria(mocking.Object);

            cuentaBancaria.Deposito(balance);
            var resultado = cuentaBancaria.Retiro(retiro);
            Assert.IsTrue(resultado);
        }
        [Test]
        public void CuentaBancariaLoggerGeneral_LogMockingOuPutReturnTrue()
        {
            var mocking = new Mock<ILoggerGeneral>();
            string testText = "Hola";
            mocking.Setup((e) => e.MessageWithOutParamsReturnBool(It.IsAny<string>(), out testText)).Returns(true);
            string paramsOut = "";
            var result = mocking.Object.MessageWithOutParamsReturnBool("Andy", out paramsOut);
            Assert.IsTrue(result);
        }
    }
}
