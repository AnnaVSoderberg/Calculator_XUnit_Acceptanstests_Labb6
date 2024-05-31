using Calculator_XUnit_Acceptanstest_Labb6.Services;
using System;
using System.Collections.Generic;

namespace Calculator_XUnit_Acceptanstest_Labb6
{
    public class MenuCalculator
    {
        private readonly ICalculator _calculator;

        public MenuCalculator(ICalculator calculator)
        {
            _calculator = calculator;
        }


        public void StartCalculator()
        {
            while (true)
            {
                DisplayMenu();
                var operation = Console.ReadLine();

                if (!IsValidOperation(operation))
                {
                    Console.WriteLine("Invalid operation. Please try again.");
                    continue;
                }

                Console.Clear();

                if (operation == "6")
                {
                    break;
                }

                if (operation == "5")
                {
                    _calculator.PrintHistory();
                    continue;
                }

                if (!TryGetNumber("Enter first number: ", out double num1) ||
                    !TryGetNumber("Enter second number: ", out double num2))
                {
                    continue;
                }

                try
                {
                    double result = PerformOperation(operation, num1, num2);
                    Console.WriteLine($"Result: {result}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        private void DisplayMenu()
        {
            Console.WriteLine("\n--- Calculator Menu ---");
            Console.WriteLine("Select a number and press Enter:");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. History");
            Console.WriteLine("6. Exit");
            Console.Write("Your choice: ");
        }

        private bool IsValidOperation(string operation)
        {
            return operation == "1" || operation == "2" ||
                   operation == "3" || operation == "4" ||
                   operation == "5" || operation == "6";
        }

        private bool TryGetNumber(string prompt, out double number)
        {
            Console.Write(prompt);
            if (!double.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return false;
            }
            return true;
        }

        private double PerformOperation(string operation, double num1, double num2)
        {
            return operation switch
            {
                "1" => _calculator.Add(num1, num2),
                "2" => _calculator.Subtract(num1, num2),
                "3" => _calculator.Multiply(num1, num2),
                "4" => _calculator.Divide(num1, num2),
                _ => throw new InvalidOperationException("Unknown operation")
            };
        }
    }
}
