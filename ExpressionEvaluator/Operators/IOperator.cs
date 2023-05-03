using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionEvaluator.Operators
{
    public interface IOperator
    {
        public char OperatorText { get; }
        public int Precedence { get; }

    }
}
