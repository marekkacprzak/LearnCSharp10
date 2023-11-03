namespace Learn10.Lambda_expression_improvements;

public class Explicit_return_type
{
    public static void Test()
    {
        var choose = object (bool b) => b ? 1 : "two"; // c# 10.0 Func<bool, object>
    }
}