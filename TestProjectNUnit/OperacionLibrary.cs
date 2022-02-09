using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectNUnit
{
    internal class OperacionLibrary
    {
        public List<int> numbersOdd = new();
        public double SumarDecimal(double decimalOne, double decimalTwo)
        {
            return decimalOne + decimalTwo;
        }
        public string CreateNameComplete(string name, string lastName)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                return $"{name} {lastName}";
            }
            throw new ArgumentException("El nombre esta en blanco");
        }
        public List<int> GetListaNumberOdd(int minValue, int maxValue)
        {
            numbersOdd.Clear();
            for (int index = minValue; index <= maxValue; index++)
            {
                if (index % 2 != 0)
                {
                    numbersOdd.Add(index);
                }
            }
            return numbersOdd;
        }

    }
    internal class Cliente
    {
        public string? Nombre { get; set; }
        public int Descuento { get; set; }
        public int OrderTotal { get; set; }
    }
    internal class BasicCLiente : Cliente
    { }
    internal class PremiunCliente : Cliente
    { }
}
