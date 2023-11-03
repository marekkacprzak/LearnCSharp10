namespace Learn10.Lambda_expression_improvements;

public class Natural_type
{
    public static void Test()
    {
        Func<string, int> sd = (string s) => int.Parse(s);//c# 9.0
        var parse = (string s) => int.Parse(s);//c# 10 
        Console.WriteLine("var parse = (string s) => int.Parse(s)");
    }
}