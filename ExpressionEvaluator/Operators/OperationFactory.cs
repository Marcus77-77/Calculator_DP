using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionEvaluator.Operators
{
    public static class OperationFactory
    {
        public static IOperator CreateOperator (char operators)
        {
            switch (operators)
            {
                case '+':
                    return new AdditionOperator();
                case '-':
                    return new SubtractionOperator();

                case '*':
                    return new MoltiplicationOperator();
                case '/':
                    return new DivideOperator();

                default: throw new NotSupportedException ();
            }     
        }
    }
}
