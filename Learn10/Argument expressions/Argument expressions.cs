using System.Runtime.CompilerServices;

namespace Learn10.Argument_expressions;

public class Argument_expressions
{
    public static bool ValidateArgument(string parameterName, bool condition, [CallerArgumentExpression("condition")] string? message=null)
    {
        if (!condition)
        {
            Console.WriteLine($"Argument failed validation: <{message}> {parameterName}");
            //Argument failed validation: <func is not null> func //c 10.0
            //Argument failed validation: <> func //c 9.0
        }
        return condition;
    }

    public static void Operation(Action func)
    {
        if (ValidateArgument(nameof(func), func is not null))
            func();
    }

    public static void Test()
    {
        Operation(null);
    }
}