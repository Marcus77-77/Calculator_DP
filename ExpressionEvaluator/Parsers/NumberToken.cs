using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionEvaluator.Parsers
{
    public class NumberToken
    {
        public double  _number { get; set; } = 0;

        public bool _discarded { get; set; } = false;

        public int _position { get; set; } = 0;

      

        public NumberToken(double number, int position, bool discarded )
        {
            _number = number;
            _position = position;
            _discarded = discarded;
        }
    }
}
