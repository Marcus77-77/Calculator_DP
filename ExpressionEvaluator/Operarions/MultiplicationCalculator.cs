﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionEvaluator.Operarions
{
    public class MultiplicationCalculator : ICalculator 
    {

        public double Calculate(double x, double y)
        {
            return x * y;
        }

    }
}
