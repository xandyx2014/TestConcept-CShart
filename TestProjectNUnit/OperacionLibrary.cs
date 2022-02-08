using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectNUnit
{
    internal class OperacionLibrary
    {
        public double SumarDecimal(double decimalOne, double decimalTwo)
        {
            return decimalOne + decimalTwo;
        }
        public string CreateNameComplete(string name, string lastName)
        {
            return $"{name} {lastName}";
        }
    }
}
