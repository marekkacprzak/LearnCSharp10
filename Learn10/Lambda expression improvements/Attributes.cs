using System.Diagnostics.CodeAnalysis;

namespace Learn10.Lambda_expression_improvements;

public class AttributesInLambda
{
    public static void Test()
    {
        Func<string?, int?> parse =  ([AllowNull]s) => (s is not null) ? int.Parse(s) : null;
        var concat = ([DisallowNull] string a, [DisallowNull] string b) => a + b;
        var inc = [return: Validate] (int? s) => s.HasValue ? s++ : null;
        //nameof(s) c# 11.0 
        Console.WriteLine("var inc = [return: Validate] (int? s) => s.HasValue ? s++ : null;");
    }
}
public class ValidateAttribute : Attribute
{
}
