namespace Learn10.Record_types_can_seal_ToString;

public class Record_types_can_seal_ToString
{  
    public  record  Man(string FirstName)
    {
        public sealed override string  ToString() // C# 10.0 only for record class
        {
            return "From Base";
        }
    }

    public record BigMan(string FirstName, bool Big) : Man(FirstName)
    {
        
    }
    public static void Test()
    {
        Console.WriteLine(new BigMan("Test", true));//Display  From Base
    }
}