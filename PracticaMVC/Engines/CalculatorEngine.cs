namespace PracticaMVC.Engines
{
    public class CalculatorEngine : ICalculatorEngine
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
        public int Substract(int a, int b)
        {
            return a - b;
        }
        public int Multiply(int a, int b)
        {
            return a * b;
        }
        public int Divide(int a, int b)
        {
            return a / b;
        }
    }
}