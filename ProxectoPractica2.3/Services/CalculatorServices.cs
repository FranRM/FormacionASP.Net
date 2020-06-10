using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
namespace ProxectoPractica2._3.Services {

public class CalculatorServices : ICalculatorServices
{
    private readonly ICalculatorEngine _CalculatorEngine;

        public CalculatorServices(ICalculatorEngine CalculatorEngine)
    {
        _CalculatorEngine = CalculatorEngine;
    }

    public int Calculate(int a, int b, string operation)
    {
            
            switch (operation)
        {
            case "add":
                return _CalculatorEngine.Add(a, b);
            case "sub":
                return _CalculatorEngine.Substract(a, b);
            case "mul":
                return _CalculatorEngine.Multiply(a, b);
            case "div":
                return _CalculatorEngine.Divide(a, b);
            default:
                var message = $"Operation '{operation}' not supported";
                throw new ArgumentOutOfRangeException(nameof(operation), message);
        }
    }
    
}
}