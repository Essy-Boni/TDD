using System;
using System.Collections.Generic;
using System.Text;

namespace DemoBasesTDD
{
    public class Calcul
    {
        public double Addition(double x, double y)
        {
            return x + y;
        }

        public double Division(double x, double y)
        {
            {
                //return 999; 
                if (y != 0)
                    return x / y;
                throw new DivideByZeroException("Division par zéro impossible.");
            }

        }
    }
}
