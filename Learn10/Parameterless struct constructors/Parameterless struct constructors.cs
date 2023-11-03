namespace Learn10.Static_Abstract_Members_In_Interfaces;

public class Parameterless_struct_constructors
{
    struct S {
        public int X = 1; //  cannot have instance property or field initializers in structs
        public S(int x) { X = x; }
    }

    public static void Test()
    {
        var s = new S(); //C# 10.0
        var s1 = s with { X = 2 }; // C# 10.0
    }
}