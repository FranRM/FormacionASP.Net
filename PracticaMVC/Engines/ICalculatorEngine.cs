namespace PracticaMVC.Engines
{
    public interface ICalculatorEngine
    {
         int Add(int a, int b);
        int Substract(int a, int b);
        int Multiply(int a, int b);
        int Divide(int a, int b);
    }
}