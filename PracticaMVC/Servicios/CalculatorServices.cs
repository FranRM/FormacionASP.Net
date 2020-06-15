using System;

namespace PracticaMVC
{
    public class CalculatorServices : ICalculatorServices
    {
         private readonly Engines.ICalculatorEngine _calculationEngine;

    public CalculatorServices(Engines.ICalculatorEngine calculationEngine)
    {
        _calculationEngine = calculationEngine;
    }

    public int Calculate(int a, int b, string operation)
    {
        switch (operation)
        {
            case "+":
                return _calculationEngine.Add(a, b);
            case "-":
                return _calculationEngine.Substract(a, b);
            case "*":
                return _calculationEngine.Multiply(a, b);
            case "/":
                return _calculationEngine.Divide(a, b);
            default:
                var message = $"Operation '{operation}' not supported";
                throw new ArgumentOutOfRangeException(nameof(operation), message);
        }
    }
    }
}