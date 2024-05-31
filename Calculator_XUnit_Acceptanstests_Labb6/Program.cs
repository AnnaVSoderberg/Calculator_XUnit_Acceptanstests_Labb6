using Calculator_XUnit_Acceptanstest_Labb6.Services;
using Calculator_XUnit_Acceptanstest_Labb6;

namespace Calculator_XUnit_Acceptanstests_Labb6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICalculatorHistoryRepository repository = new CalculateHistoryRepository();
            ICalculator calculator = new Calculator(repository);
            var menuCalculator = new MenuCalculator(calculator);
            menuCalculator.StartCalculator();
        }
    }
}
