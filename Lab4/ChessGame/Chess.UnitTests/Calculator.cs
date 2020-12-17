using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.UnitTests
{
    public class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public double Divide(double a, double b)
        {
            if(b == 0)
            {
                throw new ArgumentException("Dominador cant b 0");
            }
            return a / b;
        }
    }
}
