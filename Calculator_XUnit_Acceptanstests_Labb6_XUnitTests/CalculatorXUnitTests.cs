using Calculator_XUnit_Acceptanstest_Labb6.Services;

namespace Calculator_XUnit_Acceptanstests_Labb6_XUnitTests
{
    public class CalculatorXUnitTests
    {
        private class MockCalculatorHistoryRepository : ICalculatorHistoryRepository
        {
            private readonly List<string> _history = new List<string>();

            public void SaveHistory(string entry)
            {
                _history.Add(entry);
            }

            public List<string> GetHistory()
            {
                return new List<string>(_history);
            }
        }

        [Theory]
        [InlineData(5, 3, 8)]
        [InlineData(-5, -3, -8)]
        [InlineData(5, -3, 2)]
        [InlineData(-5, 3, -2)]
        [InlineData(0, 0, 0)]
        public void Add_ShouldCalculateCorrectly(double a, double b, double expected)
        {
            var repository = new MockCalculatorHistoryRepository();
            var calculator = new Calculator(repository);
            var result = calculator.Add(a, b);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10, 4, 6)]
        [InlineData(-10, -4, -6)]
        [InlineData(10, -4, 14)]
        [InlineData(-10, 4, -14)]
        [InlineData(0, 0, 0)]
        public void Subtract_ShouldCalculateCorrectly(double a, double b, double expected)
        {
            var repository = new MockCalculatorHistoryRepository();
            var calculator = new Calculator(repository);
            var result = calculator.Subtract(a, b);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(7, 6, 42)]
        [InlineData(-7, -6, 42)]
        [InlineData(7, -6, -42)]
        [InlineData(-7, 6, -42)]
        [InlineData(0, 6, 0)]
        public void Multiply_ShouldCalculateCorrectly(double a, double b, double expected)
        {
            var repository = new MockCalculatorHistoryRepository();
            var calculator = new Calculator(repository);
            var result = calculator.Multiply(a, b);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(20, 4, 5)]
        [InlineData(-20, -4, 5)]
        [InlineData(20, -4, -5)]
        [InlineData(-20, 4, -5)]
        public void Divide_ShouldCalculateCorrectly(double a, double b, double expected)
        {
            var repository = new MockCalculatorHistoryRepository();
            var calculator = new Calculator(repository);
            var result = calculator.Divide(a, b);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Divide_ShouldThrowDivideByZeroException()
        {
            var repository = new MockCalculatorHistoryRepository();
            var calculator = new Calculator(repository);
            Assert.Throws<DivideByZeroException>(() => calculator.Divide(20, 0));
        }
    }
}
