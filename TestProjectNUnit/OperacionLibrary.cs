using System;
using System.Collections.Generic;
using System.IO;
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
    internal class CuentaBancaria
    {
        private readonly ILoggerGeneral _loggerGeneral;

        public int balance { get; set; }

        public CuentaBancaria(ILoggerGeneral loggerGeneral)
        {
            balance = 0;
            _loggerGeneral = loggerGeneral;
        }
        public bool Deposito(int monto)
        {
            _loggerGeneral.Message($"Monto de {monto}");
            balance = balance + monto;
            return true;
        }
        public bool Retiro(int monto)
        {
            if (monto <= balance)
            {
                _loggerGeneral.LogBalanceDespuesRetiro(monto);
                balance = balance - monto;
                return _loggerGeneral.LogBalanceDespuesRetiro(balance);
            }
            return _loggerGeneral.LogBalanceDespuesRetiro(balance - monto);
        }
        public int GetBalance()
        {
            return balance;
        }

    }
    public interface ILoggerGeneral
    {
        bool IsLog { get; set; }

        void Message(string message);
        bool LogDatabase(string message);
        bool LogBalanceDespuesRetiro(int balanceDespuesRetiro);
        bool MessageWithOutParamsReturnBool(string message, out string ouputStr);
    }
    class LoggerGeneral : ILoggerGeneral
    {
        public bool IsLog { get; set; }

        public bool LogBalanceDespuesRetiro(int balanceDespuesRetiro)
        {
            if (balanceDespuesRetiro >= 0)
            {
                Console.WriteLine("Success");
                return true;
            }
            return false;
        }

        public bool LogDatabase(string message)
        {
            Console.WriteLine(message);
            return true;
        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }

        public bool MessageWithOutParamsReturnBool(string message, out string ouputStr)
        {
            ouputStr = "Hola" + message;
            return true;
        }
    }
    class LoggerGeneralMock : ILoggerGeneral
    {
        public bool IsLog { get; set; }

        public bool LogBalanceDespuesRetiro(int balanceDespuesRetiro)
        {
            if (balanceDespuesRetiro >= 0)
            {
                Console.WriteLine("Success");
                return true;
            }
            return false;
        }

        public bool LogDatabase(string message)
        {
            Console.WriteLine(message);
            return true;
        }


        public void Message(string message)
        {

        }

        public bool MessageWithOutParamsReturnBool(string message, out string ouputStr)
        {
            ouputStr = "Hola" + message;
            return true;
        }
    }

}
