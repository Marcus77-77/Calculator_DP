

using ExpressionEvaluator.Parsers;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Inserisci una espressione semplice");
        var insertedtext = Console.ReadLine();
        double result = 0;


        ExpressionParser expression = new ExpressionParser();
        
        
        expression.ValidateExpression(insertedtext);
        expression.DecomposeExpression(insertedtext);
        result = expression.ExecuteCalc(insertedtext);
        Console.WriteLine(result);

        Console.ReadLine();
    }
}