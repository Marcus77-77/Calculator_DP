using ExpressionEvaluator.Operarions;
using ExpressionEvaluator.Operators;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ExpressionEvaluator.Parsers
{
    public class ExpressionParser
    {
        private List<NumberToken> numberTokens { get; set; } = new();

        private List<OperatorToken> operatorTokens { get; set; } = new();

        public void ValidateExpression (string expression)
        {
            try
            {
                if (MathOperators.Operations.Contains(expression[0]))
                {
                    throw new Exception($"il carattere nella posizione {expression[0] + 1} è un operatore");
                    break;
                }
                else if (MathOperators.Operations.Contains(expression[expression.Length - 1]))
                {
                    throw new Exception($"il carattere nella posizione {expression[expression.Length] - 1} è un operatore");
                    break;
                }
                else if (String.isNullOrEmpty(expression)) 
                {
                    throw new Exception("la stringa è vuota");
                    break;
                }
                // this bool controls if there is a subsequent operator.
                bool isOperatorOld = false;

                for (int i = 0; i < expression.Length; i++) 
                {
                    bool isOperator = MathOperators.Operations.Contains(expression[i]);

                    var token = char.IsDigit(expression[i]) || isOperator ;




                    if (!token)
                    {
                        throw new ArgumentException("Contiene Caratteri non Validi");
                        break;
                    }
                    else if (isOperatorOld && isOperator)
                    {
                        throw new ArgumentException("Ci Sono Due Operatori di seguito");
                        break;
                    }
                    else if (isOperator)
                    {
                        isOperatorOld = true;
                    } 
                    else
                    {
                        isOperatorOld = false;
                    }             
                }
               

            }
            catch (Exception) 
            {
                Console.WriteLine("Hai sbagliato");
                break;
            }

        }
        public void DecomposeExpression(string expression)
        {
            string number = "";
            int numberposition = 0;
            bool oldCharisOperator = false;
            bool discarded = false;
            

            for (int i = 0; i < expression.Length; i ++)
            {

                

                if (char.IsDigit(expression[i]))
                {
                    number += expression[i];
                    if (oldCharisOperator)
                    {
                        numberposition = i;

                        oldCharisOperator = false;
                    }
                }
                else
                {                  
                    oldCharisOperator = true;

                    numberTokens.Add(new NumberToken
                        (Double.Parse(number),
                         numberposition,
                         discarded));
                    operatorTokens.Add(new OperatorToken(

                         expression[i] , i

                        ));
                    number = "";
                }

                if (i == expression.Length - 1) 
                {
                    numberTokens.Add(new NumberToken
                        (
                          Double.Parse(number), numberposition, discarded
                        ));
                }


            }
        }




        public double ExecuteCalc(string expression)
        {
            var sortedOperator = operatorTokens.OrderBy(sO => sO._operator.Precedence)
                                               .ToList();
            double result = 0;

            foreach(var @operator in sortedOperator)
            {
                var validNumbers = numberTokens.Where(vn => vn._discarded == false);

                var beforeOperator = validNumbers.Where(vn => vn._position < @operator._position)
                                                 .Last();

                var afterOperator = validNumbers.Where(vn => vn._position > @operator._position)
                                                .First();

               var partialresult = CalculatorFactory.CreateCalculator(@operator._operator.OperatorText)
                                                    .Calculate(beforeOperator._number,afterOperator._number);
                
               afterOperator._discarded = true;


               beforeOperator._number = partialresult;


                result = partialresult;
                                               

            }
            return result;

        }
        
        
       
    }
    
}
