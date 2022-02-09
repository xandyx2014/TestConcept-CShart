using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectNUnit
{
    [TestFixture]
    internal class CollectionNUnitTest
    {
        [Test]
        public void GetListNumberOnlyOdd()
        {
            var operacionLibrary = new OperacionLibrary();
            var numberOddExpected = new List<int>() { 5, 7, 9 };
            // lanza todos los errores de los logs
            Assert.Multiple(() =>
            {
                var numbersOdd = operacionLibrary.GetListaNumberOdd(5, 10);
                Assert.That(numbersOdd, Is.EquivalentTo(numberOddExpected));
                Assert.AreEqual(numbersOdd, numbersOdd);
                // verifica que el 5 esta
                Assert.That(numbersOdd, Does.Contain(5));
                Assert.Contains(5, numbersOdd);
                Assert.That(numbersOdd, Is.Not.Empty);
                Assert.That(numbersOdd.Count, Is.EqualTo(3));
                Assert.That(numbersOdd, Has.No.Member(100));
                // si estan ordenados
                Assert.That(numbersOdd, Is.Ordered);
                // Saber si hay duplicados
                Assert.That(numbersOdd, Is.Unique);
                // que esta en un rango
                Assert.That(numbersOdd.First(), Is.InRange(5, 10));
            });

        }
    }
}
