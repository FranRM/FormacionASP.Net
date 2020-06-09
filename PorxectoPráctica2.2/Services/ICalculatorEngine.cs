using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PorxectoPráctica2._2.Services
{
    public interface ICalculatorEngine
    {
        int Add(int a, int b);
        int Substract(int a, int b);
        int Multiply(int a, int b);
        int Divide(int a, int b);
    }
}
