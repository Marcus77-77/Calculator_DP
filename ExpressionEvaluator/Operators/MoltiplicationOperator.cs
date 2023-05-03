using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionEvaluator.Operators
{
    public class MoltiplicationOperator : IOperator 
    {
        public char OperatorText { get { return '*'; } }
        public int Precedence { get { return 1; } }
    }
}
