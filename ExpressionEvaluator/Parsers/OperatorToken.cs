using ExpressionEvaluator.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionEvaluator.Parsers
{
    public class OperatorToken
    {
        public IOperator _operator { get; set; }

        public int _position { get; set; }

        

        public OperatorToken(char symbol , int position)
        {
            _operator = OperationFactory.CreateOperator(symbol);
            _position = position;
        }
    }
}
