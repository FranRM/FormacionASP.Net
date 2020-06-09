using System.Collections.Generic;
namespace FormacionASP.Net{
public interface ICalculatorServices
{
    int Calculate(int a, int b, string operation);
}
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