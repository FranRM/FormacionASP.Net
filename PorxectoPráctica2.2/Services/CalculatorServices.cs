using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
namespace PorxectoPráctica2._2.Services {

public class CalculatorServices : ICalculatorServices
{
    private readonly ICalculatorEngine _CalculatorEngine;
    private readonly ILogger<CalculatorMiddleWare> _calclogger;

        public CalculatorServices(ICalculatorEngine CalculatorEngine, ILogger<CalculatorMiddleWare> calclogger)
    {
        _CalculatorEngine = CalculatorEngine;
            _calclogger = calclogger;
    }

    public int Calculate(int a, int b, string operation)
    {
            _calclogger.LogDebug($"Realizando o calculo: {a}{operation}{b}");
            switch (operation)
        {
            case "+":
                return _CalculatorEngine.Add(a, b);
            case "-":
                return _CalculatorEngine.Substract(a, b);
            case "*":
                return _CalculatorEngine.Multiply(a, b);
            case "/":
                return _CalculatorEngine.Divide(a, b);
            default:
                var message = $"Operation '{operation}' not supported";
                throw new ArgumentOutOfRangeException(nameof(operation), message);
        }
    }
    
}
}