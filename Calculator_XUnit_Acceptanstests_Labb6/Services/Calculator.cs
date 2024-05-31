using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_XUnit_Acceptanstest_Labb6.Services
{
    public class Calculator : ICalculator
    {
        private readonly ICalculatorHistoryRepository _repository;

        public Calculator(ICalculatorHistoryRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Calculator()
        {
        }

        public double Add(double a, double b)
        {
            double result = a + b;
            _repository.SaveHistory($"{a} + {b} = {result}");
            return result;
        }

        public double Subtract(double a, double b)
        {
            double result = a - b;
            _repository.SaveHistory($"{a} - {b} = {result}");
            return result;
        }

        public double Multiply(double a, double b)
        {
            double result = a * b;
            _repository.SaveHistory($"{a} * {b} = {result}");
            return result;
        }

        public double Divide(double a, double b)
        {
            if (b == 0) throw new DivideByZeroException();
            double result = a / b;
            _repository.SaveHistory($"{a} / {b} = {result}");
            return result;
        }

        public void PrintHistory()
        {
            Console.WriteLine("Calculation History:");
            foreach (var entry in _repository.GetHistory())
            {
                Console.WriteLine(entry);
            }
        }
    }
}
