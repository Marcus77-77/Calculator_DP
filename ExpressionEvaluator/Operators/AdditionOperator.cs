using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionEvaluator.Operators
{
    public class AdditionOperator : IOperator
    {
        public char OperatorText { get { return '+'; } }
        public int Precedence { get { return 2; } }
    }
}
