using ExpressionEvaluator.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionEvaluator.Operarions
{
    public static class CalculatorFactory
    {
        public static ICalculator CreateCalculator(char operators)
        {
            switch (operators)
            {
                case '+':
                    return new AdditionCalculator();
                case '-':
                    return new SubtractorCalculator();

                case '*':
                    return new MultiplicationCalculator();
                case '/':
                    return new DivisorCalculator();

                default: throw new NotSupportedException();
            }
        }
    }
}
